using UnityEngine;
using System.Collections;

public class SacredGenerator : MonoBehaviour 
{
	public GameObject circle;
	private GameObject[] circles;
	private Vector3 position;

	void Start () 
	{
		position = new Vector3(0f,0f,0f);

		circles = new GameObject[40];
		for (int i = 0; i < circles.Length; i++)
		{
			circles[i] = Instantiate (circle, position, Quaternion.identity) as GameObject;
		}

		//DrawFruitOfLife();
		//DrawFlowerOfLife();
		DrawFlowerOfLifeBigger();
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

		//First Row
		position.x = 1f;
		position.z = 0f;
		circles[1].transform.position = position;

		position.x = 1f;
		position.z = 0;
		circles[2].transform.position = position;
	
		position.x = -1f;
		position.z = 0;
		circles[3].transform.position = position;

		position.x = Mathf.Cos(Mathf.PI/3);
		position.z = Mathf.Sin(Mathf.PI/3);
		circles[4].transform.position = position;

		position.x = Mathf.Cos(4*Mathf.PI/3);
		position.z = Mathf.Sin(4*Mathf.PI/3);
		circles[5].transform.position = position;

		position.x = Mathf.Cos(5*Mathf.PI/3);
		position.z = Mathf.Sin(5*Mathf.PI/3);
		circles[6].transform.position = position;

		position.x = Mathf.Cos(2*Mathf.PI/3);
		position.z = Mathf.Sin(2*Mathf.PI/3);
		circles[7].transform.position = position;

		//Second Row
		position.x = 1f;
		position.z = (Mathf.Tan(Mathf.PI/3f));
		circles[8].transform.position = position;
		
		position.x = 1f;
		position.z = (Mathf.Tan(5*Mathf.PI/3f));
		circles[9].transform.position = position;
		
		position.x = -1f;
		position.z = (Mathf.Tan(4*Mathf.PI/3f));
		circles[10].transform.position = position;
		
		position.x = -1f;
		position.z = (Mathf.Tan(2*Mathf.PI/3f));
		circles[11].transform.position = position;
		
		position.x = 2f;
		position.z = 0f;
		circles[12].transform.position = position;
		
		position.x = -2f;
		position.z = 0f;
		circles[13].transform.position = position;
	}

