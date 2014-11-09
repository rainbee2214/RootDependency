using UnityEngine;
using System.Collections;

public class SacredGenerator : MonoBehaviour 
{
	public float rotationSpeed = 1f;
	public GameObject circle;
	private GameObject[] circles;
	private Vector3 position;

	void Start () 
	{
		position = new Vector3(0f,0f,0f);

		circles = new GameObject[33];
		for (int i = 0; i < circles.Length; i++)
		{
			circles[i] = Instantiate (circle, position, Quaternion.identity) as GameObject;
		}

		//DrawFruitOfLife();
		//DrawFlowerOfLife(); // This is where I manually determined the positions of each circle using trigonometry

		DrawFOL(); // Here I am generating the rows of the flower of life using trigonometry
	}

	
	void Update () 
	{	
		
		DrawFOL();
		SpinCircles();
	}

	void DrawFOL()
	{
		int currentCircle = 0;
		float theta = 0f;
		float radius = 1f;
		float k = 0f;
		//Center circle
		/////
		position.x = 0f;
		position.z = 0f;
		circles[0].transform.position = position;
		currentCircle++;

		//Second Row
		/////
		for (int i = currentCircle; i < currentCircle + 6; i++)
		{
			position.x = Mathf.Cos(theta);
			position.z = Mathf.Sin(theta);
			circles[i].transform.position = position;
			circles[i].name = "SecondRow :" + i;
			theta += Mathf.PI/3f;
		}
		currentCircle += 6;
		
		//Third Row - Group 1
		///
		theta = 0f;
		for (int i = currentCircle; i < currentCircle + 6; i++)
		{
			position.x = 2*Mathf.Cos(theta);
			position.z = 2*Mathf.Sin(theta);
			circles[i].transform.position = position;
			circles[i].name = "ThirdRow :" + i;
			theta += Mathf.PI/3f;
		}
		currentCircle += 6;

		//An alternate method of finding the third row - group 1
		/////
//		theta = 0f;
//		float r = 2f*radius;
//		position.x = r;
//		k = -1f;
//		for (int i = currentCircle; i < currentCircle + 6; i++)
//		{
//			position.z = Mathf.Tan(theta);
//			circles[i].transform.position = position;
//			circles[i].name = "ThirdRow :" + i;
//			r += k;
//			if (r == -2) k = 1f;
//			if (r == 0) r += k;
//			position.x = r;
//			theta += Mathf.PI/3f;
//		}
//		currentCircle += 6;
		{
			//Third Row - Group 2
			theta = Mathf.PI/3f;
			position.x = Mathf.Cos(theta) + radius;
			position.z = Mathf.Sin(theta);
			circles[13].transform.position = position;
			
			theta += Mathf.PI/3f;
			position.x = Mathf.Cos(theta) - radius;
			position.z = Mathf.Sin(theta);
			circles[14].transform.position = position;
			
			theta = Mathf.PI/3f;
			position.x = Mathf.Cos(theta) + radius;
			position.z = -Mathf.Sin(theta);
			circles[15].transform.position = position;
			
			theta += Mathf.PI/3f;
			position.x = Mathf.Cos(theta) - radius;
			position.z = -Mathf.Sin(theta);
			circles[16].transform.position = position;
			
			position.x = 0;
			position.z = 2 * Mathf.Sin(theta);
			circles[17].transform.position = position;
			
			position.x = 0;
			position.z = -2 * Mathf.Sin(theta);
			circles[18].transform.position = position;
			currentCircle += 6;
		}

	}
	
	void DeactivateHalfCircle(GameObject circle, string half)
	{
		Transform children = circle.transform.GetComponentInChildren<Transform>();
		foreach (Transform child in children)
		{
			if (child.name == half) child.gameObject.SetActive(false);
		}
	}

	// You can change the rotation of the x and z for interesting outcomes :)
	void SpinCircles()
	{
		for (int i = 0; i < circles.Length; i++)
		{
			circles[i].transform.Rotate(new Vector3(0f, rotationSpeed, 0f));
		}
	}
	
	void SpinHalfCircles()
	{
		for (int i = 0; i < circles.Length; i++)
		{
			DeactivateHalfCircle(circles[i], "top");
			circles[i].transform.Rotate(new Vector3(0f, rotationSpeed, 0f));
		}
	}

