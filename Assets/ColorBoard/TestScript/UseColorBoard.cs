
using UnityEngine;
using Fardin.ColorTools;

public class UseColorBoard : MonoBehaviour {

	[SerializeField]
	ColorTerminal cTerminal;

	void Start () {
		if(cTerminal==null)
			cTerminal = GameObject.FindGameObjectWithTag("ColorTerminal").GetComponent<ColorTerminal>();

		/// Set event handler method so we can get colorChanges On the color change
		cTerminal.changedColor += On_Color_Change;
	}


	Color color = Color.blue;
	Color lastColor = Color.white;

	public void OnGUI(){

		GUILayout.BeginVertical (GUILayout.Width(200));
		
		GUI.color = cTerminal.colorForm.RGB;
		GUILayout.Label ("OnEveryFrame",GUILayout.Height(30));

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



		if (color != lastColor) {
			//here you report color changes by new Color
			cTerminal.SetColorForm(color);
		}
		lastColor = color;


		GUILayout.EndVertical ();
	}

	//This method only runs on each color changes
	void On_Color_Change(object o, OnChangeColorHandler e)
	{
		color = e.form.RGB;
	}
}
