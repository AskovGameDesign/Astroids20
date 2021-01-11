using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroid : MonoBehaviour
{
    public GameObject explosionPrefab;
    public int points = 10;
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
        rb2d.AddTorque(Random.Range(20f, 80f));
        Destroy(gameObject, 6f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet"))
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager)
                gameManager.SetScoreText(points);

            if(explosionPrefab)
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }


    private void FixedUpdate()
    {
        rb2d.AddForce(-direction.normalized * speed);
    }

    
}
