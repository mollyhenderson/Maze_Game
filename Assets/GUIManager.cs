using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {

	public GUIText gameStartText, levelText;
	public GUITexture loadingScreen;
	public GUITexture crossHair;

	// Use this for initialization
	void Start () {
		crossHair.enabled = false;
	}

	public void GameStart() {
		levelText.enabled = false;
		gameStartText.enabled = false;
		loadingScreen.enabled = false;
		crossHair.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
