using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneScript : MonoBehaviour {

	public static SceneScript	S;

	// Use this for initialization
	void Start () {
		S = this;
	}

	public void Loading(){
		SceneManager.LoadScene("Loading");
	}

	public void GameOver(){
		SceneManager.LoadScene("GameOver");
	}
}
