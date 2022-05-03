using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    //local variables 
    Shoot2 rifleStats, heavyStats;
    public int rifleAmmoAdd = 50;
    public int heavyAmmoAdd = 16;

    //references
    public GameObject rifle, heavy;
    public AudioClip rifleSound;
    public AudioClip heavySound;
    public AudioSource sound;

    private void Start()
    {
        rifleStats = rifle.GetComponent<Shoot2>();
        heavyStats = heavy.GetComponent<Shoot2>();
        rifleSound = AudioFiles.Rifle;
        heavySound = AudioFiles.Shotgun;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 13)
        {
            if (other.tag == "Rifle" && rifleStats.bulletsLeft != rifleStats.magazineSize)
            {
                if (rifleStats.bulletsLeft + rifleAmmoAdd > rifleStats.magazineSize) //If current ammo + pickup exceeds maximum capacity, add maximum minus current instead
                    rifleStats.bulletsLeft += (rifleStats.magazineSize - rifleStats.bulletsLeft);
                else
                    rifleStats.bulletsLeft += rifleAmmoAdd; //otherwise add 50
                Destroy(other.gameObject);
                PlaySound(rifleSound);
            }

            if (other.tag == "Shot" && heavyStats.bulletsLeft != heavyStats.magazineSize)
            {
                if (heavyStats.bulletsLeft + heavyAmmoAdd > heavyStats.magazineSize) //If current ammo + pickup exceeds maximum capacity, add maximum minus current instead
                    heavyStats.bulletsLeft += (heavyStats.magazineSize - heavyStats.bulletsLeft);
                else
                    heavyStats.bulletsLeft += heavyAmmoAdd; //otherwise add 16
                Destroy(other.gameObject);
                PlaySound(heavySound);
            }
        }
    }

    public void PlaySound(AudioClip audio)
    {
        sound.clip = audio;
        sound.Play();
        Debug.Log("Sound has triggered.");
    }
}
