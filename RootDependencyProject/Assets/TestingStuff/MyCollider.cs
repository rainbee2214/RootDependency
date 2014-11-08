using UnityEngine;
using System.Collections;

public class MyCollider : MonoBehaviour 
{
	void OnTriggerEnter(Collider other)
	{
		Debug.Log ("Trigger by " + other.tag);
	}

	void OnCollisionEnter(Collision other)
	{
		Debug.Log("Collision with " + other.gameObject.tag);
	}
}
