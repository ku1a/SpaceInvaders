using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    //Local attributes of Bullet
    public int bulletDamage;

    //References to other objects
    public Stats player;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag != "Enemy" && collision.transform.tag != "Player" && collision.transform.tag != "Bullet")
        {
            Destroy(gameObject);
        }
        else if (collision.transform.tag == "Player")
        {
            player = collision.gameObject.GetComponent<Stats>();
            player.TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
    }
}
