using UnityEngine;
using System.Collections;

public class TimerScript : MonoBehaviour {

	public float			timeElapsed;
	public float			timeTilBW;
	public float			t;


	public static TimerScript S;

	// Use this for initialization
	void Start () {
		S = this;
		t = 0;
		timeTilBW = 20;
	}

	// Update is called once per frame
	void Update () {
		Debug.Log(timeElapsed);
		timeElapsed = Time.timeSinceLevelLoad - t;
		if(timeElapsed > timeTilBW){
			PlayerManager.S.Popup();
			timeTilBW -= 1;
		}
	}

	public void Reset() {
		t = Time.timeSinceLevelLoad;
	}
}
