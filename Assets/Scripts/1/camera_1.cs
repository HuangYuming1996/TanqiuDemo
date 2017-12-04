using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class camera_1 : MonoBehaviour {
	public GameObject exit_panel;
	public GameObject lose_panel;
	public GameObject win_panel;
	public GameObject brick_group;
	public GameObject winButton;
	public GameObject myTanban;
	public int brick_number;
	public int life;
	public bool isPanelShowing = false;
	public GameObject cube_Prefab;
	public float colorKuandu;
	int level_now;
	int level_count;
	// Use this for initialization
	void Start () {
		
		Time.timeScale = 1;
		exit_panel.SetActive (false);
		lose_panel.SetActive (false);
		win_panel.SetActive (false);
		Cursor.visible = false;
		level_count = PlayerPrefs.GetInt ("level_count", 0);
		level_now = PlayerPrefs.GetInt ("level_now", -1);
		if (level_now == level_count - 1) {
			winButton.transform.Find ("Text").GetComponent<Text> ().text = "已通关";
			winButton.GetComponent<Button> ().interactable = false;
		}
		if (level_now == -1) {   //加载默认关卡
			Vector4 colorPosition = new Vector4 (Random.Range (0f, 50f), Random.Range (0f, 50f), Random.Range (0f, 50f), Random.Range (0f, 50f));
			for (int i = 0; i < 16; i++) {
				for (int j = 0; j < 12; j++) {
					GameObject cube = Instantiate (cube_Prefab);
					cube.GetComponent<cube> ().myCubeKind = 1;
					cube.GetComponent<Renderer> ().material.color = new Color (
						Mathf.PerlinNoise (colorPosition.x + i * colorKuandu, colorPosition.x + j * colorKuandu), 
						Mathf.PerlinNoise (colorPosition.y + i * colorKuandu, colorPosition.y + j * colorKuandu),
						Mathf.PerlinNoise (colorPosition.z + i * colorKuandu, colorPosition.z + j * colorKuandu),
						Mathf.PerlinNoise (colorPosition.w + i * colorKuandu, colorPosition.w + j * colorKuandu));
					cube.transform.SetParent (brick_group.transform);
					cube.transform.localPosition = new Vector3 (-7.5f + i * 1f, 4.25f - j * 0.5f, 0);
				}
			}
		} else {
			for (int i = 0; i < 16; i++) {
				for (int j = 0; j < 12; j++) {
					GameObject cube = Instantiate (cube_Prefab);
					switch (PlayerPrefs.GetInt (level_now.ToString () + "_" + i.ToString () + "_" + j.ToString (),0)) {
					case 0:
						Destroy (cube.gameObject);
						break;
					case 1:
						cube.GetComponent<cube> ().myCubeKind = 1;
						cube.transform.SetParent (brick_group.transform);
						cube.transform.localPosition = new Vector3 (-7.5f + i * 1f, 4.25f - j * 0.5f, 0);
						break;
					case 2:
						cube.GetComponent<cube> ().myCubeKind = 2;
						cube.GetComponent<Renderer> ().material.color = Color.yellow;
						cube.transform.SetParent (brick_group.transform);
						cube.transform.localPosition = new Vector3 (-7.5f + i * 1f, 4.25f - j * 0.5f, 0);
						break;
					case 3:
						cube.GetComponent<cube> ().myCubeKind = 3;
						cube.GetComponent<Renderer> ().material.color = Color.magenta;
						cube.transform.SetParent (brick_group.transform);
						cube.transform.localPosition = new Vector3 (-7.5f + i * 1f, 4.25f - j * 0.5f, 0);
						break;
					case 4:
						cube.GetComponent<cube> ().myCubeKind = 4;
						cube.GetComponent<Renderer> ().material.color = Color.cyan;
						cube.transform.SetParent (brick_group.transform);
						cube.transform.localPosition = new Vector3 (-7.5f + i * 1f, 4.25f - j * 0.5f, 0);
						break;
					case 5:
						cube.GetComponent<cube> ().myCubeKind = 5;
						cube.GetComponent<Renderer> ().material.color = Color.green;
						cube.transform.SetParent (brick_group.transform);
						cube.transform.localPosition = new Vector3 (-7.5f + i * 1f, 4.25f - j * 0.5f, 0);
						break;
					case 6:
						cube.GetComponent<cube> ().myCubeKind = 6;
						cube.GetComponent<Renderer> ().material.color = Color.blue;
						cube.transform.SetParent (brick_group.transform);
						cube.transform.localPosition = new Vector3 (-7.5f + i * 1f, 4.25f - j * 0.5f, 0);
						break;
					case 7:
						cube.GetComponent<cube> ().myCubeKind = 7;
						cube.GetComponent<Renderer> ().material.color = Color.red ;
						cube.transform.SetParent (brick_group.transform);
						cube.transform.localPosition = new Vector3 (-7.5f + i * 1f, 4.25f - j * 0.5f, 0);
						break;
					case 8:
						cube.GetComponent<cube> ().myCubeKind = 8;
						cube.transform.SetParent (brick_group.transform);
						cube.transform.localPosition = new Vector3 (-7.5f + i * 1f, 4.25f - j * 0.5f, 0);
						break;
					case 9:
						cube.GetComponent<cube> ().myCubeKind = 9;
						cube.GetComponent<MeshRenderer> ().enabled = false;
						cube.transform.SetParent (brick_group.transform);
						cube.transform.localPosition = new Vector3 (-7.5f + i * 1f, 4.25f - j * 0.5f, 0);
						break;
					case 10:
						cube.GetComponent<Renderer> ().material.color = Color.black;
						cube.transform.localPosition = new Vector3 (-7.5f + i * 1f, 4.25f - j * 0.5f, 10);
						cube.GetComponent<cube> ().enabled = false;
						cube.tag = "black";
						break;
					default:
						break;
					}

				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		brick_number = brick_group.transform.childCount;
		if (brick_number == 0 && isPanelShowing == false) {   //win panel
			isPanelShowing = true;
			Cursor.visible = true;
			Time.timeScale = 0;
			win_panel.SetActive (true);
		}
		if (Input.GetKey (KeyCode.Escape ) && isPanelShowing == false) {   //exit panel
			isPanelShowing = true;
			Cursor.visible = true;
			Time.timeScale = 0;
			exit_panel.SetActive (true);
		}
		if (life <= 0 && isPanelShowing == false) {  // lose panel
			GetComponent<AudioSource>().Play();
			isPanelShowing = true;
			life = 3;
			Cursor.visible = true;
			Time.timeScale = 0;
			lose_panel.SetActive (true);
		}
	}
	public void contuniu_game(){
		isPanelShowing = false;
		Cursor.visible = false;
		Time.timeScale = 1;
	}
	void OnGUI(){
		GUILayout.Label ("LIFE:" + life);
		GUILayout.Label ("brick_left:" + brick_number);
		GameObject[] myBalls = GameObject.FindGameObjectsWithTag ("ball");
		foreach (GameObject ball in myBalls) {
			GUILayout.Label ("ball_speed:" + ball.GetComponent<Rigidbody> ().velocity.magnitude);
		}
		GUILayout.Label ("tanban_length:" + myTanban.GetComponent<tanban> ().length);
	}
	public void nextLevel(){
		if(level_now < level_count - 1){
			PlayerPrefs.SetInt("level_now",level_now + 1);
			SceneManager.LoadScene ("1");
		}
	}
}
