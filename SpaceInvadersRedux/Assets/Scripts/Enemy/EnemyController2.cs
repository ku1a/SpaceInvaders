    using UnityEngine;
using UnityEngine.AI;

public class EnemyController2 : MonoBehaviour
{
    //Local Variables
    //Patrolling:
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking:
    public float timeBetweenAttacks;
    bool hasAttacked;
    public float bulletSpeed;
    public int damageDealt;

    //States:
    public float detectRange, attackRange;
    public bool playerInDetectRange, playerInAttackRange;

    //References
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;

    public GameObject evilBullet;
    public GameObject attackArea;

    private void Awake()
    {
        player = GameObject.Find("First Person Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Check if player is within detection or attacking range, then call functions accordingly
        playerInDetectRange = Physics.CheckSphere(transform.position, detectRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInDetectRange && !playerInAttackRange)
        {
            Patrolling();
        }
        if (playerInDetectRange && !playerInAttackRange)
        {
            Chasing();
        }
        if (playerInDetectRange && playerInAttackRange)
        {
            Attacking();
        }
    }

    private void Patrolling()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }
        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        float randX = Random.Range(-walkPointRange, walkPointRange); //randomize position in x position
        float randZ = Random.Range(-walkPointRange, walkPointRange); //randomize position in z position

        walkPoint = new Vector3(transform.position.x + randX, transform.position.y, transform.position.z + randZ); //set a new vector3 displacement

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround)) //confirm that walkPointSet is true if on top of ground layer
            walkPointSet = true;
    }

    private void Chasing()
    {
        agent.SetDestination(player.position);
    }

    private void Attacking()
    {
        //Stop enemy
        agent.SetDestination(transform.position);

        transform.LookAt(player); //have player look at enemy when shooting

        if (!hasAttacked)
        {
            //Perform Attack, can be substituted with anything
            GameObject bullet = Instantiate(evilBullet);
            bullet.transform.position = attackArea.transform.position - new Vector3(0, 1f, 0);
            bullet.transform.forward = attackArea.transform.forward;
            bullet.GetComponent<Rigidbody>().AddForce(attackArea.transform.forward * bulletSpeed, ForceMode.VelocityChange);
            bullet.GetComponent<EnemyBullet>().bulletDamage = damageDealt;

            hasAttacked = true;
            Invoke("ResetAttack", timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        hasAttacked = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectRange);
    }
}
