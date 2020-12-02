using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroid : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Vector3 direction;
    private float speed;
    public float speedMax = 4f, speedMin = 2f;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        direction = transform.position - GameObject.FindGameObjectWithTag("Player").transform.position;
        speed = Random.Range(speedMin, speedMax);
    }

    private void FixedUpdate()
    {
        rb2d.AddForce(-direction.normalized * speed);
    }
}
