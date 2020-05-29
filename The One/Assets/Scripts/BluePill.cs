using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePill : MonoBehaviour
{

    public Rigidbody2D rb;
    private bool catchBluePill = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.tag == "BluePill" )
         {
            Destroy(gameObject);
         }
    }
}
