using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class camera_editer : MonoBehaviour {
	public bool isSaved;
	public GameObject button_baocun;
	public GameObject baocun_panel;
	public GameObject cubeEdit;
	public GameObject cubeGroup;
	public GameObject inputName;
	public int chooseCubeKind;

	public GameObject exitPanel;
	public bool isPannelShow;

	public GameObject cube_bai;
	public GameObject cube_huang;
	public GameObject cube_zi;
	public GameObject cube_lanlv;
	public GameObject cube_lv;
	public GameObject cube_lan;
	public GameObject cube_hong;
	public GameObject cube_bianse;
	public GameObject cube_hei;

	Vector3 randomColor ;

	// Use this for initialization
	void Start () {
		baocun_panel.SetActive (false);
		isSaved = true;
		isPannelShow = false;
		Time.timeScale = 1;
		randomColor = new Vector3 (Random.Range (0, 10f), Random.Range (0, 10f), Random.Range (0, 10f));
		cube_bai.GetComponent<Renderer> ().material.color = Color.white;
		cube_huang.GetComponent<Renderer> ().material.color = Color.yellow;
		cube_zi.GetComponent<Renderer> ().material.color = Color.magenta;
		cube_lanlv.GetComponent<Renderer> ().material.color = Color.cyan;
		cube_lv.GetComponent<Renderer> ().material.color = Color.green;
		cube_lan.GetComponent<Renderer> ().material.color = Color.blue;
		cube_hong.GetComponent<Renderer> ().material.color = Color.red;
		cube_hei.GetComponent<Renderer> ().material.color = Color.black;
	
		exitPanel.SetActive (false);

		int level_count = PlayerPrefs.GetInt ("level_count", 0);
		int level_now = PlayerPrefs.GetInt ("level_now", -1);



		if (level_now == level_count) {
			for (int i = 0; i < 16; i++) {  //新建，全是默认砖块
				for (int j = 0; j < 12; j++) {
					GameObject cube = Instantiate (cubeEdit);
					cube.GetComponent<cube_edit> ().position = new Vector2 (i, j);
					cube.transform.SetParent (cubeGroup.transform);
					cube.transform.localPosition = new Vector3 (-7.5f + i * 1f, 4.25f - j * 0.5f, 0);
				}
			}
		} else {     // 加载以前的关卡，根据存储的数据加载砖块
			inputName.GetComponent<InputField> ().text = PlayerPrefs.GetString ("level_" + level_now, "ERROR");
			for (int i = 0; i < 16; i++) {
				for (int j = 0; j < 12; j++) {
					GameObject cube = Instantiate (cubeEdit);
					cube.GetComponent<cube_edit> ().position = new Vector2 (i, j);

					switch (PlayerPrefs.GetInt(level_now.ToString() + "_" + i.ToString() + "_" + j.ToString(),-1)) {
					case 0:
						cube.GetComponent<cube_edit>().myCubeKind = 0;
						cube.GetComponent<MeshRenderer> ().enabled = false;
						cube.transform.Find ("yincang").GetComponent<SpriteRenderer> ().enabled = false;
						break;
					case 1:
						cube.GetComponent<cube_edit>().myCubeKind = 1;
						cube.GetComponent<MeshRenderer> ().enabled = true;
						cube.transform.Find ("yincang").GetComponent<SpriteRenderer> ().enabled = false;
						cube.GetComponent<Renderer> ().material.color = Color.white;
						break;
					case 2:
						cube.GetComponent<cube_edit>().myCubeKind = 2;
						cube.GetComponent<MeshRenderer> ().enabled = true;
						cube.transform.Find ("yincang").GetComponent<SpriteRenderer> ().enabled = false;
						cube.GetComponent<Renderer> ().material.color = Color.yellow;
						break;
					case 3:
						cube.GetComponent<cube_edit>().myCubeKind = 3;
						cube.GetComponent<MeshRenderer> ().enabled = true;
						cube.transform.Find ("yincang").GetComponent<SpriteRenderer> ().enabled = false;
						cube.GetComponent<Renderer> ().material.color = Color.magenta;
						break;
					case 4:
						cube.GetComponent<cube_edit>().myCubeKind = 4;
						cube.GetComponent<MeshRenderer> ().enabled = true;
						cube.transform.Find ("yincang").GetComponent<SpriteRenderer> ().enabled = false;
						cube.GetComponent<Renderer> ().material.color = Color.cyan;
						break;
					case 5:
						cube.GetComponent<cube_edit>().myCubeKind = 5;
						cube.GetComponent<MeshRenderer> ().enabled = true;
						cube.transform.Find ("yincang").GetComponent<SpriteRenderer> ().enabled = false;
						cube.GetComponent<Renderer> ().material.color = Color.green;
						break;
					case 6:
						cube.GetComponent<cube_edit>().myCubeKind = 6;
						cube.GetComponent<MeshRenderer> ().enabled = true;
						cube.transform.Find ("yincang").GetComponent<SpriteRenderer> ().enabled = false;
						cube.GetComponent<Renderer> ().material.color = Color.blue;
						break;
					case 7:
						cube.GetComponent<cube_edit>().myCubeKind = 7;
						cube.GetComponent<MeshRenderer> ().enabled = true;
						cube.transform.Find ("yincang").GetComponent<SpriteRenderer> ().enabled = false;
						cube.GetComponent<Renderer> ().material.color = Color.red;
						break;
					case 8:
						cube.GetComponent<cube_edit>().myCubeKind = 8;
						cube.GetComponent<MeshRenderer> ().enabled = true;
						cube.transform.Find ("yincang").GetComponent<SpriteRenderer> ().enabled = false;
						break;
					case 9:
						cube.GetComponent<cube_edit>().myCubeKind = 9;
						cube.GetComponent<MeshRenderer> ().enabled = true;
						cube.transform.Find ("yincang").GetComponent<SpriteRenderer> ().enabled = true;
						break;
					case 10:
						cube.GetComponent<cube_edit>().myCubeKind = 10;
						cube.GetComponent<MeshRenderer> ().enabled = true;
						cube.transform.Find ("yincang").GetComponent<SpriteRenderer> ().enabled = false;
						cube.GetComponent<Renderer> ().material.color = Color.black;
						break;
					default:
						break;
					}

					cube.transform.SetParent (cubeGroup.transform);
					cube.transform.localPosition = new Vector3 (-7.5f + i * 1f, 4.25f - j * 0.5f, 0);
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		cube_bianse.GetComponent<Renderer> ().material.color = new Color (Mathf.PerlinNoise (Time.time, randomColor.x), Mathf.PerlinNoise (Time.time, randomColor.y), Mathf.PerlinNoise (Time.time, randomColor.z));
		if (Input.GetKey (KeyCode.Escape)) {
			exitPanel.SetActive (true);
			isPannelShow = true;
		}
	}
	public void esc(){
		exitPanel.SetActive (true);
		isPannelShow = true;
	}
	public void save(){
		isPannelShow = true;
		isSaved = true;
		button_baocun.GetComponent<Button> ().interactable = false;
		baocun_panel.SetActive (true);
		int level_count = PlayerPrefs.GetInt ("level_count", 0);
		int level_now = PlayerPrefs.GetInt ("level_now", 0);
		PlayerPrefs.SetString ("level_" + level_now.ToString (), inputName.GetComponent<InputField> ().text);
		foreach (Transform child in cubeGroup.transform) {
			Vector2 myPosition = child.GetComponent<cube_edit> ().position;
			PlayerPrefs.SetInt (level_now.ToString () + "_" + myPosition.x.ToString () + "_" + myPosition.y.ToString (),child.GetComponent<cube_edit>().myCubeKind);
		}

		if (level_count == level_now) {
			level_count++;
			PlayerPrefs.SetInt ("level_count", level_count);
		}
	}
	public void closePannel(){
		isPannelShow = false;
	}
}
