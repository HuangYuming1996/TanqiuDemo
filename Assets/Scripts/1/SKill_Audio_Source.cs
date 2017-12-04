using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SKill_Audio_Source : MonoBehaviour {
	public AudioClip good;
	public AudioClip bad;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void PlayAudio(string clipname){
		switch(clipname){
		case "good":
			GetComponent<AudioSource> ().clip = good;
			break;
		case "bad":
			GetComponent<AudioSource> ().clip = bad;
			break;
		default:
			Debug.Log ("The audioClip name you input is not exiest");
			GetComponent<AudioSource> ().clip = good;
			break;
		}
		GetComponent<AudioSource> ().Play ();
	}
}
