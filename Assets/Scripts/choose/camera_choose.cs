using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class camera_choose : MonoBehaviour {
	public GameObject toggle_group;
	public GameObject toggle_prefab;
	public GameObject button_jiazai;
	public GameObject button_bianji;
	public GameObject button_shanchu;
	public GameObject Panel_shanchu;
	int level_count;
	// Use this for initialization
	void Start () {
		Panel_shanchu.SetActive (false);
		button_bianji.GetComponent<Button>().interactable = false;
		button_jiazai.GetComponent<Button>().interactable  =false;
		button_shanchu.GetComponent<Button>().interactable  =false;
		level_count = PlayerPrefs.GetInt ("level_count", 0);
		for (int i = 0; i < level_count; i++) {
			GameObject mytoggle = Instantiate (toggle_prefab);
			mytoggle.GetComponent<toggle_number> ().number = i;
			mytoggle.transform.Find ("Label").gameObject.GetComponent<Text> ().text = i.ToString () + ":" + PlayerPrefs.GetString ("level_" + i.ToString (), "ERROR");
			mytoggle.transform.SetParent (toggle_group.transform);
			mytoggle.GetComponent<Toggle> ().group = toggle_group.GetComponent<ToggleGroup>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Escape)) {
			SceneManager.LoadScene ("start");
		}
	}
	public void xinjian(){
		if (level_count == 0) {
			PlayerPrefs.SetInt ("level_now", 0);
		} else {
			PlayerPrefs.SetInt ("level_now", level_count);
		}
		SceneManager.LoadScene("editer");
	}
	public void bianji(){
		foreach (Transform child in toggle_group.transform) {
			if (child.GetComponent<Toggle> ().isOn == true) {
				PlayerPrefs.SetInt ("level_now", child.GetComponent<toggle_number> ().number);
			}
		}
		SceneManager.LoadScene ("editer");
	}
	public void jiazai(){
		foreach (Transform child in toggle_group.transform) {
			if (child.GetComponent<Toggle> ().isOn == true) {
				PlayerPrefs.SetInt ("level_now", child.GetComponent<toggle_number> ().number);
			}
		}
		SceneManager.LoadScene ("1");
	}
	public void shanchu(){
		int level_now = -1;
		foreach (Transform child in toggle_group.transform) {
			if (child.GetComponent<Toggle> ().isOn == true) {
				level_now = child.GetComponent<toggle_number> ().number;
			}
		}
		PlayerPrefs.DeleteKey ("level_" + level_now.ToString());
		for (int i = 0; i < 16; i++) {
			for (int j = 0; j < 12; j++) {
				PlayerPrefs.DeleteKey (level_now.ToString () + "_" + i.ToString () + "_" + j.ToString ());
			}
		}   //都删完了

		for(int a = level_now; a < level_count - 1; a++){
			PlayerPrefs.SetString ("level_" + a.ToString (), PlayerPrefs.GetString ("level_" + (a + 1).ToString (), "NULL"));
			for (int i = 0; i < 16; i++) {
				for (int j = 0; j < 12; j++) {
					PlayerPrefs.SetInt (a.ToString () + "_" + i.ToString () + "_" + j.ToString (), PlayerPrefs.GetInt ((a + 1).ToString () + "_" + i.ToString () + "_" + j.ToString (), 0));
				}
			}
		}// 都移动完了
		PlayerPrefs.SetInt("level_count",level_count - 1);
		SceneManager.LoadScene ("choose");


	}
}
