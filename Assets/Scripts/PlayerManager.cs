using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	public int		playerNum;
	public int		playerState;
	public int		emails;
	public bool		playing;
	public bool		binder;

	public static PlayerManager S;

	// Use this for initialization
	void Awake(){
		S = this;
	}

	void Start () {
		Reset();
	}

	public void Go(){
		playing = true;
		ClientScript.S.SendPlaying();
	}

	public void Popup(){
		int i = Random.Range(0, 4);
		if(i == 0) Calendar();
		if(i == 1) Call();
		if(i == 2) Binder();
		if(i == 3) return;
		TimerScript.S.Reset();
		Debug.Log("popped!");

	}

	void Calendar() {
		PopupScript.S.Popup("calendar");
		playerState = 1;
	}

	void Call() {
		PhoneScript.S.Ringing();
	}

	void Binder() {
		PopupScript.S.Popup("binder");
		playerState = 1;
	}

	public void Reset(){
		playing = false;
		playerState = 0;
		GameManagementScript.S.gameState = 0;
		emails = 0;
	}

	public void Update(){
		if(Input.GetKeyDown(KeyCode.Escape)) PhoneScript.S.phoneFlipped();
	}
		
}
