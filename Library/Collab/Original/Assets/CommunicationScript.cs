using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommunicationScript : MonoBehaviour {

	public OSC[] 		osc;
	public int 			score;

	private int			playerNum;

	public static CommunicationScript S;

	// Use this for initialization
	void Start () {
		S = this;
		osc = GetComponentsInChildren<OSC>();
		playerNum = PlayerManager.S.playerNum;
		if (playerNum == 0) {
			osc [0].SetAddressHandler ("/score1", OnReceiveScore1);
			osc [1].SetAddressHandler ("/score2", OnReceiveScore2);
		} else {
			osc [playerNum + 1].SetAddressHandler ("/state", OnReceiveState);
			Debug.Log (playerNum + 1);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {
			score++;
			OscMessage message = new OscMessage ();
			message.address = "/score" + playerNum;
			message.values.Add (score);
			osc [playerNum - 1].Send (message);
		}
	
	}

	public void SendState(int state){
		OscMessage message = new OscMessage ();
		message.address = "/state";
		message.values.Add (state);
		osc [0].Send (message);
		osc [1].Send (message);
		Debug.Log (state);
	}

	public void UpdateScore(int score){
		OscMessage message = new OscMessage ();
		message.address = "/score" + playerNum;
		message.values.Add (score);
		osc [playerNum + 1].Send (message);
	}

	void OnReceiveScore1(OscMessage message){
		int x = message.GetInt (0);
		GameManagementScript.S.score [1]++;
		Debug.Log ("Employee #1: " + x);
	}

	void OnReceiveScore2(OscMessage message){
		int x = message.GetInt (0);
		Debug.Log ("Employee #2: " + x);
	}

	void OnReceiveState(OscMessage message){
		PlayerManager.S.gameState = message.GetInt (0);
	}
}
