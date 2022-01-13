using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    
    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }
    
    
    //HP
    public int maxHealth = 5;
    public int currentHealth;
    
    //Movement(1)
    private Rigidbody2D rb2D;
    public float characterSpeed = 5f;
    
    //Animation
    public Animator animator;
    
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    } 
    
    //Movement(2) 
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
        
        //Animation
        animator.SetBool("IsJumping", false);
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
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