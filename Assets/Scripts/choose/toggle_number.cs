using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class toggle_number : MonoBehaviour {
	public GameObject button_jiazai;
	public GameObject button_bianji;
	public GameObject button_shanchu;
	public int number;
	// Use this for initialization
	void Start () {
		button_jiazai = GameObject.Find ("jiazai");
		button_bianji = GameObject.Find ("bianji");
		button_shanchu = GameObject.Find ("shanchu");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void setButtonChooseable(){
		button_bianji.GetComponent<Button> ().interactable = true;
		button_jiazai.GetComponent<Button> ().interactable = true;
		button_shanchu.GetComponent<Button> ().interactable = true;
	}
}
