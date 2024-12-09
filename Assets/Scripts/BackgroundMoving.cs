using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMoving : MonoBehaviour
{
    public GameObject background;
    [SerializeField] private float speed;

    private void FixedUpdate()
    {
        if (Time.timeScale == 1)
        {
            background.transform.position = new Vector3(background.transform.position.x, background.transform.position.y - speed, background.transform.position.z);
        }
        
    }
}
