using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float horizontalInput, verticalInput;
    private float dashPower = 2000f, dashTime = 0.25f, dashCooldown = 1f;
    private bool canDash = true;
    private Vector2 newVelocity, currentSpeed;
    private Rigidbody2D rb;
    private TrailRenderer tr;

    [SerializeField] private int speed, health, dashCharges;

    void Start()
    {
        newVelocity = new Vector2(0f, 0f);
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<TrailRenderer>();
    }

    void Update()
    {
        //movement
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        newVelocity.x = horizontalInput;
        newVelocity.y = verticalInput;

        rb.velocity = newVelocity * speed;

        currentSpeed = rb.velocity;

        //dash input
        bool dash = Input.GetButtonDown("Fire3");
        if (dash && canDash && dashCharges > 0)
        {
            StartCoroutine(Dash());
        }
    }

    //causes the player to dash and gives it a cooldown
    private IEnumerator Dash()
    {
        canDash = false;
        tr.emitting = true;
        dashCharges--;
        rb.AddForce(currentSpeed.normalized * dashPower);
        yield return new WaitForSeconds(dashTime);
        tr.emitting = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}
