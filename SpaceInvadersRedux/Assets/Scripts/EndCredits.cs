using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCredits : MonoBehaviour
{
    private float time = 24f;

    private void Start()
    {
        Invoke("AfterCreditsScene", time);
    }

    private void AfterCreditsScene()
    {
        SceneManager.LoadScene("Menu_YouWin");
    }
}
