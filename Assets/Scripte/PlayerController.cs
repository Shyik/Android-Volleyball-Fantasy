using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public float characterSpeed = 5f;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    } 
    
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
            rb2D.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (jumpTimeCounter>0)
            {
                rb2D.velocity = Vector2.up * jumpForce;
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
    

    
    

}
