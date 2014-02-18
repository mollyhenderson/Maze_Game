using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {

	public GUIText gameStartText, levelText, levelCompletedText;
	public GUITexture loadingScreen;
	public GUITexture crossHair;
	public MouseLook m;

	// Use this for initialization
	void Start () {
		crossHair.enabled = false;
	}

	public void GameStart() {
		levelText.enabled = false;
		gameStartText.enabled = false;
		levelCompletedText.enabled = false;
		loadingScreen.enabled = false;
		crossHair.enabled = true;
	}

	public void LevelCompleted() {
		levelCompletedText.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
