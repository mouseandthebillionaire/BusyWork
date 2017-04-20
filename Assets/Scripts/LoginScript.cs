using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoginScript : MonoBehaviour {

	public Text				loginText;
	public Button			login;
	public Text				waiting;
	public Button			go;

	public bool				working;

	public static LoginScript		S;

	// Use this for initialization
	void Awake(){
		S = this;
	}

	void Start () {
		Reset();
		go.onClick.AddListener(() => { PlayerManager.S.Go(); });
	}

	public void Ready() {
		loginText.text = "Ready";
		waiting.enabled = true;
		go.gameObject.SetActive(true);
		login.interactable = false;
	}
		
	public void Go() {
		working = true;
	}

	public void Reset(){
		waiting.enabled = false;
		go.gameObject.SetActive(false);
		go.interactable = true;
		login.interactable = true;
		working = false;
	}

}
