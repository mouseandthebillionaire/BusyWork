using UnityEngine;
using System.Collections;

public class ServerScript : MonoBehaviour {

	public OscIn			oscIn;
	public OscOut			oscOut;

	public int				e0, e1, e2;

	public static ServerScript S;

	// Use this for initialization
	void Start () {
		S = this;
		oscIn = gameObject.GetComponentInChildren<OscIn>();
		oscOut = gameObject.GetComponentInChildren<OscOut>();
		oscIn.Open(7000);
		oscOut.Open(8000, "224.1.1.1");
		e0 = 0;
		e1 = 0;
		e2 = 0;
	}

	// Update is called once per frame
	void LateUpdate () {
		int state = GameManagementScript.S.gameState;
		oscOut.Send("/state", state);

		if(state == 0){
			oscIn.Map("/p0/playing", Playing);
			oscIn.Map("/p1/playing", Playing);
			oscIn.Map("/p2/playing", Playing);
		}

		oscIn.Map("/p0/emails", Tally0);
		oscIn.Map("/p1/emails", Tally1);
		oscIn.Map("/p2/emails", Tally2);

		if(state == 3){
			Score();
		}
	}	

	void Playing(bool value){
		if(!value) {
			return;
		}
		if(value) {
			GameManagementScript.S.gameState = 1;
		}
	}

	public void SendPhone(string name, int value){
		oscOut.Send("/phone/"+name, value);
	}

	void Tally0(int emails){
		if(emails != null) e0 = emails;
	}
	void Tally1(int emails){
		if(emails != null) e1 = emails;
	}
	void Tally2(int emails){
		if(emails != null) e2 = emails;
	}

	void Score(){
		int i = 0;
		if(e0 > e1 && e0 > e2) i = 0;
		if(e1 > e0 && e1 > e2) i = 1;
		if(e2 > e1 && e2 > e0) i = 2;
		GameOverScript.S.winner = i;
	}

		


}
