using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMoving : MonoBehaviour
{
    public GameObject background;
    [SerializeField] private float speed;

    private void Update()
    {
        if (Time.timeScale == 1)
        {
            background.transform.position = new Vector3(background.transform.position.x, background.transform.position.y - speed * Time.deltaTime * Screen.width, background.transform.position.z);
        }
        
    }
}
