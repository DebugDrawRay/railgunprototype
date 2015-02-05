using UnityEngine;
using System.Collections;

public class caravanTruck : MonoBehaviour
{

	public float speed;
	
	void Update () 
	{
		rigidbody.velocity = Vector3.forward * speed;

	}
}
