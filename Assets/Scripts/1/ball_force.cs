using UnityEngine;
using System.Collections;

public class ball_force : MonoBehaviour {
	public Vector3 start_speed;
	public bool isStarted ;
	GameObject myCamera;
	// Use this for initialization
	void Start () {
		myCamera = GameObject.Find ("Main Camera");
		isStarted = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Mouse0)) {
			if (isStarted == false && myCamera.GetComponent<camera_1>().isPanelShowing == false) {
				this.GetComponent<SphereCollider> ().isTrigger = false;
				isStarted = true;
				this.transform.SetParent (null);
				this.GetComponent<Rigidbody> ().velocity = start_speed;
			}
		}
	}
}
