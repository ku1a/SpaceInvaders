using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 50f;
    public GameObject corpse;

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
    }
}
