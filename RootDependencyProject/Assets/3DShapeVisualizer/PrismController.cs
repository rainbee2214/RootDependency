using UnityEngine;
using System.Collections;

public class PrismController : MonoBehaviour 
{
	public float rotationSpeed = 1f;
	public bool rotateAroundX = false;
	public bool rotateAroundY = false;
	public bool rotateAroundZ = false;
	public bool reset = false;

	float currentSpeed;
	Quaternion xRotation;
	Quaternion yRotation;
	Quaternion zRotation;
	Quaternion noRotation = Quaternion.Euler(0f, 0f, 0f);

	Quaternion startingRotation;

	void Start () 
	{
		startingRotation = transform.rotation;
		SetRotations();
	}

	void Update () 
	{
		if (reset) ResetRotation();
		if (currentSpeed != rotationSpeed) SetRotations();

		if (rotateAroundY) Rotate("y");
		if (rotateAroundX) Rotate("x");
		if (rotateAroundZ) Rotate("z");
	}

	void ResetRotation()
	{
		reset = false;
		rotateAroundX = false;
		rotateAroundY = false;
		transform.rotation = startingRotation;
		rotateAroundZ = false;
	}

	void Rotate (string axis)
	{
		Quaternion rotation = transform.rotation;
		switch (axis)
		{
		case "x":
		case "X":
			transform.rotation = rotation * xRotation;
			break;
		case "y":
		case "Y":
			transform.rotation = rotation * yRotation;
			break;
		case "z":
		case "Z":
			transform.rotation = rotation * zRotation;
			break;
		default:
			break;
		}
	}

	void SetRotations()
	{
		currentSpeed = rotationSpeed;
		xRotation = Quaternion.Euler(currentSpeed, 0f, 0f);
		yRotation = Quaternion.Euler(0f, currentSpeed, 0f);
		zRotation = Quaternion.Euler(0f, 0f, currentSpeed);
	}
}