	public void DrawFruitOfLife()
	{
		//Center Circle
		position.x = 0f;
		position.z = 0f;
		circles[0].transform.position = position;
		//First Row
		position.x = 1f;
		position.z = (Mathf.Tan(Mathf.PI/3f));
		circles[1].transform.position = position;
		
		position.x = 1f;
		position.z = (Mathf.Tan(5*Mathf.PI/3f));
		circles[2].transform.position = position;
		
		position.x = -1f;
		position.z = (Mathf.Tan(4*Mathf.PI/3f));
		circles[3].transform.position = position;
		
		position.x = -1f;
		position.z = (Mathf.Tan(2*Mathf.PI/3f));
		circles[4].transform.position = position;
		
		position.x = 2f;
		position.z = 0f;
		circles[5].transform.position = position;
		
		position.x = -2f;
		position.z = 0f;
		circles[6].transform.position = position;
		
		//Second Row
		position.x = 2*(1f);
		position.z = 2*((Mathf.Tan(Mathf.PI/3f)));
		circles[7].transform.position = position;
		
		position.x = 2*(1f);
		position.z = 2*((Mathf.Tan(5*Mathf.PI/3f)));
		circles[8].transform.position = position;
		
		position.x = 2*(-1f);
		position.z = 2*((Mathf.Tan(4*Mathf.PI/3f)));
		circles[9].transform.position = position;
		
		position.x = 2*(-1f);
		position.z = 2*((Mathf.Tan(2*Mathf.PI/3f)));
		circles[10].transform.position = position;
		
		position.x = 2*(2f);
		position.z = 2*(0f);
		circles[11].transform.position = position;
		
		position.x = 2*(-2f);
		position.z = 2*(0f);
		circles[12].transform.position = position;
	}
	
