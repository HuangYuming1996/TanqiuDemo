using UnityEngine;
using System.Collections;

public class cube : MonoBehaviour {
	public GameObject particle;
	public float skill_chance;
	public GameObject skill;
	public int HP;
	public int myCubeKind;
	Vector3 randomColor;
	Vector3 ballSpeed;
	float random_skill_chance;
	// Use this for initialization
	void Start () {
		random_skill_chance = Random.value;
		randomColor = new Vector3 (Random.Range (0, 10f), Random.Range (0, 10f), Random.Range (0, 10f));
		if (myCubeKind == 1 || myCubeKind == 8) {
			HP = 1;
		} else if ((myCubeKind >= 2 && myCubeKind <= 4 ) || myCubeKind == 9) {
			HP = 2;
		} else if (myCubeKind >= 5 && myCubeKind <= 7) {
			HP = 3;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (myCubeKind == 8) {
			this.GetComponent<Renderer> ().material.color = new Color (Mathf.PerlinNoise (Time.time, randomColor.x), Mathf.PerlinNoise (Time.time, randomColor.y), Mathf.PerlinNoise (Time.time, randomColor.z));
		}
	}

	void OnCollisionEnter(Collision other){
		other.gameObject.GetComponent<AudioSource> ().Play ();
		HP--;
		ballSpeed = other.gameObject.GetComponent<Rigidbody> ().velocity;
		switch (myCubeKind) {
		case 1:
			if (random_skill_chance < skill_chance) {
				GameObject mySkill = GameObject.Instantiate (skill);
				mySkill.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, 9.3f);
				mySkill.GetComponent<skill_trigger> ().startSpeed.x = ballSpeed.x / 5;
			}
			showParticle ();
			Destroy (this.gameObject);
			break;
		case 2:
			if (HP == 1) {
				this.GetComponent<Renderer> ().material.color = new Color (1, 1, 0.5f);
			} else {
				if (random_skill_chance < skill_chance) {
					GameObject mySkill = GameObject.Instantiate (skill);
					mySkill.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, 9.3f);
					mySkill.GetComponent<skill_trigger> ().startSpeed.x = ballSpeed.x / 5;
				}
				showParticle ();
				Destroy (this.gameObject);
			}
			break;
		case 3:
			if (HP == 1) {
				this.GetComponent<Renderer> ().material.color = new Color (1, 0.5f,1);
			} else {
				if (random_skill_chance < skill_chance) {
					GameObject mySkill = GameObject.Instantiate (skill);
					mySkill.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, 9.3f);
					mySkill.GetComponent<skill_trigger> ().startSpeed.x = ballSpeed.x / 5;
				}
				showParticle ();
				Destroy (this.gameObject);
			}
			break;
		case 4:
			if (HP == 1) {
				this.GetComponent<Renderer> ().material.color = new Color (0.5f,1,1);
			} else {
				if (random_skill_chance < skill_chance) {
					GameObject mySkill = GameObject.Instantiate (skill);
					mySkill.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, 9.3f);
					mySkill.GetComponent<skill_trigger> ().startSpeed.x = ballSpeed.x / 5;
				}
				showParticle ();
				Destroy (this.gameObject);
			}
			break;
		case 5:
			if (HP == 1) {
				this.GetComponent<Renderer> ().material.color = new Color (0.7f, 1, 0.7f);
			} else if (HP == 2) {
				this.GetComponent<Renderer> ().material.color = new Color (0.3f, 1, 0.3f);
			}else{
				if (random_skill_chance < skill_chance) {
					GameObject mySkill = GameObject.Instantiate (skill);
					mySkill.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, 9.3f);
					mySkill.GetComponent<skill_trigger> ().startSpeed.x = ballSpeed.x / 5;
				}
				showParticle ();
				Destroy(this.gameObject);
			}
			break;
		case 6:
			if (HP == 1) {
				this.GetComponent<Renderer> ().material.color = new Color (0.7f,0.7f,1);
			} else if (HP == 2) {
				this.GetComponent<Renderer> ().material.color = new Color (0.3f,0.3f,1);
			}else{
				if (random_skill_chance < skill_chance) {
					GameObject mySkill = GameObject.Instantiate (skill);
					mySkill.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, 9.3f);
					mySkill.GetComponent<skill_trigger> ().startSpeed.x = ballSpeed.x / 5;
				}
				showParticle ();
				Destroy(this.gameObject);
			}
			break;
		case 7:
			if (HP == 1) {
				this.GetComponent<Renderer> ().material.color = new Color (1, 0.7f,0.7f);
			} else if (HP == 2) {
				this.GetComponent<Renderer> ().material.color = new Color (1, 0.3f,0.3f);
			}else{
				if (random_skill_chance < skill_chance) {
					GameObject mySkill = GameObject.Instantiate (skill);
					mySkill.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, 9.3f);
					mySkill.GetComponent<skill_trigger> ().startSpeed.x = ballSpeed.x / 5;
				}
				showParticle ();
				Destroy(this.gameObject);
			}
			break;
		case 8:
			{
				GameObject mySkill2 = GameObject.Instantiate (skill);
				mySkill2.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, 9.3f);
				mySkill2.GetComponent<skill_trigger> ().startSpeed.x = ballSpeed.x / 5;
				showParticle ();
				Destroy (this.gameObject);
			}
			break;
		case 9:
			if (HP == 1) {
				this.GetComponent<MeshRenderer> ().enabled = true;
			} else {
				if (random_skill_chance < skill_chance) {
					GameObject mySkill = GameObject.Instantiate (skill);
					mySkill.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, 9.3f);
					mySkill.GetComponent<skill_trigger> ().startSpeed.x = ballSpeed.x / 5;
				}
				showParticle ();
				Destroy (this.gameObject);
			}
			break;
		default:
			break;
		}

	}
	void OnTriggerStay(Collider other){
		if (other.tag == "ball" || (other.tag == "bullet" && this.GetComponent<BoxCollider>().isTrigger == true)) {
			HP--;
			if (HP == 1) {
				this.GetComponent<MeshRenderer> ().enabled = true;
			}
			if (HP == 0) {
				if (myCubeKind == 8) {
					GameObject mySkill = GameObject.Instantiate (skill);
					mySkill.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, 9.3f);
					mySkill.GetComponent<skill_trigger> ().startSpeed.x = ballSpeed.x / 5;
				} else if (random_skill_chance < skill_chance) {
					GameObject mySkill = GameObject.Instantiate (skill);
					mySkill.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, 9.3f);
					mySkill.GetComponent<skill_trigger> ().startSpeed.x = ballSpeed.x / 5;
				}
				showParticle ();
				Destroy (this.gameObject);
			}
		}
	}
	void OnTriggerEnter(Collider other){
		GameObject.FindGameObjectWithTag ("ball").GetComponent<AudioSource> ().Play ();
		if (other.tag == "bullet") {
			HP--;
			ballSpeed = other.gameObject.GetComponent<Rigidbody> ().velocity;
			switch (myCubeKind) {
			case 1:
				if (random_skill_chance < skill_chance) {
					GameObject mySkill = GameObject.Instantiate (skill);
					mySkill.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, 9.3f);
					mySkill.GetComponent<skill_trigger> ().startSpeed.x = ballSpeed.x / 5;
				}
				showParticle ();
				Destroy (this.gameObject);
				break;
			case 2:
				if (HP == 1) {
					this.GetComponent<Renderer> ().material.color = new Color (1, 1, 0.5f);
				} else {
					if (random_skill_chance < skill_chance) {
						GameObject mySkill = GameObject.Instantiate (skill);
						mySkill.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, 9.3f);
						mySkill.GetComponent<skill_trigger> ().startSpeed.x = ballSpeed.x / 5;
					}
					showParticle ();
					Destroy (this.gameObject);
				}
				break;
			case 3:
				if (HP == 1) {
					this.GetComponent<Renderer> ().material.color = new Color (1, 0.5f,1);
				} else {
					if (random_skill_chance < skill_chance) {
						GameObject mySkill = GameObject.Instantiate (skill);
						mySkill.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, 9.3f);
						mySkill.GetComponent<skill_trigger> ().startSpeed.x = ballSpeed.x / 5;
					}
					showParticle ();
					Destroy (this.gameObject);
				}
				break;
			case 4:
				if (HP == 1) {
					this.GetComponent<Renderer> ().material.color = new Color (0.5f,1,1);
				} else {
					if (random_skill_chance < skill_chance) {
						GameObject mySkill = GameObject.Instantiate (skill);
						mySkill.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, 9.3f);
						mySkill.GetComponent<skill_trigger> ().startSpeed.x = ballSpeed.x / 5;
					}
					showParticle ();
					Destroy (this.gameObject);
				}
				break;
			case 5:
				if (HP == 1) {
					this.GetComponent<Renderer> ().material.color = new Color (0.7f, 1, 0.7f);
				} else if (HP == 2) {
					this.GetComponent<Renderer> ().material.color = new Color (0.3f, 1, 0.3f);
				}else{
					if (random_skill_chance < skill_chance) {
						GameObject mySkill = GameObject.Instantiate (skill);
						mySkill.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, 9.3f);
						mySkill.GetComponent<skill_trigger> ().startSpeed.x = ballSpeed.x / 5;
					}
					showParticle ();
					Destroy(this.gameObject);
				}
				break;
			case 6:
				if (HP == 1) {
					this.GetComponent<Renderer> ().material.color = new Color (0.7f,0.7f,1);
				} else if (HP == 2) {
					this.GetComponent<Renderer> ().material.color = new Color (0.3f,0.3f,1);
				}else{
					if (random_skill_chance < skill_chance) {
						GameObject mySkill = GameObject.Instantiate (skill);
						mySkill.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, 9.3f);
						mySkill.GetComponent<skill_trigger> ().startSpeed.x = ballSpeed.x / 5;
					}
					showParticle ();
					Destroy(this.gameObject);
				}
				break;
			case 7:
				if (HP == 1) {
					this.GetComponent<Renderer> ().material.color = new Color (1, 0.7f,0.7f);
				} else if (HP == 2) {
					this.GetComponent<Renderer> ().material.color = new Color (1, 0.3f,0.3f);
				}else{
					if (random_skill_chance < skill_chance) {
						GameObject mySkill = GameObject.Instantiate (skill);
						mySkill.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, 9.3f);
						mySkill.GetComponent<skill_trigger> ().startSpeed.x = ballSpeed.x / 5;
					}
					showParticle ();
					Destroy(this.gameObject);
				}
				break;
			case 8:
				{
					GameObject mySkill2 = GameObject.Instantiate (skill);
					mySkill2.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, 9.3f);
					mySkill2.GetComponent<skill_trigger> ().startSpeed.x = ballSpeed.x / 5;
					showParticle ();
					Destroy (this.gameObject);
				}
				break;
			case 9:
				if (HP == 1) {
					this.GetComponent<MeshRenderer> ().enabled = true;
				} else {
					if (random_skill_chance < skill_chance) {
						GameObject mySkill = GameObject.Instantiate (skill);
						mySkill.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, 9.3f);
						mySkill.GetComponent<skill_trigger> ().startSpeed.x = ballSpeed.x / 5;
					}
					showParticle ();
					Destroy (this.gameObject);
				}
				break;
			default:
				break;
			}
			if (this.GetComponent<BoxCollider> ().isTrigger == false) {
				showParticle ();
				Destroy (other.gameObject);
			}
		}
	}
	void showParticle(){
		GameObject myParticle = GameObject.Instantiate (particle);
		myParticle.transform.localPosition = this.gameObject.transform.position + new Vector3 (-1f, 0f, -0.5f);
		ParticleSystem myParticleSystem = myParticle.GetComponent<ParticleSystem> ();
		var main = myParticleSystem.main;
		Color myColor =  this.GetComponent<Renderer> ().material.color;
		myColor.a += 0.5f;
		if (myColor.a > 1f) {
			myColor.a = 1f;
		}
		main.startColor = myColor;
	}
}
