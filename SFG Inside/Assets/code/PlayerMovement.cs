/*
 * PlayerMovement
 * 
 * Fetches the character movement input and applies it to the character controller.
 * Requires a CharacterController
 */

using UnityEngine;

[RequireComponent (typeof (CharacterController))]
public class PlayerMovement : MonoBehaviour 
{
	// public accecible properties
	public float speed  = 10.0f;
	public float rotateSpeed = 70f;
	public float jumpSpeed = 8.0f;
	public float gravity = 20.0f;
	
	private Vector3 _moveDirection = Vector3.zero;
	private CharacterController _controller;

	//unity awake
	public void Awake()
	{
		//fetch character controller
		_controller = GetComponent<CharacterController>();
	}

	//unity update
	public void Update() 
	{
		//check if character in not in the air
		if (_controller.isGrounded) 
		{	
			//check for rotation input
			if(Input.GetKey(KeyCode.D))
			{
				//execute rotation right
				transform.Rotate(0,rotateSpeed* Time.deltaTime,0);
			}
			if(Input.GetKey(KeyCode.A))
			{
				//execute rotation left
				transform.Rotate(0,-rotateSpeed* Time.deltaTime,0);
			}
			
			//we are grounded, so recalculate move direction directly from axes
			_moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
			_moveDirection = transform.TransformDirection(_moveDirection);
			_moveDirection *= speed;

			//check for jump button
			if (Input.GetButton ("Jump")) 
			{
				//apply jump
				_moveDirection.y = jumpSpeed;
			}
		}
		
		// apply gravity
		_moveDirection.y -= gravity * Time.deltaTime;
		
		// execute movement
		_controller.Move(_moveDirection * Time.deltaTime);
	}
}
