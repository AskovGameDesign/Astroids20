using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float speed = 5f;
    public float torqueForce = 2f;


    private float forceInput;
    private float torqueInput;
   
    void Start()
    {
        
    }

    void Update()
    {
        forceInput = Input.GetAxis("Vertical");
        torqueInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        rb2d.AddForce(transform.up * forceInput * speed);
        rb2d.AddTorque(-torqueInput * torqueForce);
    }
}
