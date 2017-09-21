using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class osScript : MonoBehaviour {

	public GameObject			go;
	public Text					inbox;
	public Text					from;

	private SpriteRenderer		sr;
	private int					playerNum;

	// Use this for initialization
	void Start () {
		playerNum = PlayerManager.S.playerNum;

		sr = go.GetComponent<SpriteRenderer> ();
		sr.sprite = Resources.Load<Sprite> ("wallpaper/"+playerNum);

		TextAsset ib = Resources.Load("inboxes/" + playerNum) as TextAsset;
		TextAsset fr = Resources.Load("inboxes/" + playerNum + "_from") as TextAsset;

		inbox.text = ib.text;
		from.text = fr.text;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
