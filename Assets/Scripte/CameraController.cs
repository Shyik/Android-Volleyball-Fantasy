using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public float cameraSpeed = 8f;
    [SerializeField] private PlayerController PlayerController;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //GetComponent<PlayerController>().characterSpeed = cameraSpeed;
        rb2D.velocity = new Vector2(cameraSpeed, 0);

        if (PlayerController.currentHealth <= 0)
        {
            rb2D.velocity = new Vector2(0,0);
        }
    }

}