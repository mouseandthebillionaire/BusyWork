using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour {

	public float 			time;
	public float			currTime;
	public Image			loadingBar;
	private string			playerNum;
	private float			loadingBarSize;

	// Use this for initialization
	void Awake () {
		loadingBarSize = 0;
	}

	// Update is called once per frame
	void Update () {
		GameManagementScript.S.gameState = 2;
		playerNum = PlayerManager.S.playerNum.ToString();
		loadingBar.fillAmount = loadingBarSize;
		if(Time.timeSinceLevelLoad < time){
			loadingBarSize = Time.timeSinceLevelLoad / time;
		} else {
			SceneManager.LoadScene(playerNum);
		}
	}
}
