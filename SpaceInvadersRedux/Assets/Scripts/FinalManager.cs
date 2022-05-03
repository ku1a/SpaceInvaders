using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalManager : MonoBehaviour
{
    public GameObject medkit;
    public GameObject rifleAmmo;
    public GameObject shotgunAmmo;

    public List<Transform> medkits = new List<Transform>();
    public List<Transform> rifle = new List<Transform>();
    public List<Transform> shotgun = new List<Transform>();

    //Replenishment Countdown
    public float timeToReplenish = 30;
    float countdown;

    // Start is called before the first frame update
    void Start()
    {
        Replenish();
    }

    private void Update()
    {
        //When counter hits 0, perform replenishments
        countdown -= Time.deltaTime;

        if (countdown <= 0)
        {
            countdown = timeToReplenish;
            Replenish();
        }
    }

    void Replenish()
    {
        foreach (Transform spawn in medkits)
        {
            Instantiate(medkit, spawn.position, spawn.rotation);
        }
        foreach (Transform spawn in rifle)
        {
            Instantiate(rifleAmmo, spawn.position, spawn.rotation);
        }
        foreach (Transform spawn in shotgun)
        {
            Instantiate(shotgunAmmo, spawn.position, spawn.rotation);
        }
    }
}
