﻿using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other){
		if (other.tag == "boarder") {
			Destroy (this.gameObject);
		}
	}
}
