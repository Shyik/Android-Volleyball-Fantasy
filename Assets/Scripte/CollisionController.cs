using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _color = _renderer.material.color;
    }

    private Renderer _renderer;
    private Color _color;

    public int obstacleDamage = 1;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle" /*|| "Enemy"*/) == true)
        {
            Debug.Log("collided with: "+collision.name);
            GetComponent<PlayerController>().TakeDamage(obstacleDamage);
            StartCoroutine("GetInvulnerable");
        }
        if (collision.gameObject.CompareTag(/*"Obstacle" || */"Enemy") == true)
        {
            Debug.Log("collided with: "+collision.name);
            GetComponent<PlayerController>().TakeDamage(obstacleDamage);
            StartCoroutine("GetInvulnerable");
        }
        
    }
    
    
    //Invulnerability 
    IEnumerator GetInvulnerable()
    {
        GetComponent<PlayerController>().isInvulnerable = true;
        _color.a = 0.8f;
        _renderer.material.color = _color;
        yield return new WaitForSeconds(0.2f);
        _color.a = 0.6f;
        _renderer.material.color = Color.red;
        GetComponent<PlayerController>().isInvulnerable = true;
        yield return new WaitForSeconds(0.2f);
        _color.a = 0.4f;
        _renderer.material.color = _color;
        GetComponent<PlayerController>().isInvulnerable = true;
        yield return new WaitForSeconds(0.2f);
        _color.a = 0.6f;
        _renderer.material.color = Color.red;
        GetComponent<PlayerController>().isInvulnerable = true;
        yield return new WaitForSeconds(0.2f);
        _color.a = 0.8f;
        _renderer.material.color = _color;
        GetComponent<PlayerController>().isInvulnerable = true;
        yield return new WaitForSeconds(0.2f);
        
        GetComponent<PlayerController>().isInvulnerable = false;
        _color.a = 1f;
        _renderer.material.color = _color;
        
        
    }

    
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