	public void DrawFlowerOfLife()
	{
		//Center Circle
		position.x = 0f;
		position.z = 0f;
		circles[0].transform.position = position;
		circles[0].transform.Rotate(new Vector3(0f, 60f, 0f));
		
		//First Row
		position.x = 1f;
		position.z = 0f;
		circles[1].transform.position = position;
		circles[1].transform.Rotate(new Vector3(0f, 60f, 0f));
		
		position.x = 1f;
		position.z = 0;
		circles[2].transform.position = position;
		circles[2].transform.Rotate(new Vector3(0f, 60f, 0f));
		
		position.x = -1f;
		position.z = 0;
		circles[3].transform.position = position;
		circles[3].transform.Rotate(new Vector3(0f, 60f, 0f));
		
		position.x = Mathf.Cos(Mathf.PI/3);
		position.z = Mathf.Sin(Mathf.PI/3);
		circles[4].transform.position = position;
		circles[4].transform.Rotate(new Vector3(0f, 60f, 0f));
		
		position.x = Mathf.Cos(4*Mathf.PI/3);
		position.z = Mathf.Sin(4*Mathf.PI/3);
		circles[5].transform.position = position;
		circles[5].transform.Rotate(new Vector3(0f, 60f, 0f));
		
		position.x = Mathf.Cos(5*Mathf.PI/3);
		position.z = Mathf.Sin(5*Mathf.PI/3);
		circles[6].transform.position = position;
		circles[6].transform.Rotate(new Vector3(0f, 60f, 0f));
		
		position.x = Mathf.Cos(2*Mathf.PI/3);
		position.z = Mathf.Sin(2*Mathf.PI/3);
		circles[7].transform.position = position;
		circles[7].transform.Rotate(new Vector3(0f, 60f, 0f));
		
		//Second Row
		position.x = 1f;
		position.z = (Mathf.Tan(Mathf.PI/3f));
		circles[8].transform.position = position;
		circles[8].transform.Rotate(new Vector3(0f, 60f, 0f));
		
		position.x = 1f;
		position.z = (Mathf.Tan(5*Mathf.PI/3f));
		circles[9].transform.position = position;
		circles[9].transform.Rotate(new Vector3(0f, 60f, 0f));
		
		position.x = -1f;
		position.z = (Mathf.Tan(4*Mathf.PI/3f));
		circles[10].transform.position = position;
		circles[10].transform.Rotate(new Vector3(0f, 60f, 0f));
		
		position.x = -1f;
		position.z = (Mathf.Tan(2*Mathf.PI/3f));
		circles[11].transform.position = position;
		circles[11].transform.Rotate(new Vector3(0f, 60f, 0f));
		
		position.x = 2f;
		position.z = 0f;
		circles[12].transform.position = position;
		circles[12].transform.Rotate(new Vector3(0f, 60f, 0f));
		
		position.x = -2f;
		position.z = 0f;
		circles[13].transform.position = position;
		circles[13].transform.Rotate(new Vector3(0f, 60f, 0f));
		
		position.x = Mathf.Cos(5*Mathf.PI/3) + 1f;
		position.z = Mathf.Sin(5*Mathf.PI/3);
		circles[14].transform.position = position;
		circles[14].transform.Rotate(new Vector3(0f, 60f, 0f));
		
		position.x = Mathf.Cos(4*Mathf.PI/3) - 1f;
		position.z = Mathf.Sin(4*Mathf.PI/3);
		circles[15].transform.position = position;
		circles[15].transform.Rotate(new Vector3(0f, 60f, 0f));
		
		position.x = Mathf.Cos(5*Mathf.PI/3) + 1f;
		position.z = -Mathf.Sin(5*Mathf.PI/3);
		circles[16].transform.position = position;
		circles[16].transform.Rotate(new Vector3(0f, 60f, 0f));
		
		position.x = Mathf.Cos(4*Mathf.PI/3) - 1f;
		position.z = -Mathf.Sin(4*Mathf.PI/3);
		circles[17].transform.position = position;
		circles[17].transform.Rotate(new Vector3(0f, 60f, 0f));
		
		position.x = Mathf.Cos(5*Mathf.PI/3) -0.5f;
		position.z = Mathf.Sin(5*Mathf.PI/3) * 2;
		circles[18].transform.position = position;
		circles[18].transform.Rotate(new Vector3(0f, 60f, 0f));
		
		position.x = Mathf.Cos(5*Mathf.PI/3) -0.5f;
		position.z = -Mathf.Sin(5*Mathf.PI/3) * 2;
		circles[19].transform.position = position;
		circles[19].transform.Rotate(new Vector3(0f, 60f, 0f));
		//
		//		//Third Row
		//		position.x = Mathf.Cos(Mathf.PI/3);
		//		position.z =  Mathf.Sin(5*Mathf.PI/3) * 3;
		//		DeactivateHalfCircle(circles[20], "bottom");
		//		circles[20].transform.Rotate(new Vector3(0f, 60f, 0f));
		//		circles[20].transform.position = position;
		//		circles[20].name = "Circle[20]";
		//
		//		position.x = Mathf.Cos(Mathf.PI/3);
		//		position.z = -Mathf.Sin(5*Mathf.PI/3) * 3;
		//		DeactivateHalfCircle(circles[21], "bottom");
		//		circles[21].transform.Rotate(new Vector3(0f, 60f, 0f));
		//		circles[21].transform.position = position;
		//		circles[21].name = "Circle[21]";
		//
		//		position.x = -Mathf.Cos(Mathf.PI/3);
		//		position.z = Mathf.Sin(5*Mathf.PI/3) * 3;
		//		DeactivateHalfCircle(circles[22], "bottom");
		//		circles[22].transform.Rotate(new Vector3(0f, 60f, 0f));
		//		circles[22].transform.position = position;
		//		circles[22].name = "Circle[22]";
		//		
		//		position.x = -Mathf.Cos(Mathf.PI/3);
		//		position.z = -Mathf.Sin(5*Mathf.PI/3) * 3;
		//		DeactivateHalfCircle(circles[23], "bottom");
		//		circles[23].transform.Rotate(new Vector3(0f, 60f, 0f));
		//		circles[23].transform.position = position;
		//		circles[23].name = "Circle[23]";
		
		//		position.x = 0;
		//		position.z = 0;
		//		position.y = -23f;
		//		DeactivateHalfCircle(circles[24], "bottom");
		//		circles[24].transform.Rotate(new Vector3(0f, 60f, 0f));
		//		circles[24].transform.position = position;
		//		circles[24].name = "Circle[24]";
		//		position.y = -10f;
	}
}
