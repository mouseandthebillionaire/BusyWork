using UnityEngine;
using System.Collections;

public class GameManagementScript : MonoBehaviour {

	public int		gameState;
	public float	levelTime;

	private float	time;

	public static GameManagementScript	S;

	// Use this for initialization
	void Awake () {
		S = this;
		Reset();
	}

	
	// Update is called once per frame
	void Update () {
		time = Time.timeSinceLevelLoad;

		if(gameState == 1){
			SceneScript.S.Loading();
		}

		if(gameState == 2){
			if(time > levelTime){
				gameState = 3;
				SceneScript.S.GameOver();
			}
		}	
	}

	public void Reset(){
		gameState = 0;
		time = 0;
	}
}
