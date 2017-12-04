using UnityEngine;
using System.Collections;
public class skill_trigger : MonoBehaviour {
	public Material iceball;
	public Material fireBall;
	public GameObject particle;
	public int[] skill_proportion;
	public int skill_kind;
	public Vector3 startSpeed;
	public Sprite[] skill_sprite;
	private GameObject myCamera;
	public GameObject myBallPrefab;
	public GameObject gun_prefab;
	float random_skill_proportion;
	int skill_sum;
	// Use this for initialization
	void Start () {
		myCamera = GameObject.Find ("Main Camera");
		for (int i = 0; i < skill_proportion.Length; i++) {
			skill_sum = skill_sum + skill_proportion [i];
		}
		random_skill_proportion = Random.Range (0f, (float)skill_sum);
		int a = 0;

		for (int i = 0; i < skill_proportion.Length; i++) {
			a += skill_proportion [i];
			if (random_skill_proportion < a) {
				skill_kind = i;
				this.GetComponent<SpriteRenderer> ().sprite = skill_sprite [i];
				break;
			}
		}
		switch (skill_kind) {
		case 10:
			{
				this.GetComponent<SpriteRenderer> ().sortingOrder = 1;
				break;
			}
		}	
		this.GetComponent<Rigidbody> ().velocity = startSpeed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "tanban") {
			switch (skill_kind) {
			case 0:
				{
					other.transform.Find ("skill_sound_source").GetComponent<SKill_Audio_Source> ().PlayAudio ("good");
					GameObject myTanban = GameObject.Find ("tanban");
					ArrayList myBallsInTanban = new ArrayList ();
					foreach (Transform myBall in myTanban.transform) {
						myBallsInTanban.Add (myBall);
					}
					foreach (Transform child in myBallsInTanban) {
						child.SetParent (null);
					}
					float myLength = myTanban.GetComponent<tanban> ().length;
					if (myLength == 0.5f) {
						myLength = 1f;
					} else if (myLength == 1f) {
						myLength = 2f;
					} else if (myLength == 2) {
						myLength = 3f;
					} else if (myLength == 3) {
						myLength = 4.5f;
					} else if (myLength == 4.5) {
						myLength = 6.5f;
					}
					myTanban.GetComponent<tanban> ().length = myLength;
					myTanban.transform.localScale = new Vector3 (myLength, 0.2f, 1f);
					foreach (Transform myBall in myBallsInTanban) {
						myBall.SetParent (myTanban.transform);
						if (myBall.tag == "gun") {
							if (myBall.transform.localPosition.x < 0) {
								myBall.transform.localPosition = new Vector3 (-0.5f, 1f, 0);
							} else {
								myBall.transform.localPosition = new Vector3 (0.5f, 1f, 0);
							}
						}
					}
					break;
				}
			case 1:
				{
					other.transform.Find ("skill_sound_source").GetComponent<SKill_Audio_Source> ().PlayAudio ("bad");
					GameObject myTanban = GameObject.Find ("tanban");
					ArrayList myBallsInTanban = new ArrayList ();
					foreach (Transform myBall in myTanban.transform) {
						myBallsInTanban.Add (myBall);
					}
					foreach (Transform child in myBallsInTanban) {
						child.SetParent (null);
					}
					float myLength = myTanban.GetComponent<tanban> ().length;
					if (myLength == 2f) {
						myLength = 1f;
					} else if (myLength == 3f) {
						myLength = 2f;
					} else if (myLength == 4.5) {
						myLength = 3f;
					} else if (myLength == 6.5) {
						myLength = 4.5f;
					} else if (myLength == 1) {
						myLength = 0.5f;
					}
					myTanban.GetComponent<tanban> ().length = myLength;
					myTanban.transform.localScale = new Vector3 (myLength, 0.2f, 1f);
					foreach (Transform myBall in myBallsInTanban) {
						myBall.SetParent (myTanban.transform);
						if (myBall.tag == "gun") {
							if (myBall.transform.localPosition.x < 0) {
								myBall.transform.localPosition = new Vector3 (-0.5f, 1f, 0);
							} else {
								myBall.transform.localPosition = new Vector3 (0.5f, 1f, 0);
							}
						}
					}
					break;
				}
			case 2:
				{
					other.transform.Find ("skill_sound_source").GetComponent<SKill_Audio_Source> ().PlayAudio ("bad");
					GameObject[] myBall = GameObject.FindGameObjectsWithTag("ball");
					float myBallSpeed = myBall [0].GetComponent<brick>().ball_speed;
				
					if (myBallSpeed == 4f) {
						myBallSpeed = 5f;
						foreach (GameObject  ball in myBall) {
							ball.GetComponent<Rigidbody> ().velocity *= 1.25f;
						}
					} else if (myBallSpeed == 5f) {
						myBallSpeed = 7.5f;
						foreach (GameObject  ball in myBall) {
							ball.GetComponent<Rigidbody> ().velocity *= 1.5f;
						}
					} else if (myBallSpeed == 7.5f) {
						myBallSpeed = 9f;
						foreach (GameObject  ball in myBall) {
							ball.GetComponent<Rigidbody> ().velocity *= 1.2f;
						}
					}
					foreach (GameObject ball in myBall) {
						ball.GetComponent<brick> ().ball_speed = myBallSpeed;
					}
					break;
				}
			case 3:
				{
					other.transform.Find ("skill_sound_source").GetComponent<SKill_Audio_Source> ().PlayAudio ("good");
					GameObject[] myBall = GameObject.FindGameObjectsWithTag("ball");
					float myBallSpeed = myBall [0].GetComponent<brick>().ball_speed;

					if (myBallSpeed == 5f) {
						myBallSpeed = 4f;
						foreach (GameObject  ball in myBall) {
							ball.GetComponent<Rigidbody> ().velocity /= 1.25f;
						}
					} else if (myBallSpeed == 7.5f) {
						myBallSpeed = 5f;
						foreach (GameObject  ball in myBall) {
							ball.GetComponent<Rigidbody> ().velocity /= 1.5f;
						}
					} else if (myBallSpeed == 9f) {
						myBallSpeed = 7.5f;
						foreach (GameObject  ball in myBall) {
							ball.GetComponent<Rigidbody> ().velocity /= 1.2f;
						}
					}
					foreach (GameObject ball in myBall) {
						ball.GetComponent<brick> ().ball_speed = myBallSpeed;
						Vector3 ball_start_speed = ball.GetComponent<ball_force> ().start_speed.normalized;
						ball.GetComponent<ball_force> ().start_speed = ball_start_speed * myBallSpeed;
					}
					break;
				}
			case 4:
				{
					other.transform.Find ("skill_sound_source").GetComponent<SKill_Audio_Source> ().PlayAudio ("good");
					GameObject myTanban = GameObject.FindGameObjectWithTag ("tanban");
					if (myTanban.GetComponent<tanban> ().hasGun == false) {
						myTanban.GetComponent<tanban> ().hasGun = true;
						GameObject gun_left = GameObject.Instantiate (gun_prefab);
						gun_left.transform.SetParent (myTanban.transform);
						gun_left.transform.localScale = new Vector3 (0.05f, 3f, 0.1f);
						gun_left.transform.localPosition = new Vector3 (-0.5f, 1f, 0);
						GameObject gun_right = GameObject.Instantiate (gun_prefab);
						gun_right.transform.SetParent (myTanban.transform);
						gun_right.transform.localScale = new Vector3 (0.05f, 3f, 0.1f);
						gun_right.transform.localPosition = new Vector3 (0.5f, 1f, 0);
					}
					break;
				}
			case 5:
				{
					other.transform.Find ("skill_sound_source").GetComponent<SKill_Audio_Source> ().PlayAudio ("good");
					GameObject[] myCubes = GameObject.FindGameObjectsWithTag ("brick");
					foreach (GameObject cube in myCubes) {
						cube.GetComponent<BoxCollider> ().isTrigger = true;
					}
					GameObject[] myballs = GameObject.FindGameObjectsWithTag ("ball");
					foreach (GameObject myball in myballs) {
						myball.transform.Find ("iceball_particle").gameObject.SetActive (false);
						myball.transform.Find ("fireball_particle").gameObject.SetActive (true);
						myball.GetComponent<MeshRenderer> ().material = fireBall;
					}
					break;
				}
			case 6:
				{
					other.transform.Find ("skill_sound_source").GetComponent<SKill_Audio_Source> ().PlayAudio ("good");
					GameObject myTanban = GameObject.Find ("tanban");
					ArrayList myBallsInTanban = new ArrayList ();
					foreach (Transform myBall in myTanban.transform) {
						myBallsInTanban.Add (myBall);
					}
					foreach (Transform child in myBallsInTanban) {
						child.SetParent (null);
					}
					GameObject[] myBalls = GameObject.FindGameObjectsWithTag ("ball");
					float myBallScale = myBalls [0].GetComponent<brick>().myScale;
					if (myBallScale == 0.2f) {
						myBallScale = 0.3f;
						foreach (GameObject ball in myBalls) {
							ball.transform.localScale = new Vector3 (myBallScale, myBallScale, myBallScale);
							ball.GetComponent<brick> ().myScale = myBallScale;
						}
					} else if (myBallScale == 0.3f) {
						myBallScale = 0.4f;
						foreach (GameObject ball in myBalls) {
							ball.transform.localScale = new Vector3 (myBallScale, myBallScale, myBallScale);
							ball.GetComponent<brick> ().myScale = myBallScale;
						}
					}
					foreach (Transform myBall in myBallsInTanban) {
						myBall.SetParent (myTanban.transform);
					}
					break;
				}
			case 7:
				{
					other.transform.Find ("skill_sound_source").GetComponent<SKill_Audio_Source> ().PlayAudio ("bad");
					GameObject myTanban = GameObject.Find ("tanban");
					ArrayList myBallsInTanban = new ArrayList ();
					foreach (Transform myBall in myTanban.transform) {
						myBallsInTanban.Add (myBall);
					}
					foreach (Transform child in myBallsInTanban) {
						child.SetParent (null);
					}
					GameObject[] myBalls = GameObject.FindGameObjectsWithTag ("ball");
					float myBallScale = myBalls [0].GetComponent<brick>().myScale;
					if (myBallScale == 0.3f) {
						myBallScale = 0.2f;
						foreach (GameObject ball in myBalls) {
							ball.transform.localScale = new Vector3 (myBallScale, myBallScale, myBallScale);
							ball.GetComponent<brick> ().myScale = myBallScale;
						}
					} else if (myBallScale == 0.4f) {
						myBallScale = 0.3f;
						foreach (GameObject ball in myBalls) {
							ball.transform.localScale = new Vector3 (myBallScale, myBallScale, myBallScale);
							ball.GetComponent<brick> ().myScale = myBallScale;
						}
					}
					foreach (Transform myBall in myBallsInTanban) {
						myBall.SetParent (myTanban.transform);
					}
					break;
				}
			case 8:
				{
					other.transform.Find ("skill_sound_source").GetComponent<SKill_Audio_Source> ().PlayAudio ("good");
					GameObject myTanban = GameObject.Find ("tanban");
					GameObject[] myBalls = GameObject.FindGameObjectsWithTag ("ball");
					foreach (GameObject ball in myBalls) {
						GameObject ball1 = GameObject.Instantiate (ball);
						if (ball.transform.parent) {
							ball1.transform.SetParent (myTanban.transform);
						}
						ball1.transform.localScale = ball.transform.localScale;
						ball1.transform.localPosition = ball.transform.localPosition + new Vector3 (-0.5f,0f,0f);
						ball1.GetComponent<Rigidbody> ().velocity = Quaternion.AngleAxis(-30f,new Vector3(0,0,-1f)) * ball.GetComponent<Rigidbody> ().velocity;
						ball1.GetComponent<brick> ().ball_speed = ball.GetComponent<brick> ().ball_speed;
						GameObject ball2 = GameObject.Instantiate (ball);
						if (ball.transform.parent) {
							ball2.transform.SetParent (myTanban.transform);
						}
						ball2.transform.localScale = ball.transform.localScale;
						ball2.transform.localPosition = ball.transform.localPosition + new Vector3 (0.5f,0f,0f);
						ball2.GetComponent<Rigidbody> ().velocity = Quaternion.AngleAxis(30f,new Vector3(0,0,-1f)) * ball.GetComponent<Rigidbody> ().velocity;
						ball2.GetComponent<brick> ().ball_speed = ball.GetComponent<brick> ().ball_speed;
					}
					break;
				}
			case 9:
				{
					other.transform.Find ("skill_sound_source").GetComponent<SKill_Audio_Source> ().PlayAudio ("good");
					myCamera.GetComponent<camera_1> ().life++;
					break;
				}
			case 10:
				{
					other.transform.Find ("skill_sound_source").GetComponent<SKill_Audio_Source> ().PlayAudio ("bad");
					GameObject[] myBalls = GameObject.FindGameObjectsWithTag ("ball");
					foreach (GameObject ball in myBalls) {
						Destroy (ball.gameObject);
					}
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
					GameObject myTanban = GameObject.Find ("tanban");
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
					break;
				}
			case 11:
				{
					other.transform.Find ("skill_sound_source").GetComponent<SKill_Audio_Source> ().PlayAudio ("good");
					GameObject[] myBricks = GameObject.FindGameObjectsWithTag ("brick");
					foreach (GameObject brick in myBricks) {
						showParticle ();
						Destroy (brick.gameObject);
					}
					break;
				}
			case 12:
				{
					other.transform.Find ("skill_sound_source").GetComponent<SKill_Audio_Source> ().PlayAudio ("good");
					GameObject myTanban = GameObject.Find ("tanban");
					myTanban.GetComponent<tanban> ().isStick = true;
					break;
				}
			case 13:
				{
					GameObject[] myBalls = GameObject.FindGameObjectsWithTag ("ball");
					for (int i = 1; i < myBalls.Length; i++) {
						Destroy (myBalls [i].gameObject);
					}
					break;
				}
			case 14:
				{
					GameObject[] myBricks = GameObject.FindGameObjectsWithTag ("brick");
					foreach (GameObject brick in myBricks) {
						brick.GetComponent<BoxCollider> ().isTrigger = false;
					}
					break;
				}
			default:
				break;
			}
			Destroy (this.gameObject);
		}

	}
	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "boarder" || other.gameObject.tag == "dead") {
			Destroy (this.gameObject);
		}
	}
	void showParticle(){
		GameObject myParticle = GameObject.Instantiate (particle);
		myParticle.transform.localPosition = this.gameObject.transform.position + new Vector3 (-1f, 0f, -0.5f);
		ParticleSystem myParticleSystem = myParticle.GetComponent<ParticleSystem> ();
		var main = myParticleSystem.main;
		Color myColor =  this.GetComponent<Renderer> ().material.color;
		myColor.a += 0.3f;
		if (myColor.a > 1f) {
			myColor.a = 1f;
		}
		main.startColor = myColor;
	}
}
