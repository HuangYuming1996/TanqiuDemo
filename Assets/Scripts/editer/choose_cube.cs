using UnityEngine;
using System.Collections;

public class choose_cube : MonoBehaviour {
	public int myKind;
	public float speed;
	public GameObject myCamera;
	bool isMouseOver;
	// Use this for initialization
	void Start () {
		speed = 3f;

	}
	
	// Update is called once per frame
	void Update () {
		if (isMouseOver == false) {
			this.transform.localScale = new Vector3 (Mathf.MoveTowards (this.transform.localScale.x, 1f, Time.deltaTime * speed), Mathf.MoveTowards (this.transform.localScale.y, 0.5f, Time.deltaTime * speed), 1f);
		}
	}
	void OnMouseDown(){
		myCamera.GetComponent<camera_editer> ().chooseCubeKind = myKind;
	}
	void OnMouseEnter(){
		isMouseOver = true;
	}
	void OnMouseOver(){
		this.transform.localScale = new Vector3 (Mathf.MoveTowards(this.transform.localScale.x,1.3f,Time.deltaTime * speed), Mathf.MoveTowards(this.transform.localScale.y,0.65f,Time.deltaTime * speed), 1f);
	}
	void OnMouseExit(){
		isMouseOver = false;
	}


}
