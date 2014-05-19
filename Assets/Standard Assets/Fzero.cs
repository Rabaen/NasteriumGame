using UnityEngine;
using System.Collections;

public class Fzero : MonoBehaviour
{
	/*Ship handling parameters*/
	public float fwd_accel = 100f;
	public static float fwd_max_speed = 600f;
	public float startMaxSpeed = 600.0f;
	public float brake_speed = 200f;
	public float turn_speed = 50f;
	public float timer = 10;
	public static bool timerOn = false;
	
	/*Auto adjust to track surface parameters*/
	public float hover_height = 3f;     //Distance to keep from the ground
	public float height_smooth = 10f;   //How fast the ship will readjust to "hover_height"
	public float pitch_smooth = 5f;     //How fast the ship will adjust its rotation to match track normal
	
	/*We will use all this stuff later*/
	private Vector3 prev_up;
	public float yaw;
	private float smooth_y;
	public static float current_speed;
	private float localEulerAngles;
	//public static float mph = rigidbody.velocity.magnitude * 2.237
	public CountdownTime CountGo;
	
	void Update ()
	{
		//mphNeedle.angle = mph;
		/*Here we get user input to calculate the speed the ship will get*/
		if (CountGo.StartBool == true) 
		{
				if (Input.GetKey (KeyCode.W)) 
			{
								/*Increase our current speed only if it is not greater than fwd_max_speed*/
				current_speed += (current_speed >= fwd_max_speed) ? 0f : fwd_accel * Time.deltaTime;
			} else 
			{
				if (current_speed > 0) 
			{
										/*The ship will slow down by itself if we dont accelerate*/
				current_speed -= brake_speed * Time.deltaTime;
			} 
			else 
			{
					current_speed = 0f;
			}
			}
		}
		/*We get the user input and modifiy the direction the ship will face towards*/
		yaw += turn_speed * Time.deltaTime * Input.GetAxis ("Horizontal");
		/*We want to save our current transform.up vector so we can smoothly change it later*/
		prev_up = transform.up;
		/*Now we set all angles to zero except for the Y which corresponds to the Yaw*/
		transform.rotation = Quaternion.Euler(0, yaw, 0);
		
		RaycastHit hit;
		if (Physics.Raycast(transform.position, -prev_up, out hit))
		{   
			Debug.DrawLine (transform.position, hit.point);
			
			/*Here are the meat and potatoes: first we calculate the new up vector for the ship using lerp so that it is smoothed*/
			//Vector3 desired_up = Vector3.Lerp (prev_up, hit.normal, Time.deltaTime * pitch_smooth);
			/*Then we get the angle that we have to rotate in quaternion format*/
			//Quaternion tilt = Quaternion.FromToRotation(transform.up, desired_up);
			/*Now we apply it to the ship with the quaternion product property*/
			//transform.rotation = tilt * transform.rotation;
			
			/*Smoothly adjust our height*/
			smooth_y = Mathf.Lerp (smooth_y, hover_height - hit.distance, Time.deltaTime * height_smooth);
			transform.localPosition += prev_up * smooth_y;
		}
		
		/*Finally we move the ship forward according to the speed we calculated before*/
		transform.position += transform.forward * (current_speed * Time.deltaTime);
		Debug.Log(current_speed);
		if (timerOn)
			timer -= Time.deltaTime;
		{
			if (timer < 0.8 && current_speed > startMaxSpeed)
			{
				fwd_max_speed = startMaxSpeed;
				current_speed = startMaxSpeed;
				timer = 10;
				timerOn = false;
			}
			else if(timer < 0.8 && current_speed < startMaxSpeed)
			{
				fwd_max_speed = startMaxSpeed;
				timer = 10;
				timerOn = false;
			}
		}
	}
 	/*void LateUpDate ()
	{

		
		 
		float leftRight= Input.GetAxis("Horizontal") * Time.deltaTime * (turn_speed - 10);  

		transform.localEulerAngles = new Vector3(10f,transform.localEulerAngles.y,transform.localEulerAngles.z);

	 
		//making it turn left or right  
		if(transform.localEulerAngles.y < 65 )
		{  
			transform.Rotate(0, -leftRight, 0);  
		} else if (transform.localEulerAngles.y > 295)
		{  
			transform.Rotate(0, -leftRight, 0);                 
		}  
		//making it not exceed rotation limit (left and right) and preventing it lock up  
		//if(transform.localEulerAngles.y >= 65 && transform.localEulerAngles.y < 295)
		if(transform.localEulerAngles = new Vector3(10f,0,0));//transform.localEulerAngles.y,transform.localEulerAngles.z));
		{  
			if(transform.localEulerAngles.y < 180)
			{  
				transform.localEulerAngles.y = 64.9f;  
			} else{  
				transform.localEulerAngles.y = 295.1f;  
			}  
		}  
 
		//making sure it doesn't turn on it's z axis  
		if(transform.localEulerAngles.z != 0)
		{  
			transform.localEulerAngles.z = 0;  
		}  
		
	}
*/
}