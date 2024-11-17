using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] float minSpeed, maxSpeed, chaseSpeed = 1f;
    private Rigidbody2D rb;
    private Transform target;
    Vector2 moveDirection;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        float speed = Random.Range(minSpeed, maxSpeed);
        rb.velocity = new Vector2(rb.velocity.x, -speed);
    }

    private void Update()
    {
        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            moveDirection = direction;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (target)
        {
            rb.velocity = new Vector2(moveDirection.x * chaseSpeed, rb.velocity.y);
        }
        
    }
}
