
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    

    private int current_weapon = 0;


    // Start is called before the first frame update
    void Start()
    {
        ChangeWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        int previousWeapon = current_weapon;
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            current_weapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            current_weapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            current_weapon = 2;
        }
        if ( previousWeapon != current_weapon)
        {
            ChangeWeapon();
        }
    }

    void ChangeWeapon()
    {
        int weapon_number = 0;

        foreach (Transform weapon in transform)
        {
            if (weapon_number == current_weapon)
            {
                weapon.gameObject.SetActive(true);
            }

            else
            {
                weapon.gameObject.SetActive(false);
            }

            weapon_number++;
        }
    }
}
