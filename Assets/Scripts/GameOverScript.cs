using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverScript : MonoBehaviour {

	public int				winner;
	public Text				congratulationsText;

	//-----------------------------------------

	public static GameOverScript S;

	// Use this for initialization
	void Start () {
		S = this;
		ClientScript.S.SendScore(PlayerManager.S.emails);
	}
	
	// Update is called once per frame
	void Update () {
		congratulationsText.text = "Employee #"+winner.ToString()+" has won the monthly bonus. Please pick up your fruitcake from Sharon at the front desk.";
	}

	public void Reset(){
		GameManagementScript.S.Reset();
		SceneManager.LoadScene("Login");
	}

}
