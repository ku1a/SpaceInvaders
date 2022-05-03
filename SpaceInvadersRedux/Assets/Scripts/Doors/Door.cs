using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : CollisionDoor
{
    //Local variables accessed through Properties on abstract class

    //Check player enters trigger, doorOpen is true and Animation triggers
    public override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            DoorOpen = true;
            DoorControl("Open");
            PlaySound(DoorOpenSound);
            Collider.enabled = false;
        }
    }
}
