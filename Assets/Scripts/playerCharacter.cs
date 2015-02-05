using UnityEngine;
using System.Collections;

public class playerCharacter : MonoBehaviour 
{
	//control vars
	private float horAxis;
	private float verAxis;
	private bool firePrimary;

	//move vars
	public float moveAccel;
	public float resetVelocity;
	public float resetVelocityMultiplier;

	//weapon control vars
	private bool primaryReady;
	public GameObject primaryWeapon;

	//aiming control vars
	public float zOffset;
	private Vector3 mousePosAdj;

	void Awake()
	{
		primaryReady = true;
	}
	void Update()
	{
		inputListener();
		aimEngine();
		weaponsEngine();
	}

	void FixedUpdate()
	{
		moveEngine();
	}

	void aimEngine()
	{	
 		transform.LookAt(Camera.main.ScreenToWorldPoint(mousePosAdj));
	}

	void weaponsEngine()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		Debug.DrawRay(ray.origin, ray.direction);
		if (firePrimary && primaryReady)
		{
			GameObject projectile;
			projectile = Instantiate(primaryWeapon, transform.position, Quaternion.identity) as GameObject;
			if(Physics.Raycast(ray, out hit, Mathf.Infinity))
			{
				projectile.transform.LookAt(hit.point);
			}
			else
			{
				projectile.transform.rotation = transform.rotation;
				primaryReady = false;
			}
		}

		if(!firePrimary)
		{
			primaryReady = true;
		}
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
		mousePosAdj = Input.mousePosition;
		mousePosAdj.z = zOffset;
		firePrimary = Input.GetButtonDown("Fire1");
	}
}
