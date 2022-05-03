using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    //Gun stats
    public int damage;
    public float timeBetweenShooting, spread, range, timeBetweenShots; // reloadTime;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    public int bulletsLeft, bulletsShot;
    public string ammotype;
    public float bulletSpeed = 40;

    //bools 
    bool shooting, readyToShoot; //reloading;

    //Reference
    public Camera fpsCam;
    public GameObject bulletPrefab;
    public GameObject barrel;

    public AdjustableBar ammoMeter;
    public CamRecoil recoil;

    AudioSource fire;
    public GameObject muzzleFlash;

    private void Awake()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
        fire = GetComponent<AudioSource>();
    }

    private void Update()
    {
        MyInput();
    }
    private void MyInput()
    {
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        /*if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading)
        {
            Reload();
        }*/

        //Shoot
        if (readyToShoot && shooting && bulletsLeft > 0) //!reloading <- incorporate into if statement if reloading is a requirement
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
        bullet.transform.position = barrel.transform.position + barrel.transform.forward;
        bullet.transform.forward = barrel.transform.forward;
        bullet.GetComponent<Rigidbody>().AddForce(barrel.transform.forward * bulletSpeed, ForceMode.VelocityChange);
        //bullet.GetComponent<BulletBehavior>().speed = bulletSpeed;
        bullet.GetComponent<BulletBehavior>().bulletDamage = damage;

        //Graphics for MuzzleFlash
        Instantiate(muzzleFlash, barrel.transform.position, Quaternion.identity);

        
        bulletsShot--;
        

        Invoke("ResetShot", timeBetweenShooting);

        if (bulletsShot > 0 && bulletsLeft > 0)
            Invoke("Bang", timeBetweenShots);
    }
    private void ResetShot()
    {
        readyToShoot = true;
    }

    //Reload functions
    /*private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }
    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    } */
}