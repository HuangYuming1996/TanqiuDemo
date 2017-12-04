using UnityEngine;
using System.Collections;

public class tanban : MonoBehaviour {
	public float length;
	public Camera myCamera;
	public Vector3 mousePosition;
	public bool isStick;
	public bool hasGun;
	// Use this for initialization
	void Start () {
		isStick = false;
		hasGun = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		mousePosition.x = myCamera.ScreenToWorldPoint(Input.mousePosition + new Vector3(0,0,10)).x;
		if (mousePosition.x > 8 - (length / 2)) {
			this.transform.position = new Vector3 (8 - (length / 2), -4.4f, 10);
		} else if (mousePosition.x < -8 + (length / 2)) {
			this.transform.position = new Vector3 (-8 + (length / 2), -4.4f, 10);
		} else {
			this.transform.position = mousePosition;
		}
	}
}
