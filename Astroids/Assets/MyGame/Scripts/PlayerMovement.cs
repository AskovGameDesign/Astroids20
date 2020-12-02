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
    private float left, top;

   
    void Start()
    {
        left = Camera.main.ScreenToWorldPoint(Vector3.zero).x;
        top = Camera.main.ScreenToWorldPoint(Vector3.zero).y;
    }

    void Update()
    {
        forceInput = Input.GetAxis("Vertical");
        torqueInput = Input.GetAxis("Horizontal");

        if(rb2d.position.x < left )
        {
            rb2d.position = new Vector2(-left, rb2d.position.y);
        }
        else if(rb2d.position.x > -left)
        {
            rb2d.position = new Vector2(left, rb2d.position.y);
        } 
        else if(rb2d.position.y < top )
        {
            rb2d.position = new Vector2(rb2d.position.x, -top);
        }
        else if(rb2d.position.y > -top)
        {
            rb2d.position = new Vector2(rb2d.position.x, top);
        }


    }

    private void FixedUpdate()
    {
        rb2d.AddForce(transform.up * forceInput * speed);
        rb2d.AddTorque(-torqueInput * torqueForce);
    }
}
