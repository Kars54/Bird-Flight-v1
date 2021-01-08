﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlatform : Platform
{
    float currentTime;
    bool collided = false;

    
    private float jumpForce = 8;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                //Issue is addforce takes into consideration the velocity and the existing forces

                Vector2 velocity = rb.velocity;
                velocity.y = jumpForce;
                rb.velocity = velocity;
                collided = true;
                currentTime = Time.time;
            }
        }



    }

    private void Update()
    {
        if(currentTime + 0.2f < Time.time && collided == true)
        {
            Destroy(this.gameObject);
        }
    }
}
