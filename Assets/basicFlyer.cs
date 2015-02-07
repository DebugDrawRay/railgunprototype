using UnityEngine;
using System.Collections;

public class basicFlyer : MonoBehaviour 
{

	void Update () 
	{
		
		transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform.position);
		Instantiate(GetComponent<enemyProperties>().weaponType, transform.position, transform.rotation);
	}
}
