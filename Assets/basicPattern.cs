using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class basicPattern : MonoBehaviour 
{
	//based on an offset from the center of the pattern
	public Vector3[] patternPositions;
	
	private List<GameObject> spawnedEnemies;
	void Start () 
	{
		spawnedEnemies = new List<GameObject>();
		if (GetComponent<patternControl>().availableEnemies.Length == patternPositions.Length)
		{
			for(int i = 0; i <= GetComponent<patternControl>().availableEnemies.Length - 1; i++)
			{
				GameObject newEnemy;
				newEnemy = Instantiate(GetComponent<patternControl>().availableEnemies[i], transform.position + patternPositions[i], Quaternion.identity) as GameObject;
				spawnedEnemies.Add(newEnemy);
			}
		}
		else
		{
			Debug.Log("Required enemy count not met");
		}
	}
	
	void Update () 
	{
			spawnedEnemies[0].transform.position = new Vector3(spawnedEnemies[0].transform.position.x, spawnedEnemies[0].transform.position.y, transform.position.z);
		
	}
}