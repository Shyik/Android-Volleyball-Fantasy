using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolleyballWerfen : MonoBehaviour
{

    public Transform firePosition;
    public GameObject volleyballPrefab;

    public float throwRate = 2.5f;
    private float nextThrowTime = 0f;   
    
    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextThrowTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Shoot();
                nextThrowTime = Time.time + 1f / throwRate;
            }
        }
    }

    void Shoot()
    {
        Instantiate(volleyballPrefab, firePosition.position, firePosition.rotation);
    }
}
