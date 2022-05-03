using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSwitching : MonoBehaviour
{
    //Local Variables
    public int selectedWeapon = 0;
    //public int previousSelectedWeapon; Weapons history didn't make sense in a particular order, so I removed these variables
    //public int secondLastSelected;

    Shoot pistolAmmo;
    Shoot2 otherAmmo;
    public List<Sprite> gunSprites = new List<Sprite>();

    int maxAmmo;

    //References (to set the slider correctly to its values);
    public GameObject pistol, rifle, shotty;

    public AdjustableBar slider;

    public Image holster1, holster2, holster3;
    public Text infinite;
    public Image highlight;

    void Start()
    {
        SelectWeapon();
        pistolAmmo = pistol.GetComponent<Shoot>();
        maxAmmo = pistolAmmo.magazineSize;
        holster1.sprite = gunSprites[0];
        holster2.sprite = gunSprites[1];
        holster3.sprite = gunSprites[2];
    }

    // Update is called once per frame
    void Update()
    {
        int previousSelectedWeapon = selectedWeapon;

        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            selectedWeapon = 0;
            pistolAmmo = pistol.GetComponent<Shoot>();
            maxAmmo = pistolAmmo.magazineSize;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedWeapon = 1;
            otherAmmo = rifle.GetComponent<Shoot2>();
            maxAmmo = otherAmmo.magazineSize;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedWeapon = 2;
            otherAmmo = shotty.GetComponent<Shoot2>();
            maxAmmo = otherAmmo.magazineSize;
        }
        IsInfinite(selectedWeapon);
        Adjust(maxAmmo);
        
        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
            Highlight(selectedWeapon);
        }
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);              
            else
                weapon.gameObject.SetActive(false);
            i++;
        } 
    }

    void Highlight(int selectedWeapon)
    {
        if (selectedWeapon == 0)
        {
            highlight.rectTransform.anchoredPosition = holster1.rectTransform.anchoredPosition;
        }
        if (selectedWeapon == 1)
        {
            highlight.rectTransform.anchoredPosition = holster2.rectTransform.anchoredPosition;
        }
        if (selectedWeapon == 2)
        {
            highlight.rectTransform.anchoredPosition = holster3.rectTransform.anchoredPosition;
        }
    }

    void Adjust(int max)
    {
        slider.SetMax(max);  
    }
    
    void IsInfinite(int weapon)
    {
        if (weapon == 0)
        {
            infinite.gameObject.SetActive(true);
        }
        else
            infinite.gameObject.SetActive(false);
    }
}
