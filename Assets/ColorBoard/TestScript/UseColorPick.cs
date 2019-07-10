
using UnityEngine;
using Fardin.ColorTools;

public class UseColorPick : MonoBehaviour {

	[SerializeField]
	ColorPick cPick;

	void Start () {
		if(cPick==null)
		    cPick = GameObject.FindGameObjectWithTag("ColorPick").GetComponent<ColorPick>();

		/// Set event handler method so we can get colorChanges On the color change
	    cPick.OnPickColor += OnPickColorChange;
	}


	Color color = Color.blue;

	public void OnGUI(){

		GUILayout.BeginVertical (GUILayout.Width(200));
		
		GUI.color = color;
		GUILayout.Label ("OnColorChange",GUILayout.Height(30));

		GUILayout.BeginHorizontal ();
			GUILayout.Label ("Red:\t",GUILayout.Height(30));
			color.r = GUILayout.HorizontalSlider (color.r, 0, 1.0f,GUILayout.Height(30));
		GUILayout.EndHorizontal();

		GUILayout.BeginHorizontal();
			GUILayout.Label ("Green:\t",GUILayout.Height(30));
			color.g = GUILayout.HorizontalSlider (color.g, 0, 1.0f,GUILayout.Height(30));
		GUILayout.EndHorizontal();

		GUILayout.BeginHorizontal ();
			GUILayout.Label ("Blue:\t",GUILayout.Height(30));
			color.b = GUILayout.HorizontalSlider (color.b, 0, 1.0f,GUILayout.Height(30));
		GUILayout.EndHorizontal();


		GUILayout.EndVertical ();
	}

	//This method only runs on each color changes
    void OnPickColorChange(object o, OnPickColorHandler e)
    {
        color = e.color;
    }
}
