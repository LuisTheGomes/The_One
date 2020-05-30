using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    //Retirado do canal de youtube Brackeys
    public float Speed = 10;

    public int damage = 20;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * Speed;
    }

    void OnTriggerEnter2D (Collider2D bulletInfo)
    {
        Enemy enemy_hit = bulletInfo.GetComponent<Enemy>();
        

        if ( enemy_hit != null)
        {
            enemy_hit.Damage(damage);
        }
        Destroy(gameObject);
    }

}
