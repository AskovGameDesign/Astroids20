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
    private Vector2 HorizontalAndVerticalBorder;
   
    void Start()
    {
        HorizontalAndVerticalBorder = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
    }

    void Update()
    {
        forceInput = Input.GetAxis("Vertical");
        torqueInput = Input.GetAxis("Horizontal");

        if(rb2d.position.x > HorizontalAndVerticalBorder.x)
        {
            rb2d.position = new Vector2(-HorizontalAndVerticalBorder.x, rb2d.position.y);
        }
        else if(rb2d.position.x < -HorizontalAndVerticalBorder.x)
        {
            rb2d.position = new Vector2(HorizontalAndVerticalBorder.x, rb2d.position.y);
        }
        else if(rb2d.position.y > HorizontalAndVerticalBorder.y)
        {
            rb2d.position = new Vector2(rb2d.position.x, -HorizontalAndVerticalBorder.y);
        }
        else if(rb2d.position.y < -HorizontalAndVerticalBorder.y)
        {
            rb2d.position = new Vector2(rb2d.position.x, HorizontalAndVerticalBorder.y);
        }

    }

    private void FixedUpdate()
    {
        rb2d.AddForce(transform.up * forceInput * speed);
        rb2d.AddTorque(-torqueInput * torqueForce);
    }
}
