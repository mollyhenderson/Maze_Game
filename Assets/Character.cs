using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	public Vector3 speedVector;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.UpArrow)){
			transform.Translate(Vector3.forward / 50f);

			
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Translate(Vector3.left / 50f);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Translate(Vector3.right / 50f);
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			transform.Translate(Vector3.back / 50f);
		}

		if (Input.mousePosition.x > Screen.width - 300) {
			transform.Rotate (0f, 2f, 0f);
		}
		if (Input.mousePosition.x <300) {
			transform.Rotate (0f, -2f, 0f);
		}
	}
}
