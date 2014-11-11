using UnityEngine;
using System.Collections;

public class ShapeNameController : MonoBehaviour 
{
	int current;

	void Start () 
	{
		current = ShapeController.controller.currentShapeIndex;
		SetText();
	}

	void Update () 
	{
		if (current != ShapeController.controller.currentShapeIndex) 
		{
			current = ShapeController.controller.currentShapeIndex;
			SetText();
		}
	}

	void SetText()
	{
		gameObject.guiText.text = ShapeController.controller.shapeNames[current];
	}
}
