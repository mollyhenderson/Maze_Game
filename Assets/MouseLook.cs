using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//[AddComponentMenu("Camera-Control/Mouse Look")]
public class MouseLook : MonoBehaviour
{

		public enum RotationAxes
		{
				MouseXAndY = 0,
				MouseX = 1,
				MouseY = 2
		}
		public RotationAxes axes = RotationAxes.MouseXAndY;
		public float sensitivityX = 1F;
		public float sensitivityY = 1F;
		public float minimumX = -360F;
		public float maximumX = 360F;
		public float minimumY = -60F;
		public float maximumY = 60F;
		public Vector3 finishLoc;
		public GUIManager g;
		public GridCreator gc;
		public int level;
		private bool levelCompleted;
		float rotationY = 0F;

		void Update ()
		{
				if (!levelCompleted) {
						if (Input.GetKey (KeyCode.W)) {
								if (transform.localPosition.y < 1f) {
										transform.Translate (Vector3.forward / 50f);
								}
						}
						if (Input.GetKey (KeyCode.A)) {
								transform.Translate (Vector3.left / 50f);
						}
						if (Input.GetKey (KeyCode.D)) {
								transform.Translate (Vector3.right / 50f);
						}
						if (Input.GetKey (KeyCode.S)) {
								transform.Translate (Vector3.back / 50f);
						}

				

						
						if (Mathf.Abs (finishLoc.x - transform.localPosition.x) < .5f && Mathf.Abs (finishLoc.z - transform.localPosition.z) < .5f) {
				
								g.LevelCompleted ();
								levelCompleted = true;
								//Application.LoadLevel (0);
						}

						if (axes == RotationAxes.MouseXAndY) {
								float rotationX = transform.localEulerAngles.y + Input.GetAxis ("Mouse X") * sensitivityX;
			
								rotationY += Input.GetAxis ("Mouse Y") * sensitivityY;
								rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
			
								transform.localEulerAngles = new Vector3 (-rotationY, rotationX, 0);
						} else if (axes == RotationAxes.MouseX) {
								transform.Rotate (0, Input.GetAxis ("Mouse X") * sensitivityX, 0);
						} else {
								rotationY += Input.GetAxis ("Mouse Y") * sensitivityY;
								rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
								transform.localEulerAngles = new Vector3 (-rotationY, transform.localEulerAngles.y, 0);
						}
				} 
				if (levelCompleted) {
						if (transform.localPosition.y <= 6f) {
								rigidbody.useGravity = false;
								transform.Translate (0f, .01f, 0f);
								transform.Rotate (0f, 1f, 0f);
						} else {
								if (level < 3) {
										Application.LoadLevel (level);
								} else {
										Debug.Log ("Winner");
								}
						}
				}
			
		}
	
		void Start ()
		{
				finishLoc = new Vector3 (10f, 10f, 10f);
				levelCompleted = false;
				Screen.lockCursor = true;
				// Make the rigid body not change rotation
				if (rigidbody)
						rigidbody.freezeRotation = true;
		}
}