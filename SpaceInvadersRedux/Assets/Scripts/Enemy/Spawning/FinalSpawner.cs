using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalSpawner : MonoBehaviour
{
    //References
    public List<GameObject> enemies = new List<GameObject>();
    BoxCollider box;
    public List<Transform> enemySpawn = new List<Transform>();
    
    //Boss related
    public Transform bossSpawn;
    public GameObject boss;

    //Teleport effect
    public GameObject teleport;

    //Barrier behind player
    public GameObject block;
    public Transform Barrier;

    //Room Manager
    public GameObject manager;

    private void Start()
    {
        box = GetComponent<BoxCollider>();
        manager.SetActive(false);
    }
    

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Start the manager
            manager.SetActive(true);

            //Block player from exiting arena
            Instantiate(block, Barrier.position, Barrier.rotation);

            //spawn boss in
            Instantiate(boss, bossSpawn.position, bossSpawn.rotation);

            //spawn enemies
            for (int i = 0; i < enemySpawn.Count; i++)
            {
                Instantiate(enemies[i], enemySpawn[i].transform.position, enemySpawn[i].transform.rotation);
                Instantiate(teleport, enemySpawn[i].transform.position, enemySpawn[i].transform.rotation);
            }
            box.enabled = false;
        }
    }
}
