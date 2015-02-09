using UnityEngine;
using System.Collections;

public class cameraControl : MonoBehaviour 
{	
	void Update () 
	{
		rigidbody.velocity = Vector3.forward * GameObject.FindGameObjectWithTag("Player").GetComponent<playerCharacter>().forwardAccel;
	}
}
