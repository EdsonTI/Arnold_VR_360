using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// para  la rotacion del escritorio 
public class Mouse_look_gira_escritorio : MonoBehaviour {
	//  limites de la pantalla  y movimiento
	#if UNITY_EDITOR
	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float sensitivityX = 15F; //rotacion horisontal
	public float sensitivityY = 15F; // rotacion en vertical
	public float minimumX = -360F;
	public float maximumX = 360F;
	public float minimumY = -60F;
	public float maximumY = 60F;
	float rotationY = 0F;
	void Update()
	{
		// detecion del  punto en la pantalla con boton derecho
		if (Input.GetMouseButton (0)) {
			if (axes == RotationAxes.MouseXAndY) {
				float rotationX = transform.localEulerAngles.y + Input.GetAxis ("Mouse X") * sensitivityX;

				rotationY += Input.GetAxis ("Mouse Y") * sensitivityY; // rotacion en  vertical
				rotationY = Mathf.Clamp (rotationY, minimumY, maximumY); // limite

				transform.localEulerAngles = new Vector3 (-rotationY, rotationX, 0);
			} else if (axes == RotationAxes.MouseX) {
				transform.Rotate (0, Input.GetAxis ("Mouse X") * sensitivityX, 0); // rotacion horizontal 
			} else {
				rotationY += Input.GetAxis ("Mouse Y") * sensitivityY;
				rotationY = Mathf.Clamp (rotationY, minimumY, maximumY); // limite

				transform.localEulerAngles = new Vector3 (-rotationY, transform.localEulerAngles.y, 0);
			}
		}
	}

	#endif
}