using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfLevelTrigger : MonoBehaviour
{
    public float timeTillPause = 12f;
    public GameManager gameManager;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")== true)
        {
            gameManager.CompleteLevel();


            StartCoroutine(Slowmotion(timeTillPause));
            /*StartCoroutine(ExecuteAfterTime(6f));
            IEnumerator ExecuteAfterTime(float time)
            {
                yield return new WaitForSeconds(time);
            }*/

        }
        
    }

    
    IEnumerator Slowmotion(float timeTillPause)
    {
        float currentTime = timeTillPause;
        while (currentTime > 0)
        {
            currentTime -= Time.unscaledDeltaTime;
            Time.timeScale = Mathf.InverseLerp(0, timeTillPause, currentTime);
            yield return null;
        }

        Time.timeScale = 0;
        yield break; 
    }
}
