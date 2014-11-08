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

		circles = new GameObject[19];
		for (int i = 0; i < circles.Length; i++)
		{
			circles[i] = Instantiate (circle, position, Quaternion.identity) as GameObject;
		}

		//DrawFruitOfLife();
		DrawFlowerOfLife();
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

	void Update () 
	{
		DrawFlowerOfLife();
	}
}
