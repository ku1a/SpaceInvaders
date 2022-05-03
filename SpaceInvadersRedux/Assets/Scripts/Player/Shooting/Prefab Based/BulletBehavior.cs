using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    //Local attributes
    public int bulletDamage;

    //References
    public Enemy enemyStats;
    public GameObject impact;
    Boss bossStats;

    // Update is called once per frame
    void Update()
    {
        //transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag != "Enemy" && collision.transform.tag != "Player" && collision.transform.tag != "Bullet")
        {
            Destroy(gameObject);
            Instantiate(impact, transform.position, transform.rotation);
        }
        if (collision.transform.tag == "Enemy")
        {
            enemyStats = collision.gameObject.GetComponent<Enemy>();
            enemyStats.takeDamage(bulletDamage);
            Destroy(gameObject);
            Instantiate(impact, transform.position, transform.rotation);
        }       
        if (collision.transform.tag == "boss")
        {
            bossStats = collision.gameObject.GetComponent<Boss>();
            bossStats.takeDamage(bulletDamage);
            Destroy(gameObject);
            Instantiate(impact, transform.position, transform.rotation);
        }
    }
}
