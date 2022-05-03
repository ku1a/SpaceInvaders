using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float health = 50f;
    public GameObject corpse;
    public GameObject explosion;  

    //Exit reference
    public GameObject exit;

    private void Start()
    {
        exit = ExitManager.Portal;
    }

    public void takeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        Instantiate(corpse, transform.position, transform.rotation);
        Instantiate(explosion, transform.position + new Vector3(0f, 20f, 0f), transform.rotation);
        Instantiate(exit, transform.position, transform.rotation);
    }
}
