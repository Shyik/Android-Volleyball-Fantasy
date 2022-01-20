using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfLevelTrigger : MonoBehaviour
{
    public GameManager gameManager;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")== true)
        {
            gameManager.CompleteLevel();
            
            StartCoroutine(ExecuteAfterTime(6f));
            IEnumerator ExecuteAfterTime(float time)
            {
                yield return new WaitForSeconds(time);
                Time.timeScale = 0;
            }
            
        }
    }
}
