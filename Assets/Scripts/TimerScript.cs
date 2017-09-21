using UnityEngine;
using System.Collections;

public class TimerScript : MonoBehaviour {

	public float			interruptTimeElapsed;
	public float			interruptTime;
	private float			t;


	public static TimerScript S;

	// Use this for initialization
	void Start () {
		S = this;
		t = 0;
		interruptTime = 20;
	}

	// Update is called once per frame
	void Update () {

		// Interrupt
		interruptTimeElapsed = Time.timeSinceLevelLoad - t;
		if(interruptTimeElapsed > interruptTime){
			PlayerManager.S.Popup();
			interruptTime -= .5f;
		}
	}

	public void Reset() {
		t = Time.timeSinceLevelLoad;
	}
}
