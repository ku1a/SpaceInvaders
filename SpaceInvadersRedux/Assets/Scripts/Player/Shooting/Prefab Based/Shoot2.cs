using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot2 : MonoBehaviour
{
    //Local Variables:
    public int damage;
    public float timeBetweenShooting, spread, range, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    public int bulletsLeft;
    int bulletsShot;
    public string ammotype;
    public float bulletSpeed;

    //bools 
    bool shooting, readyToShoot;

    //References
    public Camera fpsCam;
    public GameObject bulletPrefab;
    public GameObject barrel;

    public AdjustableBar ammoMeter;
    public CamRecoil recoil;

    AudioSource fire;
    public GameObject muzzleFlash;

    private void Awake()
    {
        //bulletsLeft = magazineSize; Leave bullet count at whatever is set in inspector.
        readyToShoot = true;
        fire = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        //Shoot
        if (readyToShoot && shooting && bulletsLeft > 0)
        {
            bulletsShot = bulletsPerTap;
            Bang();
        }
        ammoMeter.SetCurrent(bulletsLeft);
    }
  
    private void Bang()
    {
        fire.Play();
        recoil.Fire();
        readyToShoot = false;

        //Spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //Calculate Direction with Spread
        Vector3 direction = fpsCam.transform.forward + new Vector3(x, y, 0);

        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = barrel.transform.position;
        bullet.transform.forward = barrel.transform.forward;
        //bullet.transform.Rotate(x, y, Random.Range(-2, 2));

        bullet.GetComponent<Rigidbody>().AddForce(barrel.transform.forward * bulletSpeed + direction , ForceMode.VelocityChange);
        bullet.GetComponent<BulletBehavior>().bulletDamage = damage;
        //OLD bullet.GetComponent<BulletBehavior>().speed = bulletSpeed;

        //Graphics
        Instantiate(muzzleFlash, barrel.transform.position, Quaternion.identity);

        bulletsLeft--;
        bulletsShot--;

        Invoke("ResetShot", timeBetweenShooting);

        if (bulletsShot > 0 && bulletsLeft > 0)
            Invoke("Bang", timeBetweenShots);
    }
    private void ResetShot()
    {
        readyToShoot = true;
    }

}