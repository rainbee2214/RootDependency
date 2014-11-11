using UnityEngine;
using System.Collections;

public class ShapeScrollerController : MonoBehaviour 
{	
	[Range(-1, 1)]
	public int incrementValue;

	void OnMouseDown()
	{
		Debug.Log("Change shapes");
		ShapeController.controller.IncrementShape(incrementValue);
	}
}
