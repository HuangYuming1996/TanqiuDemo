using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class cube_edit : MonoBehaviour {
	public int myCubeKind;
	public Vector2 position;
	GameObject myCamera;
	GameObject button_baocun;
	Vector3 randomColor ;

	// Use this for initialization
	void Start () {
		button_baocun = GameObject.Find ("baocun");
		myCamera = GameObject.Find ("Main Camera");
		randomColor = new Vector3 (Random.Range (0, 10f), Random.Range (0, 10f), Random.Range (0, 10f));
	}
	
	// Update is called once per frame
	void Update () {
		if (myCubeKind == 8) {
			this.GetComponent<Renderer> ().material.color = new Color (Mathf.PerlinNoise (Time.time, randomColor.x), Mathf.PerlinNoise (Time.time, randomColor.y), Mathf.PerlinNoise (Time.time, randomColor.z));
		}
	}
	void OnMouseDown(){
		if (myCamera.GetComponent<camera_editer> ().isPannelShow == false) {
			myCamera.GetComponent<camera_editer> ().isSaved = false;
			button_baocun.GetComponent<Button> ().interactable = true;
			int choose = myCamera.GetComponent<camera_editer> ().chooseCubeKind;
			switch (choose) {
			case 0:
				myCubeKind = 0;
				this.GetComponent<MeshRenderer> ().enabled = false;
				this.transform.Find ("yincang").GetComponent<SpriteRenderer> ().enabled = false;
				break;
			case 1:
				myCubeKind = 1;
				this.GetComponent<MeshRenderer> ().enabled = true;
				this.transform.Find ("yincang").GetComponent<SpriteRenderer> ().enabled = false;
				this.GetComponent<Renderer> ().material.color = Color.white;
				break;
			case 2:
				myCubeKind = 2;
				this.GetComponent<MeshRenderer> ().enabled = true;
				this.transform.Find ("yincang").GetComponent<SpriteRenderer> ().enabled = false;
				this.GetComponent<Renderer> ().material.color = Color.yellow;
				break;
			case 3:
				myCubeKind = 3;
				this.GetComponent<MeshRenderer> ().enabled = true;
				this.transform.Find ("yincang").GetComponent<SpriteRenderer> ().enabled = false;
				this.GetComponent<Renderer> ().material.color = Color.magenta;
				break;
			case 4:
				myCubeKind = 4;
				this.GetComponent<MeshRenderer> ().enabled = true;
				this.transform.Find ("yincang").GetComponent<SpriteRenderer> ().enabled = false;
				this.GetComponent<Renderer> ().material.color = Color.cyan;
				break;
			case 5:
				myCubeKind = 5;
				this.GetComponent<MeshRenderer> ().enabled = true;
				this.transform.Find ("yincang").GetComponent<SpriteRenderer> ().enabled = false;
				this.GetComponent<Renderer> ().material.color = Color.green;
				break;
			case 6:
				myCubeKind = 6;
				this.GetComponent<MeshRenderer> ().enabled = true;
				this.transform.Find ("yincang").GetComponent<SpriteRenderer> ().enabled = false;
				this.GetComponent<Renderer> ().material.color = Color.blue;
				break;
			case 7:
				myCubeKind = 7;
				this.GetComponent<MeshRenderer> ().enabled = true;
				this.transform.Find ("yincang").GetComponent<SpriteRenderer> ().enabled = false;
				this.GetComponent<Renderer> ().material.color = Color.red;
				break;
			case 8:
				myCubeKind = 8;
				this.GetComponent<MeshRenderer> ().enabled = true;
				this.transform.Find ("yincang").GetComponent<SpriteRenderer> ().enabled = false;
				break;
			case 9:
				myCubeKind = 9;
				this.GetComponent<MeshRenderer> ().enabled = true;
				this.transform.Find ("yincang").GetComponent<SpriteRenderer> ().enabled = true;
				break;
			case 10:
				myCubeKind = 10;
				this.GetComponent<MeshRenderer> ().enabled = true;
				this.transform.Find ("yincang").GetComponent<SpriteRenderer> ().enabled = false;
				this.GetComponent<Renderer> ().material.color = Color.black;
				break;
			default:
				break;
			}
		}
	}


	void OnMouseEnter(){
		if (Input.GetMouseButton (0)){
			if (myCamera.GetComponent<camera_editer> ().isPannelShow == false) {
				int choose = myCamera.GetComponent<camera_editer> ().chooseCubeKind;
				switch (choose) {
				case 0:
					myCubeKind = 0;
					this.GetComponent<MeshRenderer> ().enabled = false;
					this.transform.Find ("yincang").GetComponent<SpriteRenderer> ().enabled = false;
					break;
				case 1:
					myCubeKind = 1;
					this.GetComponent<MeshRenderer> ().enabled = true;
					this.transform.Find ("yincang").GetComponent<SpriteRenderer> ().enabled = false;
					this.GetComponent<Renderer> ().material.color = Color.white;
					break;
				case 2:
					myCubeKind = 2;
					this.GetComponent<MeshRenderer> ().enabled = true;
					this.transform.Find ("yincang").GetComponent<SpriteRenderer> ().enabled = false;
					this.GetComponent<Renderer> ().material.color = Color.yellow;
					break;
				case 3:
					myCubeKind = 3;
					this.GetComponent<MeshRenderer> ().enabled = true;
					this.transform.Find ("yincang").GetComponent<SpriteRenderer> ().enabled = false;
					this.GetComponent<Renderer> ().material.color = Color.magenta;
					break;
				case 4:
					myCubeKind = 4;
					this.GetComponent<MeshRenderer> ().enabled = true;
					this.transform.Find ("yincang").GetComponent<SpriteRenderer> ().enabled = false;
					this.GetComponent<Renderer> ().material.color = Color.cyan;
					break;
				case 5:
					myCubeKind = 5;
					this.GetComponent<MeshRenderer> ().enabled = true;
					this.transform.Find ("yincang").GetComponent<SpriteRenderer> ().enabled = false;
					this.GetComponent<Renderer> ().material.color = Color.green;
					break;
				case 6:
					myCubeKind = 6;
					this.GetComponent<MeshRenderer> ().enabled = true;
					this.transform.Find ("yincang").GetComponent<SpriteRenderer> ().enabled = false;
					this.GetComponent<Renderer> ().material.color = Color.blue;
					break;
				case 7:
					myCubeKind = 7;
					this.GetComponent<MeshRenderer> ().enabled = true;
					this.transform.Find ("yincang").GetComponent<SpriteRenderer> ().enabled = false;
					this.GetComponent<Renderer> ().material.color = Color.red;
					break;
				case 8:
					myCubeKind = 8;
					this.GetComponent<MeshRenderer> ().enabled = true;
					this.transform.Find ("yincang").GetComponent<SpriteRenderer> ().enabled = false;
					break;
				case 9:
					myCubeKind = 9;
					this.GetComponent<MeshRenderer> ().enabled = true;
					this.transform.Find ("yincang").GetComponent<SpriteRenderer> ().enabled = true;
					break;
				case 10:
					myCubeKind = 10;
					this.GetComponent<MeshRenderer> ().enabled = true;
					this.transform.Find ("yincang").GetComponent<SpriteRenderer> ().enabled = false;
					this.GetComponent<Renderer> ().material.color = Color.black;
					break;
				default:
					break;
				}
			}
		}
	}

}
