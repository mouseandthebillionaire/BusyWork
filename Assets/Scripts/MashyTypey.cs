using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MashyTypey : MonoBehaviour {

	public float 			letterPause = 0.05f;

	public int				playerNum;
	string 					message;
	public Text 			textComp;
	public Button			snd;

	private int				currChar;
	private char[]			messageChars;
	public int				emails;

	public AudioSource		wrong;
	public GameObject		wrongImg;
	public Color[]			wrongColor;
	private SpriteRenderer	r;

	private string[]		signatures = new string[]{
		"Sharon Roberts\nInterpersonal Sales Associate\nBizee.Com", 
		"Joshua Garrison\nActing Team Leader, Sales Division\nBizee.Com", 
		"Amy Gable\nSales Associate Trainee\nBizee.Com", 
		"Hector Smith\nCustomer Satisfaction Taskforce Coordinator\nBizee.Com"
	};


	// Use this for initialization
	void Start () {
		playerNum = PlayerManager.S.playerNum;
		emails = 0;
		LoadMessage();
		r = wrongImg.GetComponent<SpriteRenderer>();
		r.color = wrongColor[0]; 
	}

	void Update () {
		//numEmails.text = emails.ToString();
		if(PlayerManager.S.playerState == 0){
			if(currChar+2 < message.Length){
				if(Input.anyKeyDown){
					if(Input.GetKeyDown(KeyCode.Alpha0)) return;
					else if(Input.GetKeyDown(KeyCode.Alpha1)) return;
					else if(Input.GetKeyDown(KeyCode.Backslash)) return;
					else {
						currChar+=2;
						StartCoroutine(TypeText());
					}
				}
			} else {
				PrepToSend();
			}
		} else if(PlayerManager.S.playerState == 1){
			if(Input.anyKeyDown){
				if(Input.GetKeyDown(KeyCode.Mouse0)) {
					// do nothing
					StartCoroutine(Error());
				}
			}
		}
		r.color = wrongColor[0];
	}

	IEnumerator Error () {
		r.color = wrongColor[1]; 
		wrong.Play();
		yield return new WaitForSeconds (0.75f);
		r.color = wrongColor[0]; 
		yield return null;
	}

	IEnumerator TypeText () {
		textComp.text = textComp.text + messageChars[currChar] + messageChars[currChar+1];
		yield return new WaitForSeconds (letterPause);
		yield return null;
	}

	void LoadMessage() {
		snd.gameObject.SetActive (false);

		int i = Random.Range (0, 10);
		if (i < 5) {
			int j = Random.Range (0, 4);
			TextAsset t = Resources.Load ("workEmails/email_" + j) as TextAsset;
			message = t.text + signatures [playerNum];
		} else {
			TextAsset t = Resources.Load ("emails/" + playerNum + "/0") as TextAsset;
			message = t.text;
		}
		currChar = -2;
		messageChars = message.ToCharArray();
		textComp.text = "";
	}

	void PrepToSend() {
		snd.gameObject.SetActive(true);
		if(Input.GetKeyDown(KeyCode.Return)){
			SendMessage();
		}
	}	

	public void SendMessage() {
		PlayerManager.S.emails++;
		if (PlayerManager.S.playerNum == 0) {
			GameManagementScript.S.score [0] = PlayerManager.S.emails;
		} else {
			CommunicationScript.S.UpdateScore (PlayerManager.S.emails);
		}
		LoadMessage();
	}

}
