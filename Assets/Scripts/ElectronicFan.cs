using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectronicFan : MonoBehaviour
{
    private Rigidbody2D rb2D;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity = new Vector2(0f, -1.25f);
    }
}