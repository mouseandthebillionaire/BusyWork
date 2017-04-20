using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PopupScript : MonoBehaviour {

	public Text							alertText;
	public static string				alert;
	public Canvas						alertCanvas;
	public static bool					popped;
	public float						minX, minY, maxX, maxY;

	public Text 						alertButton;
	public AudioSource					alertSound;
	public string[]						alertButtonText;

	//-----------------------------------------------

	private SpriteRenderer				r;
	private int							i;
	private bool						done;

	public static PopupScript			S;

	// Use this for initialization
	void Start () {
		done = true;
		S = this;
		r = GetComponent<SpriteRenderer>();
		Clicked();
		i = 0;
		GameManagementScript.S.gameState = 2;
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void Popup(string s) {
		if(done){
			done = false;
			this.transform.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
			alertCanvas.enabled = true;
			r.enabled = true;
			if(s == "calendar"){
				TextAsset t = Resources.Load("alert_" + i) as TextAsset;
				alert = t.text;
				alertButton.text = alertButtonText[i];
			}
			if(s == "binder"){
				var v = Random.Range(0, 2);
				if(v == 0) alert = "Please get the quarterly report from wheverer it is and bring it to your station for approval.";
				if(v == 1) alert = "Please retrieve the quarterly report from wheverer it is and place it on the mail cart.";
				alertButton.text = "Done";
			}
			alertText.text = alert;
			alertSound.Play();
		}
	}

	public void Clicked() {
		r.enabled = false;
		alertCanvas.enabled = false;
		PlayerManager.S.playerState = 0;
		done = true;
		i++;
	}
}

/*
  void OnMouseDown(){
		Debug.Log("clicked");
		GetComponent<SpriteRenderer>().enabled = false;
		Timer.t = Time.time;
		GameManager.playerState = 0;
	}
	*/
