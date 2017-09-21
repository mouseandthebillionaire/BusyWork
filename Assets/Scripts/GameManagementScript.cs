using UnityEngine;
using System.Collections;

public class GameManagementScript : MonoBehaviour {

	public int			gameState;
	public float		levelTime;
	public int 			numPlayers;
	public int[] 		score;

	private float		time;

	public static GameManagementScript	S;

	// Use this for initialization
	void Awake () {
		S = this;
		score = new int[numPlayers];
		Reset();
	}

	
	// Update is called once per frame
	void Update () {
		
		time = Time.timeSinceLevelLoad;

		if (PlayerManager.S.playerNum == 0 && gameState == 0) {
			if (Input.GetKeyDown ("escape")) {
				gameState = 1;
				CommunicationScript.S.SendState (gameState);
			}
		}

		if(gameState == 2){
			Debug.Log (time);
			if(time > levelTime){
				gameState = 4;
				int winner = WhoWon ();	
				CommunicationScript.S.SendGameOver (winner);
			}
		}	
	}

	public int WhoWon () {
		int max = score[0];
		int winner = 0;
		for (int i = 1; i < score.Length; i++) {
				if (score[i] > max) {
					max = score[i];
					winner = i;
				}
			}
		return winner;
	}

	public void Reset(){
		gameState = 0;
		time = 0;
		for (int i = 0; i < score.Length; i++) {
			score [i] = 0;
		}
	}
}
