using UnityEngine;
using System.Collections;

public class testMouse : MonoBehaviour
{
	void Update () 
	{
		Vector3 temp = Input.mousePosition;
		temp.z = transform.position.z- Camera.main.transform.position.z;
 		transform.position = Camera.main.ScreenToWorldPoint(temp);
	}
}
