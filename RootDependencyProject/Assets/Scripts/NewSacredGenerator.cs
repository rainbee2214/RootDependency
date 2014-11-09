using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NewSacredGenerator : MonoBehaviour 
{
	public int depth = 32; // Total circles to be drawn
	public GameObject circle;

	int currentDepth;

	List<GameObject> circles = new List<GameObject>();
	Vector3 position;

	int currentCircle = 0;
	Vector3 origin = new Vector3 (0f,0f,0f);

	List<Vector3> drawnCirclePositions =  new List<Vector3>();

	List<int> circlesToSurround = new List<int>();
	List<int> nextCirclesToSurround = new List<int>();

	void Start () 
	{
		currentDepth = depth;
		for (int i = 0; i < currentDepth; i++)
		{
			circles.Add(Instantiate (circle, origin, Quaternion.identity) as GameObject);
		}
		DrawFlowerOfLife();
	}
	
	
	void Update () 
	{	
	}

	void DrawFlowerOfLife()
	{		
		DrawCircle(origin);
		while (currentCircle < circles.Count)
		{
			GenerateFOL();
		}
	}

	//Must have the first circle in place at the origin
	void GenerateFOL()
	{
		for (int i = 0; i < circlesToSurround.Count; i++)
		{
			int index = (int)circlesToSurround[i];
			if (index >= circles.Count) break;
			Vector3 p = circles[index].transform.position;
			PlaceCircles(p);
		}
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
				draw = false;
			}
		}
		if (draw && currentCircle < circles.Count)
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
