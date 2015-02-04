using UnityEngine;
using System.Collections;

public class playerCharacter : MonoBehaviour 
{
	//control vars
	private float horAxis;
	private float verAxis;

	public float moveAccel;
	public float resetVelocity;
	public float resetVelocityMultiplier;

	public float zOffset;
	void Update()
	{
		inputListener();
		aimEngine();
	}
	void FixedUpdate()
	{
		moveEngine();
	}
	void aimEngine()
	{	
		Vector3 temp = Input.mousePosition;
		temp.z = zOffset;
 		transform.LookAt(Camera.main.ScreenToWorldPoint(temp));
	}
	void moveEngine()
	{
		Vector3 targetDir;
		targetDir = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2, Screen.height/2, 0)) - transform.position;
		rigidbody.AddForce(new Vector3(targetDir.x, targetDir.y, 0) * resetVelocity * (resetVelocityMultiplier * Vector3.Distance(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2, Screen.height/2, 0)), transform.position)));
		//transform.Translate(new Vector3(horAxis * moveAccel * Time.deltaTime, verAxis * moveAccel * Time.deltaTime, 0));
		if(Camera.main.WorldToScreenPoint(transform.position).x <= Screen.width && Camera.main.WorldToScreenPoint(transform.position).x >= 0)
		{
			rigidbody.AddForce(new Vector3(horAxis * moveAccel, 0, 0));
		}
		if(Camera.main.WorldToScreenPoint(transform.position).y <= Screen.height && Camera.main.WorldToScreenPoint(transform.position).y >= 0)
		{
			rigidbody.AddForce(new Vector3(0, verAxis * moveAccel, 0));
		}
	}

	void inputListener()
	{
		horAxis = Input.GetAxisRaw("Horizontal");
		verAxis = Input.GetAxisRaw("Vertical");
	}
}
