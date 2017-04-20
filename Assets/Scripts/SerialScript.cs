using UnityEngine;
using System;
using System.Collections;
using System.IO.Ports;

public class SerialScript : MonoBehaviour {

	public int			p0, p1, p2;

	public static SerialScript	S;

	SerialPort stream = new SerialPort("/dev/cu.usbmodem1411", 9600);

	public void Start(){
		S = this;
		stream.Open();
		p0 = 0;
		p1 = 0;
		p2 = 0;
	}

	void Update(){
		string input = stream.ReadLine();
		string[] values = input.Split(',');

		int tp0 = int.Parse(values[0]);
		if(tp0 != p0){
			p0 = tp0;
			ServerScript.S.SendPhone("p0", p0);
		}
		int tp1 = int.Parse(values[1]);
		if(tp1 != p1){
			p1 = tp1;
			ServerScript.S.SendPhone("p1", p1);
		}
		int tp2 = int.Parse(values[2]);
		if(tp2 != p2){
			p2 = tp2;
			ServerScript.S.SendPhone("p2", p2);
		}
	}
}