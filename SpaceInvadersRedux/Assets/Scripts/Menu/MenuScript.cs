using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour 
{

    public void LoadScene(string sceneName)
	{
		if (sceneName == null)
			Debug.Log("<color=orange>"+gameObject.name+": No Scene Name Was given for LoadScene function!</color>");
			SceneManager.LoadScene(sceneName); //load a scene
	}

	public void QuitGame()
    {
		Application.Quit();
		Debug.Log("This is working...");
    }
}
