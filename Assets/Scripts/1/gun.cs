using UnityEngine;
using System.Collections;

public class gun : MonoBehaviour {
	public GameObject bullet_prefab;
	public float bullet_speed;
	GameObject myCamera;
	// Use this for initialization
	void Start () {
		myCamera = GameObject.Find ("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			if (myCamera.GetComponent<camera_1> ().isPanelShowing == false) {
				GameObject bullet = GameObject.Instantiate (bullet_prefab);
				bullet.transform.localPosition = this.transform.position;
				bullet.GetComponent<Rigidbody> ().velocity = new Vector3 (0, bullet_speed, 0);
			}
		}
	}
}
