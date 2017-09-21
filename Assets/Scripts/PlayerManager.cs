using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	public int		playerNum;
	public int		playerState;
	public int 		gameState;
	public int		emails;
	public bool		playing;
	public bool		binder;

	public Text		time;
	public Text 	emailScore;

	public static PlayerManager S;

	// Use this for initialization
	void Awake(){
		S = this;
	}

	void Start () {
		Reset();
		emailScore = GameObject.Find ("Global Canvas/#").GetComponent<Text>();
	}

	public void Popup(){
		int i = Random.Range(0, 4);
		if(i == 0) Calendar();
		if (i == 1) {
			if (!PhoneScript.S.onCall)
				Call ();
		}
		if(i == 2) Binder();
		if(i == 3) return;
		TimerScript.S.Reset();
	}

	public void Calendar() {
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
		gameState = 0;
		emails = 0;
		time.text = "";
	}

	public void Update(){
		if(gameState == 1){
			if (playing == true) {
				SceneScript.S.Loading ();
			} else {
				SceneScript.S.Out ();
			}
		}

		if (gameState == 3) {
			time.text = System.DateTime.Now.ToString("hh:mm:ss");
			emailScore.text = emails.ToString ();
		} else {
			time.text = "";
			emailScore.text = "";
		}

		if(gameState == 4){
			SceneScript.S.GameOver ();
		}
	}
}
