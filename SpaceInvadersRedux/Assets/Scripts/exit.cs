using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exit : MonoBehaviour
{
    public string sceneName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (sceneName == null)
            {
                Debug.Log("You need to insert a scene name!");
            }
            else
                SceneManager.LoadScene("Credits");
        }
    }
}
