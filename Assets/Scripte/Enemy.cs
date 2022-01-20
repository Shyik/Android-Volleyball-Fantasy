using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy : MonoBehaviour
{
    public Animator animator;
    public Collider2D enemyCollider2D;
    public int health = 1;
    
    //public GameObejct deathEffect;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        if (health <= 0)
        {
            animator.SetTrigger("dying");
            enemyCollider2D.enabled = false;
            
            StartCoroutine(ExecuteAfterTime(0.5f));
            IEnumerator ExecuteAfterTime(float time)
            {
                yield return new WaitForSeconds(time);
                Destroy(gameObject);
            }
        }
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
    }
}