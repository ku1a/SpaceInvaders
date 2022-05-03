using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSpawner : EnemySpawn
{
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && Keys.redKey)
        {
            //This code implies that both enemies and spawnPoints will have the same element size. This works like a queue system spawning enemies in their list order
            for (int i = 0; i < spawnPoints.Count; i++)
            {
                Instantiate(enemies[i], spawnPoints[i].transform.position, spawnPoints[i].transform.rotation);
                Instantiate(teleport, spawnPoints[i].transform.position, spawnPoints[i].transform.rotation);
            }
            ColliderBox.enabled = false;
        }
    }
}
