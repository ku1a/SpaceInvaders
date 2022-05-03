using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitManager : MonoBehaviour
{
    static ExitManager Exiting;

    private void Awake()
    {
        Exiting = this;
    }

    //Held variables
    public GameObject portal;

    public static GameObject Portal
    {
        get { return Exiting.portal; }
    }
}
