using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemySpawn : MonoBehaviour
{
    //References
    public List<GameObject> enemies = new List<GameObject>();
    BoxCollider colliderbox; 
    public List<Transform> spawnPoints = new List<Transform>();
    public GameObject teleport;

    Keys keys;

    void Start()
    {
        colliderbox = GetComponent<BoxCollider>();
        keys = FindObjectOfType<Keys>();
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //This code implies that both enemies and spawnPoints will have the same element size. This works like a queue system spawning enemies in their list order
            for(int i = 0; i < spawnPoints.Count; i++)
            {
                Instantiate(enemies[i], spawnPoints[i].transform.position, spawnPoints[i].transform.rotation);
                Instantiate(teleport, spawnPoints[i].transform.position, spawnPoints[i].transform.rotation);
            }
            colliderbox.enabled = false;
        }
    }

    public BoxCollider ColliderBox
    {
        get { return colliderbox; }
    }

    public Keys Keys
    {
        get { return keys; }
    }
}
