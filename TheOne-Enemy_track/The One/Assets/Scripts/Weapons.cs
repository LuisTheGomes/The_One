using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{

    public Transform ShootingPoint;
    public GameObject BulletPrefab;

    private float timer = 0f;

    public float Cooldown = 0f;

    private int number_of_shots = 0;

    public bool isShotgun = true;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if ( timer > Cooldown )
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (isShotgun == false)
                {
                    Fire();

                    timer = 0f;
                }

                else
                {
                    Fire();
                    
                    number_of_shots += 1;

                    if (number_of_shots == 2)
                    {
                        timer = 0;

                        number_of_shots = 0;
                        
                    }
                    
                }
            }
        }
    }

    void Fire()
    {
        Instantiate(BulletPrefab, ShootingPoint.position, ShootingPoint.rotation);
    }
}
