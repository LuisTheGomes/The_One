using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    public float Speed = 4.0f;
    public float jump_force = 3.0f;
    

    

    Animator animator;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0f , 0f); // Movimento 
        Vector3 flip = transform.localScale; // rotação


        transform.position += move * Time.deltaTime * Speed;

        // Rotação do persongem
        if ( Input.GetAxis("Horizontal") < 0 )
        {
            flip.x = 1; 
        }

         if ( Input.GetAxis("Horizontal") > 0 )
        {
            flip.x = -1; 
        }

        transform.localScale = flip;

        Jump(); // Salto


        // Animação 
        animator.SetFloat("AbsVelX", Mathf.Abs(move.x)); // animação do movimento
        animator.SetFloat("VelY", move.y); // Animaçao do salto 

    }

    void Jump() // Salto
    {
        
         if (Input.GetKeyDown(KeyCode.W))
         {
             gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jump_force), ForceMode2D.Impulse);
         }

        
    }
}
