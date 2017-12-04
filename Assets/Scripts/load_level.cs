using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class load_level : MonoBehaviour {

	public void Load_level(string levelname){
		SceneManager.LoadScene (levelname);
	}
}
