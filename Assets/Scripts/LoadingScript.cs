using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour {

	public float 			time;
	public float			currTime;
	public Image			loadingBar;
	private int				playerNum;
	private float			loadingBarSize;

	// Use this for initialization
	void Awake () {
		loadingBarSize = 0;
		playerNum = PlayerManager.S.playerNum;
	}

	// Update is called once per frame
	void Update () {
		PlayerManager.S.gameState = 2;
		loadingBar.fillAmount = loadingBarSize;
		if(Time.timeSinceLevelLoad < time){
			loadingBarSize = Time.timeSinceLevelLoad / time;
		} else {
			if (playerNum == 0) {
				CommunicationScript.S.SendState (3);
				GameManagementScript.S.gameState = 3;
			} 
			PlayerManager.S.gameState = 3;
			SceneManager.LoadScene("Main");
	
		}
	}
}
