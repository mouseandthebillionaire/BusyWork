using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class ClientScript : MonoBehaviour {

	public OscIn				oscIn;
	public OscOut				oscOut;

	private string				playerName;

	public static ClientScript	S;

	// Use this for initialization
	void Awake () {
		S = this;
		oscIn = gameObject.GetComponentInChildren<OscIn>();
		oscOut = gameObject.GetComponentInChildren<OscOut>();
		oscIn.Open(8000, "224.1.1.1");
	}

	void Start() {
		oscIn = gameObject.GetComponentInChildren<OscIn>();
		oscOut = gameObject.GetComponentInChildren<OscOut>();
		playerName = "/p" + PlayerManager.S.playerNum.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		oscIn.Map("/state", StateMachine);
		if(GameManagementScript.S.gameState == 2){
			oscIn.Map("/phone"+playerName, PhoneControl);
		}
	}

	public void SendPlaying(){
		oscOut.Send(playerName+"/playing", true);
		Debug.Log(playerName);
	}

	void StateMachine(int value){
		GameManagementScript.S.gameState = value;
	}

	void PhoneControl(int value){
		PhoneScript.S.phoneFlipped();
	}

	public void SendScore(int emails){
		oscOut.Send(playerName+"/emails", emails);
	}

}
