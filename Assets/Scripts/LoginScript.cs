using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoginScript : MonoBehaviour {

	public Text				loginText;
	public Text 			userID;
	public Button			login;
	public Text				waiting;

	public bool				working;
	private string[]		names = new string[]
								{"shro_106", "joga_443", "amga_967", "hesm_502"};


	public static LoginScript		S;

	// Use this for initialization
	void Awake(){
		S = this;
		userID.text = names [PlayerManager.S.playerNum];
	}

	void Start () {
		Reset();
	}

	public void Ready() {
		loginText.text = "Ready";
		waiting.enabled = true;
		PlayerManager.S.playing = true;
		login.interactable = false;
	}
		
//	public void Go() {
//		working = true;
//	}
//
	public void Reset(){
		waiting.enabled = false;
		login.interactable = true;
		working = false;
	}

}
