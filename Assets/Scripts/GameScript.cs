using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameScript : MonoBehaviour {

	public static GameScript 	S;

	// Use this for initialization
	void Awake () {
		S = this;
		DontDestroyOnLoad(S);

		if (FindObjectsOfType(GetType()).Length > 1)
		{
			Destroy(gameObject);
		}
		SceneManager.LoadScene("Login");
	}
}
