using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    private void Update()
    {      
        Invoke("Die", 8);
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }
}
