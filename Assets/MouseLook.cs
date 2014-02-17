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

		float rotationY = 0F;

		void Update ()
		{

				if (Input.GetKey (KeyCode.W)) {
						transform.Translate (Vector3.forward / 75f);
				}
				if (Input.GetKey (KeyCode.A)) {
						transform.Translate (Vector3.left / 75f);
				}
				if (Input.GetKey (KeyCode.D)) {
						transform.Translate (Vector3.right / 75f);
				}
				if (Input.GetKey (KeyCode.S)) {
						transform.Translate (Vector3.back / 75f);
				}

						
				if (Mathf.Abs (finishLoc.x - transform.localPosition.x) < .5f && Mathf.Abs (finishLoc.z - transform.localPosition.z) < .5f) {
				
						g.LevelCompleted ();
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
	
		void Start ()
		{
				finishLoc = new Vector3 (10f, 10f, 10f);
				Screen.lockCursor = true;
				// Make the rigid body not change rotation
				if (rigidbody)
						rigidbody.freezeRotation = true;
		}
}