using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPink : MonoBehaviour
{
    private float pinkJumpForce = 8;
    private float _levelWidth = 2.0f;
    float pinkSpeed = 3f;
    Rigidbody2D rb;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                //Issue is addforce takes into consideration the velocity and the existing forces

                Vector2 velocity = rb.velocity;
                velocity.y = pinkJumpForce;
                rb.velocity = velocity;
            }
        }

       

    }

    private void Start()
    {
        pinkSpeed = Random.Range(1f, 3f);

        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (transform.position.x > _levelWidth - .1f)
            pinkSpeed *= -1f;
        else if (transform.position.x < -_levelWidth + .1f)
            pinkSpeed *= -1f;

        Vector2 velocity = rb.velocity;
        velocity.x = pinkSpeed;
        rb.velocity = velocity;

        
    }

}
