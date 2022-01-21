using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    /*
    [Header("Events")]
    [Space]


    public UnityEvent OnLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }
    */
    
    //HP
    public int maxHealth = 3;
    public int currentHealth;
    public bool isInvulnerable = false;

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    //Animation
        public Animator animator;
        
        void Start()
        {
            Time.timeScale = 1;
            rb2D = GetComponent<Rigidbody2D>();
            currentHealth = maxHealth;
            
            //Consistent Walkspeed 
            rb2D.velocity = new Vector2(characterSpeed, rb2D.velocity.y);
        } 
        
      private bool isInAir;
      public float startJump_Time;   
      
    //Movement
    private Rigidbody2D rb2D;
    public float characterSpeed = 5f;
    
    public float jumpForce;
    public bool isGrounded;
    public Transform feetPosition;
    public float checkRadius;
    public LayerMask whatIsGround;
    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;
    
    void Update()
    {
        //Jumping
        isGrounded = Physics2D.OverlapCircle(feetPosition.position,checkRadius,whatIsGround);
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            isInAir = true;
            jumpTimeCounter = jumpTime;
            startJump_Time = Time.time;
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
        animator.SetBool("IsJumping", true);

        if (isGrounded == false)
        {
            animator.SetBool("IsJumping", false);
        }

        if (isGrounded && isInAir == true)
        {
            if (startJump_Time - Time.time < 0.3f)
            {
                animator.SetTrigger("isLanding");
                isInAir = false;
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetTrigger("throwing");
        }
    }

    /*
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(feetPosition.position,checkRadius);
    }
    */


    /*public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }*/
    
    
    //Taking Damage

    public GameManager gameManager;     
    public void TakeDamage(int damage)
    {
        if (isInvulnerable == true)
        {
            return;
        }
        if (isInvulnerable == false)
        {
            currentHealth -= damage;
            gameManager.OnHitScreenflash();
            Debug.Log("current hp: " + currentHealth);

            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }
    
    public void Die()
    {
        
        
        Debug.Log("YOU DIED");
        animator.SetTrigger("dying");
        
        StartCoroutine(ExecuteAfterTime(0.2f));
        IEnumerator ExecuteAfterTime(float time)
        {
            yield return new WaitForSeconds(time);
            rb2D.velocity = new Vector2( 1f, 0);
        }

        StartCoroutine(ExecuteAfterTime2(2f));
        IEnumerator ExecuteAfterTime2(float time)
        {
            yield return new WaitForSeconds(time);
            Time.timeScale = 0;
        }


        FindObjectOfType<GameManager>().GameOver(); 

    }
}