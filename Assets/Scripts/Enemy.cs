using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Collider2D enemyCollider;
    // Start is called before the first frame update
    void Start()
    {
        enemyCollider = GetComponent<Collider2D>();
        enemyCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("TriggerTop"))
        {
            enemyCollider.isTrigger = false;
        }

    }
}
