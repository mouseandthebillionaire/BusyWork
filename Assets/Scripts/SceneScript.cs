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
		PlayerManager.S.gameState = 2;
	}

	public void Out(){
		SceneManager.LoadScene("OutOfOffice");
	}

	public void GameOver(){
		SceneManager.LoadScene("GameOver");
	}
}
