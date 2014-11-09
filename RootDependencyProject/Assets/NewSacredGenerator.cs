using UnityEngine;
using System.Collections;

public class NewSacredGenerator : MonoBehaviour 
{
	public GameObject circle;
	private GameObject[] circles;
	private Vector3 position;
	public bool generate;
	int currentCircle = 0;
	Vector3 origin = new Vector3 (0f,0f,0f);
	public int depth = 32; // Total circles to be drawn
	
	ArrayList currentCircles;
	ArrayList circlePositions;
	ArrayList drawnCirclePositions;

	ArrayList circlesToSurround;
	ArrayList nextCirclesToSurround;

	void Start () 
	{
		circlesToSurround = new ArrayList();
		nextCirclesToSurround = new ArrayList();
		currentCircles = new ArrayList();
		circlePositions = new ArrayList();
		drawnCirclePositions =  new ArrayList();
		circles = new GameObject[depth];
		for (int i = 0; i < circles.Length; i++)
		{
			circles[i] = Instantiate (circle, origin, Quaternion.identity) as GameObject;
		}
	}
	
	
	void Update () 
	{	
		if(generate && currentCircle < circles.Length)
		{
			GenerateFOL();
			generate = false;
		}
	}
	
	void GenerateFOL()
	{
		if (currentCircle == 0) DrawCircle(origin);
		else
		{
			for (int i = 0; i < circlesToSurround.Count; i++)
			{
				int index = (int)circlesToSurround[i];
				if (index >= circles.Length) break;
				Vector3 p = circles[index].transform.position;
				PlaceCircles(p);
			}
		}

		//Generate all circles at indexes inside circles to surround
//		if (currentCircle == 0) DrawCircle(origin);
//		else //if (currentCircle == 1)
//		{
//			Debug.Log(currentCircle);
//			PlaceCircles(circles[currentCircle - 1].transform.position);
//		}
//		else if (currentCircle > 1 && currentCircle < 8)
//		{
//			PlaceCircles(Mathf.Cos (Mathf.PI/3f), Mathf.Sin(Mathf.PI/3));
//		}
//		else
//		{
//			Debug.Log(currentCircle);
//		}
	}

	// Draws 6 circles surrounding a circle (currentCirles position)
	void PlaceCircles(float xPosition, float zPosition)
	{
		float theta = 0f;
		Vector3 tempOrigin = new Vector3(xPosition, 0f, zPosition);
		for (int i = 0; i < 6; i++)
		{
			DrawCircle(Mathf.Cos(theta) + xPosition, Mathf.Sin(theta) + zPosition);
			theta += Mathf.PI/3f;
		}

	}
	void PlaceCircles(Vector3 currentCirclePosition)
	{
		PlaceCircles(currentCirclePosition.x, currentCirclePosition.z);
	}

	// Draw a circle with the the centerpoint being the given position
	// Will place the currentCirlce index Circle from the circles list and place it in the new position
	// Then the currentCircle will be incremented
	void DrawCircle(float xPosition, float zPosition)
	{
		//Center Circle
		position.x = xPosition;
		position.z = zPosition;

		bool draw = true;
		//Check if position exists in drawnCirclePositions
		foreach (Vector3 p in drawnCirclePositions)
		{
			if (EqualCirclePositions(p, position, 0.00001f)) 
			{
				//Don't draw the circle
				Debug.Log("Duplicate circle being drawn: " + currentCircle);
				draw = false;
			}
		}
		if (draw && currentCircle < circles.Length)
		{
			circles[currentCircle].transform.position = position;
			circles[currentCircle].name = "Circle" + currentCircle;
			currentCircle++;
			drawnCirclePositions.Add(position);
			circlesToSurround.Add (currentCircle);

		}
	}

	void DrawCircle(Vector3 newPosition)
	{
		DrawCircle(newPosition.x, newPosition.z);
	}

	bool EqualCirclePositions(Vector3 firstPosition, Vector3 secondPosition, float precision)
	{
		//Compare x
		float temp1, temp2;
		float threshholdUpper, threshholdLower;
		temp1 = firstPosition.x;
		temp2 = secondPosition.x;

		threshholdUpper = temp1 + precision;
		threshholdLower = temp1 - precision;
		if (!((temp2 < threshholdUpper) && (temp2 > threshholdLower)))
			return false;

		//Compare y
		temp1 = firstPosition.y;
		temp2 = secondPosition.y;
		
		threshholdUpper = temp1 + precision;
		threshholdLower = temp1 - precision;
		if (!((temp2 < threshholdUpper) && (temp2 > threshholdLower)))
			return false;

		//Compare z
		temp1 = firstPosition.z;
		temp2 = secondPosition.z;
		
		threshholdUpper = temp1 + precision;
		threshholdLower = temp1 - precision;
		if (!((temp2 < threshholdUpper) && (temp2 > threshholdLower)))
			return false;

		return true;
	}
}
