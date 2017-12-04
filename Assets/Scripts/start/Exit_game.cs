using UnityEngine;
using System.Collections;

public class Exit_game : MonoBehaviour {

	public void exitgame(){
		Application.Quit ();
	}
	public void MoRenGuanQia(){
		PlayerPrefs.SetInt ("level_now", -1);
	}
}
