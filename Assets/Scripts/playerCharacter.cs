using UnityEngine;
using System.Collections;

public class playerCharacter : MonoBehaviour 
{
	//control vars
	private float horAxis;
	private float verAxis;
	private bool firePrimary;
	private bool positionLeft;
	private bool positionRight;

	//move vars
	public float forwardAccel;
	public float moveAccel;
	public float resetVelocity;
	public float resetVelocityMultiplier;
	public float anchorPosOffset;
	public Vector3[] positioningArray;
	public int currentPosition;

	private bool setPositionLeft;
	private bool setPositionRight;


	//weapon control vars
	private bool primaryReady;
	public GameObject primaryWeapon;

	//aiming control vars
	public float zAimOffset;
	private Vector3 mousePosAdj;

	void Awake()
	{
		//initialization
		primaryReady = true;
		setPositionLeft = true;
		setPositionRight = true;

		positionControl(0);
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
		//player movement
		//rigidbody.velocity = forwardVelocity(currentPosition);
		
		if(Camera.main.WorldToScreenPoint(transform.position).x <= Screen.width && Camera.main.WorldToScreenPoint(transform.position).x >= 0)
		{
			rigidbody.AddForce(horAxis * Camera.main.transform.right * moveAccel);
		}
		if(Camera.main.WorldToScreenPoint(transform.position).y <= Screen.height && Camera.main.WorldToScreenPoint(transform.position).y >= 0)
		{
			rigidbody.AddForce(new Vector3(0, verAxis * moveAccel, 0));
		}

		if(positionLeft && setPositionLeft)
		{
			positionControl(-1);
			setPositionLeft = false;
		}
		if(positionRight && setPositionRight)
		{
			positionControl(1);
			setPositionRight = false;
		}
		if(!positionLeft)
		{
			setPositionLeft = true;
		}
		if(!positionRight)
		{
			setPositionRight = true;
		}
	}

	void positionControl(int moveVal)
	{
		Debug.Log("position");
		currentPosition += moveVal;
		Camera.main.transform.eulerAngles += new Vector3(0, 90 * moveVal, 0);
		if (currentPosition < 0)
		{
			currentPosition = positioningArray.Length - 1;
		}

		if (currentPosition > positioningArray.Length - 1)
		{
			currentPosition = 0;
		}
		transform.position = Camera.main.transform.position + positioningArray[currentPosition];
		
	}

	Vector3 forwardVelocity(int pos)
	{
		if (pos == 0)
		{
			return new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, forwardAccel);
		}
		else if (pos == 1)
		{
			return new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, forwardAccel);
		}
		else if (pos == 2)
		{
			return new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, forwardAccel);		
		}
		else if (pos == 3)
		{
			return new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, forwardAccel);
		}
		else
		{
			return Vector3.zero;
		}
	}

	void inputListener()
	{
		horAxis = Input.GetAxisRaw("Horizontal");
		verAxis = Input.GetAxisRaw("Vertical");
		mousePosAdj = Input.mousePosition;
		mousePosAdj.z = zAimOffset;
		firePrimary = Input.GetButtonDown("Fire1");
		positionLeft = Input.GetButtonDown("SwitchPositionLeft");
		positionRight = Input.GetButtonDown("SwitchPositionRight");
	}
}
