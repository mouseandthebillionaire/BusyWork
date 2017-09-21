using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MessengerScript : MonoBehaviour {

	public GameObject			messenger;
	public SpriteRenderer		messengerSprite;
	public Canvas 				messengerCanvas;

	public bool					messengerActive;
	public float 				letterPause = 0.2f;

	public int					playerNum;
	public string 			    conversation;
	public string[]				messages;
	public string 				currMessage;
	public Text 				conversationDisplay;
	public Text					messageDisplay;
	public TextAsset			fullConversation;
	public Button				snd;
	public AudioSource			messengerAudio;
	public AudioClip[] 			messengerClips;

	private int					currChar;
	private int					currLine;
	private char[]				messageChars;

	private float				time;
	private float 				timeElapsed;
	private float messageTime;
	private float				t;
	private bool				responded;


	private string[]			names = new string[]{
		"\"Sharon\": ", 
		"\"J. Stevens\": ", 
		"\"Amy\": ", 
		"\"Hector\": "
	};

	private string[]			contactNames = new string[]{
		"\"Janet\": ", 
		"\"Josh\": ", 
		"\"Brenda Hoffbrau (HR)\": ", 
		"\"Steve\": "
	};
		
	// Use this for initialization
	void Start () {
		messenger.SetActive (false);
		messengerActive = false;
		currLine = 0;
		playerNum = PlayerManager.S.playerNum;
		int i = Random.Range (0, 3);
		fullConversation = Resources.Load("conversations/"+playerNum+"/"+ i) as TextAsset;
		messages = fullConversation.text.Split ('\n');
		responded = true;
		messageTime = 15;
		t = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if (!messengerActive) {
			messengerSprite.sortingOrder = 0;
			messengerCanvas.sortingOrder = 0;
		} else {
			messengerSprite.sortingOrder = 2;
			messengerCanvas.sortingOrder = 2;
		}

		timeElapsed = Time.timeSinceLevelLoad - t;
		if(timeElapsed > messageTime){
			StartCoroutine (UpdateConversation ());
			t = Time.timeSinceLevelLoad;
		}

		if (Input.GetKeyDown (KeyCode.Backslash)) {
			StartCoroutine (UpdateConversation ());
		}

		if(messengerActive){
			if(currChar < currMessage.Length){
				if(Input.anyKeyDown){
					if (Input.GetKeyDown (KeyCode.Alpha0))
						return;
					else if (Input.GetKeyDown (KeyCode.Alpha1))
						return;
					else if (Input.GetKeyDown (KeyCode.Backslash))
						return;
					else {
						currChar++;
						StartCoroutine (TypeText ());
					}
				}
			} else {
				PrepToSend();
			}
		} 
		
	}

	IEnumerator TypeText () {
		if (currChar <= currMessage.Length) {
			messageDisplay.text = messageDisplay.text + messageChars [currChar];
		}
		yield return new WaitForSeconds (letterPause);
		yield return null;
	}

	IEnumerator OpenWindow(){
		messengerActive = true;
		messenger.SetActive (true);
		PlayerManager.S.playerState = 2;
		snd.gameObject.SetActive (false);
		yield return null;
	}

	IEnumerator UpdateConversation () {
		if (!messengerActive) {
			StartCoroutine(OpenWindow ());
		}
		messengerAudio.PlayOneShot (messengerClips [0]);

		if (responded) {
			conversationDisplay.text = conversationDisplay.text + messages [currLine] + '\n';
			currMessage = messages [currLine + 1];
			currChar = -1;
			messageChars = currMessage.ToCharArray ();
			currLine++;
			responded = false;
		} else {
			StartCoroutine (NotResponding ());
		}
		yield return null;
	}

	IEnumerator NotResponding(){
		conversationDisplay.text = conversationDisplay.text + contactNames[playerNum] + " ...\n";
		yield return null;
	}



	void PrepToSend() {
		snd.gameObject.SetActive(true);
		if(Input.GetKeyDown(KeyCode.Return)){
			messengerAudio.PlayOneShot (messengerClips [1]);
			conversationDisplay.text = conversationDisplay.text + names[playerNum] + messages [currLine] + '\n';
			messageDisplay.text = "";
			messengerActive = false;
			currLine++;
			PlayerManager.S.playerState = 0;
			responded = true;
		}
	}

	public void CloseWindow(){
		messengerActive = false;
		messenger.SetActive (false);
		PlayerManager.S.playerState = 0;
	}


}
