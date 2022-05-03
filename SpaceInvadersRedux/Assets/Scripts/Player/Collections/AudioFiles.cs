using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFiles : MonoBehaviour
{
    //delcaring a static variable of class type AudioFiles
    static AudioFiles Sounds;

    private void Awake()
    {
        Sounds = this; //declared variable refers to this class
    }

    //open variables of type AudioClip which can reference AudioClips
    public AudioClip locked;
    public AudioClip doorSound;
    public AudioClip rifleAmmoPickup;
    public AudioClip shotgunAmmoPickup;
    public AudioClip healthPickup;
    public AudioClip key;

    public static AudioClip Locked
    {
        get { return Sounds.locked; }
    }

    public static AudioClip DoorSound
    {
        get { return Sounds.doorSound; }
    }

    public static AudioClip Rifle
    {
        get { return Sounds.rifleAmmoPickup; }
    }

    public static AudioClip Shotgun
    {
        get { return Sounds.shotgunAmmoPickup; }
    }

    public static AudioClip Health
    {
        get { return Sounds.healthPickup; }
    }

    public static AudioClip Key
    {
        get { return Sounds.key; }
    }
}
