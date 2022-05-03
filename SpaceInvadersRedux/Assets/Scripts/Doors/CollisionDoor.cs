using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollisionDoor : MonoBehaviour
{
    //References
    Animator animator;
    bool doorOpen;
    Keys keys;
    AudioClip doorSound;
    AudioClip locked;

    AudioSource sound;
    BoxCollider box;

    private void Awake()
    {
        sound = this.gameObject.AddComponent<AudioSource>();
        sound.playOnAwake = false;
        sound.loop = false;
        box = GetComponent<BoxCollider>();
    }
    void Start()
    {
        doorOpen = false;
        animator = transform.GetComponent<Animator>();
        keys = FindObjectOfType<Keys>();
        doorSound = AudioFiles.DoorSound;
        locked = AudioFiles.Locked;
    }

    //Check player enters trigger, doorOpen is true and Animation triggers
    public virtual void OnTriggerEnter(Collider other) { }

    //Check player leaves trigger, doorOpen is false and Animation triggers
    /*private void OnTriggerExit(Collider other)
    {
        if (doorOpen && (other.tag == "Player" || other.tag == "Enemy"))
        {
            doorOpen = false;
            DoorControl("Close");
        }
    }*/

    protected void DoorControl(string direction)
    {
        animator.SetTrigger(direction); //sets the trigger to one in its list i.e. Open or Close
    }

    protected void PlaySound(AudioClip audio)
    {
        sound.clip = audio;
        sound.Play();
        Debug.Log("Door sound has triggered.");
    }

    //Properties for child classes to access
    public bool DoorOpen
    {
        set { doorOpen = value; }
        get { return doorOpen; }
    }

    public Keys Keys
    {
        get { return keys; }
    }

    //Sound Properties
    public AudioSource Sound
    {
        set { sound = value; }
        get { return sound; }
    }

    public AudioClip DoorOpenSound
    {
        get { return doorSound; }
    }

    public AudioClip LockedSound
    {
        get { return locked; }
    }

    public BoxCollider Collider
    {
        get { return box; }
    }
}
