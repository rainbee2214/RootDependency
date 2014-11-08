using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour 
{
	public float speed;
	float moveBy;
	Vector3 position;

	void Start () 
	{
		position = transform.position;	
	}

	void Update () 
	{
		moveBy = Input.GetAxis("Vertical");
		position.z += moveBy*speed;
		moveBy = Input.GetAxis("Horizontal");
		position.x += moveBy*speed;

		transform.position = position;
	}
}
