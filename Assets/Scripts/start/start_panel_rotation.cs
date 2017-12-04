using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start_panel_rotation : MonoBehaviour {
	public RectTransform Button_Panel;
	public float x_Angle;
	public float y_Angle;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Button_Panel.rotation = Quaternion.Euler (new Vector3 (
			(Camera.main.ScreenToViewportPoint (Input.mousePosition).y - 0.5f) *(- y_Angle),
			(Camera.main.ScreenToViewportPoint (Input.mousePosition).x - 0.5f) * x_Angle,
			0f
		));
	}
	void OnGUI(){
		GUILayout.Label ("viewportPoint" +Camera.main.ScreenToViewportPoint(Input.mousePosition));
	}
}
