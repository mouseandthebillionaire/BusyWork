using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MashyTypey : MonoBehaviour {

	public float letterPause = 0.2f;

	public int				playerNum;
	string 					message;
	public Text 			textComp;
	public Text				numEmails;
	public Button			snd;

	private int				currChar;
	private char[]			messageChars;
	public int				emails;

	public AudioSource		wrong;
	public GameObject		wrongImg;
	public Color[]			wrongColor;
	private SpriteRenderer	r;


	// Use this for initialization
	void Start () {
		emails = 0;
		LoadMessage();
		r = wrongImg.GetComponent<SpriteRenderer>();
		r.color = wrongColor[0]; 
		playerNum = PlayerManager.S.playerNum;
	}

	void Update () {
		numEmails.text = emails.ToString();
		if(PlayerManager.S.playerState == 0){
			if(currChar < message.Length){
				if(Input.anyKeyDown){
					currChar++;
					StartCoroutine(TypeText());
				}
			} else {
				PrepToSend();
			}
		} else if(PlayerManager.S.playerState == 1){
			if(Input.anyKeyDown){
				if(Input.GetKeyDown(KeyCode.Mouse0)) {
					// do nothing
				} else {
					StartCoroutine(Error());
				}
			}
		}
		//r.color = wrongColor[0];
	}

	IEnumerator Error () {
		r.color = wrongColor[1]; 
		wrong.Play();
		yield return new WaitForSeconds (0.75f);
		r.color = wrongColor[0]; 
		yield return null;
	}

	IEnumerator TypeText () {
		textComp.text = textComp.text + messageChars[currChar];
		yield return new WaitForSeconds (letterPause);
		yield return null;
	}

	void LoadMessage() {
		snd.gameObject.SetActive(false);
		int i = (playerNum * 5) + Random.Range(0, 4);
		TextAsset t = Resources.Load("email_" + i) as TextAsset;
		message = t.text;
		currChar = -1;
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
		LoadMessage();
		PlayerManager.S.emails++;
	}

}
