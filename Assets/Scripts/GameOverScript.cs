using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverScript : MonoBehaviour {

	public int				winner;
	public Text				congratulationsText;

	//-----------------------------------------

	public static 			GameOverScript S;
	private int 			playerNum;

	// Use this for initialization
	void Start () {
		PlayerManager.S.gameState = 5;
		S = this;
		winner = CommunicationScript.S.winner;
		playerNum = PlayerManager.S.playerNum;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerNum == winner) {
			congratulationsText.text = "Congratulations! You have won the monthly bonus. Please pick up your fruitcake from Sharon at the front desk.";
		} else {
			congratulationsText.text = "Employee #" + winner.ToString () + " has won the monthly bonus. You should work on your productivity.";
		}
	}

	public void Reset(){
		GameManagementScript.S.Reset();
		SceneManager.LoadScene("Login");
	}

}
