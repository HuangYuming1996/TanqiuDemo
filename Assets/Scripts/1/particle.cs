using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particle : MonoBehaviour {
	private ParticleSystem myParticleSyestem;
	// Use this for initialization
	void Start () {
		myParticleSyestem = this.GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (myParticleSyestem.isStopped) {
			Destroy (this.gameObject);
		}
	}
}
