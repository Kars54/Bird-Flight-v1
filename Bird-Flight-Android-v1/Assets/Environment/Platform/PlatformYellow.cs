using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformYellow : MonoBehaviour
{
    
    private float yellowJumpForce = 12;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                //Issue is addforce takes into consideration the velocity and the existing forces

                Vector2 velocity = rb.velocity;
                velocity.y = yellowJumpForce;
                rb.velocity = velocity;
            }
        }

    }
}
