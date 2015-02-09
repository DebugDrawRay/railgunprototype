using UnityEngine;
using System.Collections;

public class waveTrigger : MonoBehaviour 
{

	public GameObject waveToSpawn;
	public Vector3 spawnOffset;

	void OnTriggerEnter(Collider other)
	{
		Instantiate (waveToSpawn, transform.position + spawnOffset, Quaternion.identity);
		Destroy(this.gameObject);
	}
}
