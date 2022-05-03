using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGibbManager : MonoBehaviour
{
    static EnemyGibbManager pieces;

    private void Awake()
    {
        pieces = this;
    }

    //Held variables
    public GameObject yellow;
    public GameObject orange;
    public GameObject purple;
    public GameObject blue;

    public static GameObject Yellow
    {
        get { return pieces.yellow; }
    }

    public static GameObject Orange
    {
        get { return pieces.orange; }
    }

    public static GameObject Purple
    {
        get { return pieces.purple; }
    }
    
    public static GameObject Blue
    {
        get { return pieces.blue; }
    }
}
