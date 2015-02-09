using UnityEngine;
using System.Collections;

public class targetingRet : MonoBehaviour 
{

	void Update () 
	{
		positionRet();
	}

	void positionRet()
	{
		Vector3 temp = Input.mousePosition;
 		transform.position = temp;
	}
}
