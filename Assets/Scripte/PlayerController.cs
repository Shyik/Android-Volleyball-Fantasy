using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //HP Variablen

    public int maxHealth = 5;
    private int currentHealth;
    
    //Movement Variablen
    private Rigidbody2D rb2D;
    public float characterSpeed = 5f;
    
    
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    } 
    
    //Movement Variablen
    public float jumpForce;
    private bool isGrounded;
    public Transform feetPosition;
    public float checkRadius;
    public LayerMask whatIsGround;
    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;

    void Update()
    {
        //Consistent Walkspeed 
        rb2D.velocity = new Vector2(characterSpeed, rb2D.velocity.y);
        
        //Jumping
        isGrounded = Physics2D.OverlapCircle(feetPosition.position,checkRadius,whatIsGround);
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb2D.velocity = new Vector2( rb2D.velocity.x, jumpForce);
        }

        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (jumpTimeCounter>0)
            {
                rb2D.velocity = new Vector2( rb2D.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }
    
    //Taking Damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("current hp: "+currentHealth);
        //play taking damage animation

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("YOU DIED");
        //play death animation
        
        Destroy(gameObject);
        
        //TODO: restart game/ gameover screen 
        
    }
}