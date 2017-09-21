using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommunicationScript : MonoBehaviour {

	public OSC[] 		osc;
	public int 			score;
	public int			winner;

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
			osc [playerNum + 1].SetAddressHandler ("/winner", OnReceiveGameOver);
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
		PlayerManager.S.gameState = state;
		message.address = "/state";
		message.values.Add (state);
		osc [0].Send (message);
		osc [1].Send (message);
	}

	public void SendGameOver(int whoWon){
		winner = whoWon;
		OscMessage message = new OscMessage ();
		message.address = "/winner";
		message.values.Add (winner);
		osc [0].Send (message);
		osc [1].Send (message);
		PlayerManager.S.gameState = 3;
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
		int state = message.GetInt (0);
		PlayerManager.S.gameState = state;
		Debug.Log (state);
	}

	void OnReceiveGameOver(OscMessage message){
		winner = message.GetInt (0);
		PlayerManager.S.gameState = 3;
	}
}
