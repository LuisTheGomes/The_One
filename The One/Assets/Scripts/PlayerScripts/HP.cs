using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    public int hp = 100;
    public int Damage = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            hp--;
            if( hp <= 0)
            {
                Destroy(gameObject);
            }
            
        }
    }
}
