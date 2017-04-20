using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeScript : MonoBehaviour {

	public Image		panel;
	public float		fadeSpeed;
	public float		panelAlpha;
	private Image		img;

	// Use this for initialization
	void Start () {
		img = panel.GetComponent<Image>();
		panelAlpha = 2;
	}
	
	// Update is called once per frame
	void Update () {
		if(panelAlpha > 0){
			panelAlpha = (2 - Time.timeSinceLevelLoad);
			//panelAlpha = 125;
			img.color = new Color(img.color.r, img.color.g, img.color.b, panelAlpha);
		}
	}
}
