using UnityEngine;
using System.Collections;

public class TimerController : MonoBehaviour 
{

	void Start () 
	{
		DisplayTime();
	}

	void Update () 
	{
		DisplayTime();
	}

	void DisplayTime()
	{
		int currentTime = (int)Time.timeSinceLevelLoad;
		gameObject.guiText.text = ("Time: " + currentTime);
	}
}