	public void DrawFlowerOfLifeBigger()
	{
		//Center Circle
		position.x = 0f;
		position.z = 0f;
		circles[0].transform.position = position;
		
		//First Row
		position.x = 1f;
		position.z = 0f;
		circles[1].transform.position = position;
		
		position.x = 1f;
		position.z = 0;
		circles[2].transform.position = position;
		
		position.x = -1f;
		position.z = 0;
		circles[3].transform.position = position;
		
		position.x = Mathf.Cos(Mathf.PI/3);
		position.z = Mathf.Sin(Mathf.PI/3);
		circles[4].transform.position = position;
		
		position.x = Mathf.Cos(4*Mathf.PI/3);
		position.z = Mathf.Sin(4*Mathf.PI/3);
		circles[5].transform.position = position;
		
		position.x = Mathf.Cos(5*Mathf.PI/3);
		position.z = Mathf.Sin(5*Mathf.PI/3);
		circles[6].transform.position = position;
		
		position.x = Mathf.Cos(2*Mathf.PI/3);
		position.z = Mathf.Sin(2*Mathf.PI/3);
		circles[7].transform.position = position;
		
		//Second Row
		position.x = 1f;
		position.z = (Mathf.Tan(Mathf.PI/3f));
		circles[8].transform.position = position;
		
		position.x = 1f;
		position.z = (Mathf.Tan(5*Mathf.PI/3f));
		circles[9].transform.position = position;
		
		position.x = -1f;
		position.z = (Mathf.Tan(4*Mathf.PI/3f));
		circles[10].transform.position = position;
		
		position.x = -1f;
		position.z = (Mathf.Tan(2*Mathf.PI/3f));
		circles[11].transform.position = position;
		
		position.x = 2f;
		position.z = 0f;
		circles[12].transform.position = position;
		
		position.x = -2f;
		position.z = 0f;
		circles[13].transform.position = position;

		position.x = Mathf.Cos(5*Mathf.PI/3) + 1f;
		position.z = Mathf.Sin(5*Mathf.PI/3);
		circles[14].transform.position = position;

		position.x = Mathf.Cos(4*Mathf.PI/3) - 1f;
		position.z = Mathf.Sin(4*Mathf.PI/3);
		circles[15].transform.position = position;

		position.x = Mathf.Cos(5*Mathf.PI/3) + 1f;
		position.z = -Mathf.Sin(5*Mathf.PI/3);
		circles[16].transform.position = position;
		
		position.x = Mathf.Cos(4*Mathf.PI/3) - 1f;
		position.z = -Mathf.Sin(4*Mathf.PI/3);
		circles[17].transform.position = position;

		position.x = Mathf.Cos(5*Mathf.PI/3) -0.5f;
		position.z = Mathf.Sin(5*Mathf.PI/3) * 2;
		circles[18].transform.position = position;
		
		position.x = Mathf.Cos(5*Mathf.PI/3) -0.5f;
		position.z = -Mathf.Sin(5*Mathf.PI/3) * 2;
		circles[19].transform.position = position;
//
//		//Third Row
		position.x = Mathf.Cos(Mathf.PI/3);
		position.z =  Mathf.Sin(5*Mathf.PI/3) * 3;
		DeactivateHalfCircle(circles[20], "top");
		circles[20].transform.position = position;
		circles[20].name = "Circle[20]";

		position.x = Mathf.Cos(Mathf.PI/3);
		position.z = -Mathf.Sin(5*Mathf.PI/3) * 3;
		DeactivateHalfCircle(circles[21], "bottom");
		circles[21].transform.position = position;
		circles[21].name = "Circle[21]";

		position.x = -Mathf.Cos(Mathf.PI/3);
		position.z = Mathf.Sin(5*Mathf.PI/3) * 3;
		DeactivateHalfCircle(circles[22], "top");
		circles[22].transform.position = position;
		circles[22].name = "Circle[22]";
		
		position.x = -Mathf.Cos(Mathf.PI/3);
		position.z = -Mathf.Sin(5*Mathf.PI/3) * 3;
		DeactivateHalfCircle(circles[23], "bottom");
		circles[23].transform.position = position;
		circles[23].name = "Circle[23]";

		position.x = -Mathf.Cos(Mathf.PI/3);
		position.z = -Mathf.Sin(5*Mathf.PI/3) * 3;
		DeactivateHalfCircle(circles[24], "bottom");
		circles[24].transform.Rotate(new Vector3(0f, 60f, 0f));
		circles[24].transform.position = position;
		circles[24].name = "Circle[24]";

//		position.x = -1f;
//		position.z = (Mathf.Tan(4*Mathf.PI/3f));
//		circles[22].transform.position = position;
//		
//		position.x = -1f;
//		position.z = (Mathf.Tan(2*Mathf.PI/3f));
//		circles[23].transform.position = position;
//		
//		position.x = 2f;
//		position.z = 0f;
//		circles[24].transform.position = position;
//		
//		position.x = -2f;
//		position.z = 0f;
//		circles[25].transform.position = position;

//		position.x = 2*(1f);
//		position.z = 2*((Mathf.Tan(Mathf.PI/3f)));
//		circles[26].transform.position = position;
//		
//		position.x = 2*(1f);
//		position.z = 2*((Mathf.Tan(5*Mathf.PI/3f)));
//		circles[27].transform.position = position;
//		
//		position.x = 2*(-1f);
//		position.z = 2*((Mathf.Tan(4*Mathf.PI/3f)));
//		circles[28].transform.position = position;
//		
//		position.x = 2*(-1f);
//		position.z = 2*((Mathf.Tan(2*Mathf.PI/3f)));
//		circles[29].transform.position = position;
//		
//		position.x = 2*(2f);
//		position.z = 2*(0f);
//		circles[30].transform.position = position;
//		
//		position.x = 2*(-2f);
//		position.z = 2*(0f);
//		circles[31].transform.position = position;
	}

	void DeactivateHalfCircle(GameObject circle, string half)
	{
		Transform children = circle.transform.GetComponentInChildren<Transform>();
		foreach (Transform child in children)
		{
			if (child.name == half) child.gameObject.SetActive(false);
		}
	}

	void Update () 
	{
		DrawFlowerOfLifeBigger();
	}
}
