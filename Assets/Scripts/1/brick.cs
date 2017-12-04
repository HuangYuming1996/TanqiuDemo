using UnityEngine;
using System.Collections;

public class brick : MonoBehaviour {

	public Material iceball;
	public float ball_speed;
	public Vector3 speed;
	public float angle;
	GameObject myCamera;
	public GameObject myBallPrefab;
	public float myScale;
	GameObject myTanban;
	// Use this for initialization
	void Start () {
		myCamera = GameObject.Find("Main Camera");
		myTanban = GameObject.Find ("tanban");
		myScale = 0.3f;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "tanban") { // 弹出角度与接触点有关
			angle = Mathf.PI * ((other.transform.position.x + other.gameObject.GetComponent<tanban> ().length / 2 - other.contacts [0].point.x) / other.gameObject.GetComponent<tanban> ().length);
			if (angle > 0.9 * Mathf.PI) {
				angle = (float)0.9 * Mathf.PI;
			} else if (angle < 0.1 * Mathf.PI) {
				angle = (float)0.1 * Mathf.PI;
			}
			speed.x = ball_speed * Mathf.Cos (angle);
			speed.y = ball_speed * Mathf.Sin (angle);
			if (myTanban.GetComponent<tanban>().isStick == false) {
				this.GetComponent<Rigidbody> ().velocity = speed;
			} else {
				this.GetComponent<SphereCollider> ().isTrigger = true;
				this.GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 0);
				this.transform.SetParent (myTanban.transform);
				this.GetComponent<ball_force> ().isStarted = false;
				this.GetComponent<ball_force> ().start_speed = speed;
			}
		} else if (other.gameObject.tag == "dead") {  //碰到下边缘生命值-1
			
			GameObject[] all_ball = GameObject.FindGameObjectsWithTag ("ball");
			other.gameObject.GetComponent<AudioSource>().Play();
			if (all_ball.Length == 1) {   // 最后一个
				GameObject[] mySkills = GameObject.FindGameObjectsWithTag ("skill");
				foreach (GameObject skill in mySkills) {
					Destroy (skill.gameObject);
				}
				GameObject[] myGuns = GameObject.FindGameObjectsWithTag ("gun");
				foreach (GameObject gun in myGuns) {
					Destroy (gun.gameObject);
				}
				GameObject[] myBricks = GameObject.FindGameObjectsWithTag ("brick");
				foreach (GameObject brick in myBricks) {
					brick.GetComponent<BoxCollider> ().isTrigger = false;
				}
				myTanban.GetComponent<tanban> ().hasGun = false;
				myTanban.GetComponent<tanban> ().isStick = false;
				myTanban.GetComponent<tanban> ().length = 2f;
				myTanban.transform.localScale = new Vector3 (2f, 0.2f, 1f);
				GameObject myBall = GameObject.Instantiate (myBallPrefab);
				myBall.GetComponent<MeshRenderer> ().material = iceball;
				myBall.transform.Find ("iceball_particle").gameObject.SetActive (true);
				myBall.transform.Find ("fireball_particle").gameObject.SetActive (false);
				myBall.GetComponent<brick> ().ball_speed = 5.0f;
				myBall.transform.localScale = new Vector3 (0.3f, 0.3f, 0.3f);
				myBall.transform.SetParent (myTanban.transform);
				myBall.transform.localPosition = new Vector3 (0, 1.4f, 0);
				myCamera.GetComponent<camera_1> ().life--;
			}
			Destroy (this.gameObject);  // 不是最后一个直接销毁
		} else if (other.gameObject.tag == "ball") {
			Vector3 speed = this.GetComponent<Rigidbody> ().velocity.normalized;
			this.GetComponent<Rigidbody> ().velocity = speed * ball_speed;
		}
	}
}
