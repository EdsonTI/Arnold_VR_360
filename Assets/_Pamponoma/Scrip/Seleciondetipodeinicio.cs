using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;
using UnityEngine.SceneManagement;

public class Seleciondetipodeinicio : MonoBehaviour {


	void Start (){
		StartCoroutine(LoadDevice("None", false));}

	IEnumerator LoadDevice(string newDevice, bool enable)
	{
		UnityEngine.XR.XRSettings.LoadDeviceByName(newDevice); //  carga de  modo  vr 
		yield return null;
		UnityEngine.XR.XRSettings.enabled = enable;
	}

	public void EnableVR()
	{
		StartCoroutine(LoadDevice("cardboard", true)); // ejecuta la carga   vr en  el modo  oculusvr

		Debug.Log ("clic");
	}

	public void DisableVR()
	{
		StartCoroutine(LoadDevice("None", false));

	}


	void  Update(){
		if (Input.GetButtonDown("Cancel")){ 

			DisableVR ();

		}

	}


	public void Iniciarnativa
	(){
		DisableVR ();
		SceneManager.LoadScene ("Tourautonoma");

	
	}

	public void IniciarVR
	(){
		EnableVR ();
		SceneManager.LoadSceneAsync ("Tourautonoma");


	}

}
