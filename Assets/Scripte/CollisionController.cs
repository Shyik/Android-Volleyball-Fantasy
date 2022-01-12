using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    public int obstacleDamage = 1;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") == true)
        {
            Debug.Log("collided with: "+collision.name);
            GetComponent<PlayerController>().TakeDamage(obstacleDamage);
        }
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
