using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour 
{
	private bool toggleBool = true;
	private string textFieldString = "text field";
	private int toolbarInt = 0;
	private string[] toolbarStrings = {"Toolbar1", "Toolbar2", "Toolbar3"};
	private int selectionGridInt = 0;
	private string[] selectionStrings = {"Grid 1", "Grid 2", "Grid 3", "Grid 4"};
	private float hSliderValue = 0.0f;


	private Rect windowRect = new Rect (5, 30, 200, 200);

	public bool myBool = false;

	void OnGUI () 
	{


//		textFieldString = GUI.TextArea (new Rect (200, 250, 300, 300), textFieldString);
//		toggleBool = GUI.Toggle (new Rect (500, 25, 100, 30), toggleBool, "Toggle");
//		toolbarInt = GUI.Toolbar (new Rect (300, 50, 250, 30), toolbarInt, toolbarStrings);
//		selectionGridInt = GUI.SelectionGrid (new Rect (25, 25, 300, 60), selectionGridInt, selectionStrings, 2);

		if (GUI.Button (new Rect (5, 5, 80, 15), "Menu"))
		{
			myBool = !myBool;
		}

		if (myBool)
		{
			windowRect = GUI.Window (0, windowRect, WindowFunction, "");

		}
	}


	void WindowFunction (int windowID) {
		// Draw any Controls inside the window here
		hSliderValue = GUI.HorizontalSlider (new Rect (5, 20, 100, 100), hSliderValue, 0.0f, 10.0f);
		if (GUI.RepeatButton (new Rect (5, 40, 100, 30), "ClickMe")) {
			GUI.Label (new Rect (110, 65, 100, 30), "Sarah<3sJoel");
		}

	}

}
