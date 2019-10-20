
using UnityEngine;
using System.Collections;
using UnityEngine.VR;
using UnityEngine.SceneManagement;

public class Mouselook : MonoBehaviour {

	// Use this for initialization
	// POSICION  RELATIVA DEL TOUCH 
	Vector2 touchDeltaPosition;
	public float sensibility = 0.5f;


	public float time=5;
	void Start () {

		Input.gyro.enabled = true;


	}

	// IDENTIFICAR  SI ESTA EN MODO  VR 
	void Update () {

		transform.localEulerAngles += new Vector3 (Input.gyro.rotationRateUnbiased.x, -Input.gyro.rotationRateUnbiased.y, 0);  // funcionamiento de giroscopio en nativo


		if (Input.GetButtonDown("Cancel")){ 

			SceneManager.LoadScene("Selecciondeinicio") ;}
		

		if (UnityEngine.XR.XRSettings.enabled)
			return;
		//-----------------------------------------------
		if (Input.touchCount == 1) {

			Touch touch = Input.GetTouch (0);

			if (touch.phase == TouchPhase.Moved) {

				touchDeltaPosition = Input.GetTouch (0).deltaPosition * sensibility; // IDENTIFICAR LA  POSOCION DE LOS DEDOS EN LA PANTALLA 

				gameObject.transform.eulerAngles += new Vector3 (touchDeltaPosition.y, -touchDeltaPosition.x, 0); // TRASA UN RECORRIDO DE UN  PUNTO A OTRO  SEGUN LO QUE SE PRESIONO EN LA PANTALLA
				//time = 10f;
			}
		}
	//	-----------------------------------------------
		/*else {
			time -= Time.deltaTime;

			if(time<=0)
				gameObject.transform.eulerAngles += Vector3.up * sensibility;
		}*/



	}


}