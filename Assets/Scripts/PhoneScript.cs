using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PhoneScript : MonoBehaviour {

	public Text							phoneText;
	public int							phoneState;
	public static string				ringing, script;
	public Canvas						alertCanvas;
	public AudioSource					ring;

	public bool							callIncoming;
	public bool							onCall;

	public SpriteRenderer				r;

	public static PhoneScript			S;

	// Use this for initialization
	void Start () {
		onCall = false;
		callIncoming = false;
		alertCanvas.enabled = false;
		ringing = "Answer Your Phone!";
		script = "Call script:\nHello, and thank you for calling Bizee.Com. My name is [Your Name]. How may I help you?";
		r = GetComponent<SpriteRenderer>();
		r.enabled = false;
		S = this;
	}

	void Update(){
		if (PlayerManager.S.gameState == 3) {
			if (callIncoming == true) {
				if (Input.GetKey (KeyCode.Alpha0)) {
					answerCall ();
				}
			}
			if(onCall){
				if (Input.GetKey (KeyCode.Alpha1)) {
					endCall ();
				}
			}
		}
	}

	public void phoneFlipped(){
		if(onCall) HangUp();
		if(callIncoming) Answered();
		else return;
	}

	public void answerCall() {
		if (!onCall && callIncoming)
			Answered ();
		else
			return;
	}

	public void endCall() {
		if (onCall)
			HangUp ();
		else
			return;
	}

	public void Ringing() {
		alertCanvas.enabled = true;
		ring.Play();
		r.enabled = true;
		phoneText.text = ringing;
		callIncoming = true;
	}

	public void Answered() {
		onCall = true;
		callIncoming = false;
		alertCanvas.enabled = true;
		ring.Stop();
		r.enabled = true;
		phoneText.text = script;

	}

	public void HangUp() {
		if(onCall){
			r.enabled = false;
			alertCanvas.enabled = false;
			onCall = false;
		}
	}
}

