using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volleyball : MonoBehaviour
{
    private float ballSpeed = 20f;
    private Rigidbody2D rb2D;
    //public int damage = 1;
    //public GameObject impactEffect;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb2D.velocity = new Vector2(ballSpeed, 0);
        
        //destroys volleyball after a certain amount of time if it doesnt hit anything
        Destroy(gameObject, 10f);
    }

    void OnTriggerEnter2D(Collider2D otherCollider2D)
    {
        /* TODO: enemies + enemy hp system
        Enemy enemy = otherCollider2D.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Instantiate(impactEffect, transform.position, transform.rotation);
        */
        Destroy(gameObject);
    }
}
