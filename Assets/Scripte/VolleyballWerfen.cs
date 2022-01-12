using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolleyballWerfen : MonoBehaviour
{

    public Transform firePosition;
    public GameObject volleyballPrefab;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(volleyballPrefab, firePosition.position, firePosition.rotation);
    }
}
