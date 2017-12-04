using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAudioControl : MonoBehaviour {
	public AudioClip move;
	public AudioClip choose;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void PlayAudion(string name){
		if (name.Equals ("move")) {
			this.GetComponent<AudioSource> ().PlayOneShot (move);
		} else if (name.Equals ("choose")) {
			this.GetComponent<AudioSource> ().PlayOneShot (choose);
			GameObject.Destroy (this.gameObject, 5f);
		}
	}
}
