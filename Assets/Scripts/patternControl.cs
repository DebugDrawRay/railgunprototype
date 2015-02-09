using UnityEngine;
using System.Collections;

public class patternControl : MonoBehaviour 
{
	public GameObject[] availableEnemies;

	public Vector3 anchorSpeed;

	void Update()
	{
		rigidbody.velocity = anchorSpeed;
	}
}
