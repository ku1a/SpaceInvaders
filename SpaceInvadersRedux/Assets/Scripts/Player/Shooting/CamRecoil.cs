using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRecoil : MonoBehaviour
{
    //LOCAL VARIABLES:
    public float rotationSpeed = 6f;
    public float returnSpeed = 25f;
    //Offset to camera when firing
    public Vector3 RecoilRotation = new Vector3(2f, 2f, 2f);
    private Vector3 currentRotation;
    private Vector3 Rot;

    private void FixedUpdate()
    {
        currentRotation = Vector3.Lerp(currentRotation, Vector3.zero, returnSpeed * Time.deltaTime);
        Rot = Vector3.Slerp(Rot, currentRotation, rotationSpeed * Time.deltaTime);
        transform.localRotation = Quaternion.Euler(Rot);
    }

    //Apply offset based on vector3 variable RecoilRotation
    public void Fire()
    {
        currentRotation += new Vector3(-RecoilRotation.x, Random.Range(-RecoilRotation.y, RecoilRotation.y), Random.Range(-RecoilRotation.z, RecoilRotation.z));
        //make it based on time, retrieve from currently active weapon
    }
}
