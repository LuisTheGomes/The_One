using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementForce; // movimento 
    public float maxHorizontalMovementSpeed; // movimento 
    public float groundFrictionLevel; 
    public float jumpForce; // para o salto
    public float dashTime; // para o dash
    public float dashSpeed; // para o dash
    public float distaceBetweenImages; // para o dash 
    public float dashCoolDown; // para o dash

    public int extraJumps; // saltos extras 

    public Transform groundCheck; // Para o groundCheck
    public float groundCheckRadius; // Para o groundCheck
    public LayerMask whatIsGround;


    private bool isFacingRight = true; // Verifica se esta virado para a direita
    private bool canJump = true; // Verifica se pode saltar
    private bool isGrounded; // Verifica se está a tocar no chão

    private float movementDirection;
    private Vector2 velocity;
    private Rigidbody2D rb;
    private Animator anim;
    private int extraJumpLeft;
    private bool isDashing; // Para o dash
    private float dashTimeLeft; // para o dash(dash cooldown)
    private float lastImageXpos; // para o dash
    private float lastDash = -100f; // para o dash (Cooldown)
    [SerializeField]
    private float dashForce;
    private Vector2 direction;

    private float Timer = 0f;
    






    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        extraJumpLeft = extraJumps;
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        // Verifica o Input do jogador
        movementDirection = Input.GetAxisRaw("Horizontal");

        if(isGrounded && rb.velocity.y <= 0) // Verifica o numero de saltos :1
        {
            canJump = true;
            extraJumpLeft = extraJumps;
        }

        // Verifica a direção
        if(!isFacingRight && movementDirection < 0)
        {
            Flip();
        }
        else if(isFacingRight && movementDirection > 0)
        {
            Flip();
        }

        // Verifica se o jogador salta
         if (Input.GetKeyDown(KeyCode.W) && !isDashing)
         {
             Jump();
         }
         /*
         Timer += Time.deltaTime;
         if( Timer > dashCoolDown )
         {
             Dash();
             Timer = 0f;
         } 
         */
        Dash();

        // Animações 

        anim.SetFloat("AbsVelX", Mathf.Abs(rb.velocity.x));
        anim.SetBool("Onground", isGrounded);
        anim.SetFloat("VelY", rb.velocity.y);


    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius,whatIsGround );

        if (isDashing) return; // 

        // Aplica forças para mover o boneco
        Vector2 forceToAdd = new Vector2(movementForce * movementDirection, 0);
        rb.AddForce(forceToAdd, ForceMode2D.Impulse);


        //Clamp x Velocity
        if (rb.velocity.x > maxHorizontalMovementSpeed)
        {
            rb.velocity = new Vector2(maxHorizontalMovementSpeed, rb.velocity.y);
                 
        }
        else if(rb.velocity.x < -maxHorizontalMovementSpeed)
        {
            rb.velocity = new Vector2(-maxHorizontalMovementSpeed, rb.velocity.y);
        }

        // Apply false friction
        if(movementDirection == 0)
        {
            velocity = rb.velocity;
            velocity.x *= groundFrictionLevel;
            rb.velocity = velocity;
        }

    }

    void Jump() // Salto 
    {
        if (canJump || extraJumpLeft >= 0)
        {
            velocity = rb.velocity;
            Vector2 jumpForceAdd = new Vector2(0, jumpForce);
            rb.AddForce(jumpForceAdd, ForceMode2D.Impulse);
            canJump = false;
            extraJumpLeft--;
        }
    }

    void Flip() // Virar o persogem 
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0.0f, 180.0f, 0);
    }

    private void Dash()
    {
        if (Input.GetButtonDown("Dash"))
        {
            isDashing = true;
            if (isFacingRight)
            {
                direction = new Vector2(-1, 0);
            }
            else
            {
                direction = new Vector2(1, 0);
            }
            rb.AddForce(direction.normalized * dashForce, ForceMode2D.Impulse);

            Invoke("CancelDash", 0.5f); // Chama o metodo CancelDash
        }

    }

    private void CancelDash()
    {
        isDashing = false;
    }

    

}
