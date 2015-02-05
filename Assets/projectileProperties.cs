using UnityEngine;
using System.Collections;

public class projectileProperties : MonoBehaviour 
{
	public float speed;

	void Start()
	{
		rigidbody.velocity = transform.forward * speed;
	}
}
