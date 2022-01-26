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
            _rb2D = GetComponent<Rigidbody2D>();
            currentHealth = maxHealth;
            
            //Consistent Walkspeed 
            _rb2D.velocity = new Vector2(characterSpeed, _rb2D.velocity.y);
        } 
        
      private bool _isInAir;
      public float startJumpTime;   
      
    //Movement
    private Rigidbody2D _rb2D;
    public float characterSpeed = 5f;
    
    public float jumpForce;
    public bool isGrounded;
    public Transform feetPosition;
    public float checkRadius;
    public LayerMask whatIsGround;
    private float _jumpTimeCounter;
    public float jumpTime;
    private bool _isJumping;
    
    void Update()
    {
        //Jumping
        isGrounded = Physics2D.OverlapCircle(feetPosition.position,checkRadius,whatIsGround);
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            _isJumping = true;
            _isInAir = true;
            _jumpTimeCounter = jumpTime;
            startJumpTime = Time.time;
            _rb2D.velocity = new Vector2( _rb2D.velocity.x, jumpForce);
            
            FindObjectOfType<AudioManager>().Play("Jump");
        }

        if (Input.GetKey(KeyCode.Space) && _isJumping == true)
        {
            if (_jumpTimeCounter>0)
            {
                _rb2D.velocity = new Vector2( _rb2D.velocity.x, jumpForce);
                _jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                _isJumping = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _isJumping = false;
        }
        
        //Animation
        animator.SetBool("IsJumping", true);

        if (isGrounded == false)
        {
            animator.SetBool("IsJumping", false);
        }

        if (isGrounded && _isInAir == true)
        {
            if (startJumpTime - Time.time < 0.3f)
            {
                animator.SetTrigger("isLanding");
                _isInAir = false;
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
            
            FindObjectOfType<AudioManager>().Play("PlayerTakeDamage");
            gameManager.OnHitScreenflash();

            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }
    
    private void Die()
    {
        animator.SetTrigger("dying");
        
        FindObjectOfType<AudioManager>().Play("PlayerDeath");
        
        StartCoroutine(ExecuteAfterTime(0.2f));
        IEnumerator ExecuteAfterTime(float time)
        {
            yield return new WaitForSeconds(time);
            _rb2D.velocity = new Vector2( 1f, 0);
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