using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{

	public float movementSpeed = 100f;
	Rigidbody2D rb;
	private float ScreenWidth;
	float movement = 0f;

	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		rb.freezeRotation = true;
		ScreenWidth = Screen.width;
	}

	// Update is called once per frame
	void Update()
	{
	
		//loop over every touch found    
		
		if (Input.touchCount > 0)
		{

			Touch touch = Input.GetTouch(0);


			if (touch.position.x < Screen.width / 2)
			{
				movement = -1;
			}

			if (touch.position.x > Screen.width / 2)
			{
				movement = 1f;
			}
			if (touch.phase == TouchPhase.Ended)
				movement = 0f;

			/* CODE FROM GITHUB --> This code works but the issue is there is it increases the time between the beginning of the input and the player action on the screen 
			switch (touch.phase)
            {
				case TouchPhase.Stationary:

					if (touch.position.x < Screen.width / 2)
					{
						movement = -1;
					}

					if (touch.position.x > Screen.width / 2)
                    {
						movement = 1f;
                    }
						break;
				case TouchPhase.Ended:
					movement = 0f;
					break;
			} */

		}
	}

	void FixedUpdate()
	{
		Vector2 velocity = rb.velocity;
		velocity.x = movement*movementSpeed*Time.deltaTime;
		rb.velocity = velocity;
	}
}
