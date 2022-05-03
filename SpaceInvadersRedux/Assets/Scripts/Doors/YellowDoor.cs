using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowDoor : CollisionDoor
{
    public override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !Keys.yellowKey)
        {
            if (Sound != null)
            {
                PlaySound(LockedSound);
            }
        }
        if (other.gameObject.tag == "Player" && Keys.yellowKey)
        {
            DoorOpen = true;
            DoorControl("Open");
            PlaySound(DoorOpenSound);
            Collider.enabled = false;
        }
    }
}
