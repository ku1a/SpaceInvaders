using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueDoor : CollisionDoor
{  
    public override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !Keys.blueKey)
        {
            if (Sound != null)
            {
                PlaySound(LockedSound);
            }           
        }
        if (other.gameObject.tag == "Player" && Keys.blueKey)
        {
            DoorOpen = true;
            DoorControl("Open");
            PlaySound(DoorOpenSound);
            Collider.enabled = false;
        }
    }
}
