using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    Transform player;
    [SerializeField]
    float agroRange; // Alcance do inimigo que ativa o agromode

    [SerializeField]
    float moveSpeed = 2f; // Velocidade do inimigo

    Rigidbody2D rb;
    Animation anime;


    // variaveis

    private float Timer = 0f;

    public float BulletTimeCooldown = 3f;

    public int BluePill = 3;

    float distToPlayer;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animation>();
    }

    
    void Update()
    {
        // distacia do jogador 
        distToPlayer = Vector2.Distance(transform.position, player.position);
        

        if(distToPlayer < agroRange)
        {
            ChasePlayer();
        }
        else
        {
            StopChasingPlayer();
        }

        // BulletTime

        Timer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (Timer <= BulletTimeCooldown && BluePill != 0 )
            {
                moveSpeed = 0.2f;
                BluePill--;
            }
            else
            {
                moveSpeed = 2f;
                Timer = 0f;
            }
        }
        
        print(Timer);
    }

    private void ChasePlayer()
    {
        if(transform.position.x < player.position.x)
        {
            // inimigo lado esquerdo do jogador
            rb.velocity = new Vector2(moveSpeed, 0);
            transform.localScale = new Vector2(1, 1);
        }
        else if (transform.position.x > player.position.x)
        {
            // inimigo lado direito do jogador ?
            rb.velocity = new Vector2(-moveSpeed, 0);
            transform.localScale = new Vector2(-1,1);
            
        }
    }

    private void StopChasingPlayer()
    {
        rb.velocity = new Vector2(0,0);
    }

    private void Animation() // Animações
    {

    }



    
}
