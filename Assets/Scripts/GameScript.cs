using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameScript : MonoBehaviour {

	public static GameScript 	S;
	public GameObject			manager;

	// Use this for initialization
	void Awake () {
		S = this;
		DontDestroyOnLoad(S);

		// remove GameManager if not the master compy
		if (PlayerManager.S.playerNum != 0) {
			manager.SetActive (false);
		}

		if (FindObjectsOfType(GetType()).Length > 1)
		{
			Destroy(gameObject);
		}
		SceneManager.LoadScene("Login");
	}
}
