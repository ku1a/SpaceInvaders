using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedDoor : CollisionDoor
{
    public override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !Keys.redKey)
        {
            if (Sound != null)
            {
                PlaySound(LockedSound);
            }
        }
        if (other.gameObject.tag == "Player" && Keys.redKey)
        {
            DoorOpen = true;
            DoorControl("Open");
            PlaySound(DoorOpenSound);
            Collider.enabled = false;
        }
    }
}
