using UnityEngine;
using System.Collections;

public class ShapeController : MonoBehaviour 
{
	public static ShapeController controller;

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

	public GameObject[] shapes;
	public string[] shapeNames;
	public string currentShape;
	public int currentShapeIndex = 0;

	#region Properties
	private int score;
	public int Score
	{
		get{return score;}
		set{score += value;}
	}
	#endregion

	void Awake () 
	{
		//if control is not set, set it to this one and allow it to persist
		if (controller == null)
		{
			DontDestroyOnLoad(gameObject);
			controller = this;
		}
		//else if control exists and it isn't this instance, destroy this instance
		else if(controller != this)
		{
			Debug.Log ("Game control already exists, deleting this new one");
			Destroy (gameObject);
		}

	}

	void Start () 
	{
		if (shapes.Length == 0)
		{
			Debug.Log("0");
			shapeNames = new string[1];
			shapeNames[0] = "Prism";
			shapes = new GameObject[1];
			
			shapes[0] = GameObject.CreatePrimitive(PrimitiveType.Cube);
			shapes[0].transform.position = new Vector3(0f, 1F, -5f);
			shapes[0].SetActive(false);
			shapes[0].gameObject.name = shapeNames[0];
		}
		else
		{
			Debug.Log("Else");
			for (int i = 0; i < shapes.Length; i++)
			{
				shapes[i] = Instantiate(shapes[i], new Vector3(0f, 1F, -5f), Quaternion.identity) as GameObject;
				shapes[i].SetActive(false);
				shapes[i].gameObject.name = shapeNames[i];
			}
		}

		currentShape = shapeNames[0];
		DisplayShape();

		startingRotation = shapes[0].transform.rotation;
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

	void DisplayShape()
	{
		shapes[currentShapeIndex].gameObject.SetActive(true);
	}

	public void IncrementShape(int incrementValue)
	{
		shapes[currentShapeIndex].gameObject.SetActive(false);
		currentShapeIndex += incrementValue;
		if (currentShapeIndex >= shapes.Length) currentShapeIndex = 0;
		if (currentShapeIndex < 0) currentShapeIndex = shapes.Length - 1;
		DisplayShape();
	}
	
	void ResetRotation()
	{
		reset = false;
		rotateAroundX = false;
		rotateAroundY = false;
		shapes[currentShapeIndex].transform.rotation = startingRotation;
		rotateAroundZ = false;
	}
	
	void Rotate (string axis)
	{
		Quaternion rotation = shapes[currentShapeIndex].transform.rotation;
		switch (axis)
		{
		case "x":
		case "X":
			shapes[currentShapeIndex].transform.rotation = rotation * xRotation;
			break;
		case "y":
		case "Y":
			shapes[currentShapeIndex].transform.rotation = rotation * yRotation;
			break;
		case "z":
		case "Z":
			shapes[currentShapeIndex].transform.rotation = rotation * zRotation;
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
