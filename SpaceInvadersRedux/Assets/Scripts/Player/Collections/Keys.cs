using UnityEngine;
using UnityEngine.UI;

public class Keys : MonoBehaviour
{
    //Local variables
    public bool redKey = false;
    public bool blueKey = false;
    public bool yellowKey = false;

    //References
    public Image blue, red, yellow;
    public AudioSource sound;

    public AudioClip keys;

    private void Awake()
    {
        blue.gameObject.SetActive(false);
        red.gameObject.SetActive(false);
        yellow.gameObject.SetActive(false);
    }

    private void Start()
    {
        keys = AudioFiles.Key;
    }

    private void OnTriggerEnter(Collider other) //other refers to object collided with (both objects must have a collider, and one object must have a rigidbody to work)
    {
        //implemented a nested version for legibility and integrity
        if (other.gameObject.tag == "Key")
        {
            if (other.gameObject.name == "RedKey" && !redKey)
            {
                redKey = true;
                red.gameObject.SetActive(true);
            }

            if (other.gameObject.name == "BlueKey" && !blueKey)
            {
                blueKey = true;
                blue.gameObject.SetActive(true);
            }

            if (other.gameObject.name == "YellowKey" && !yellowKey)
            {
                yellowKey = true;
                yellow.gameObject.SetActive(true);
            }

            PlaySound(keys);
            Debug.Log("Key Collected!");
            Destroy(other.gameObject);
        }
    }

    private void PlaySound(AudioClip audio)
    {
        sound.clip = audio;
        sound.Play();
        Debug.Log("Sound has triggered.");
    }
}
