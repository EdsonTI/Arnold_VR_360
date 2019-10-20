using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class Boton_iniciar : MonoBehaviour {

	public Inicio_animacion inicio_animacion; 


	public event Action<Boton_iniciar> OnButtonSelected;  

	public int index;
	[SerializeField] private SelectionRadial m_SelectionRadial;         // This controls when the selection is complete.
	[SerializeField] private VRInteractiveItem m_InteractiveItem;  


	// Use this for initialization
	void Start () {	
		transform.DOLookAt (Camera.main.transform.position,0.5f);
		transform.DOScale (new Vector3 (0.4f, 0.4f, 0.4f), 0.5f).SetEase(Ease.InOutSine);
		//hotpost 
	}

	private IEnumerator coroutine=null;
	private bool m_GazeOver;                                            // Whether the user is looking at the VRInteractiveItem currently.


	private void OnEnable ()
	{
		m_InteractiveItem.OnOver += HandleOver;
		m_InteractiveItem.OnOut += HandleOut;
		m_SelectionRadial.OnSelectionComplete += HandleSelectionComplete;

	}


	private void OnDisable ()
	{
		m_InteractiveItem.OnOver -= HandleOver;
		m_InteractiveItem.OnOut -= HandleOut;
		m_SelectionRadial.OnSelectionComplete -= HandleSelectionComplete;

	}


	private void HandleOver()
	{		


		transform.DOScale (new Vector3 (1.1f, 1.1f, 1), 0.5f).SetEase(Ease.InOutSine);

		// When the user looks at the rendering of the scene, show the radial.
		m_SelectionRadial.Show();

		m_GazeOver = true;
	}


	private void HandleOut()
	{
		transform.DOScale (new Vector3 (0.2f, 0.2f, 0.2f), 0.5f).SetEase(Ease.InOutSine);

		// When the user looks away from the rendering of the scene, hide the radial.
		m_SelectionRadial.Hide();

		m_GazeOver = false;
	}


	private void HandleSelectionComplete()
	{
		coroutine = ActivateButton ();
		// If the user is looking at the rendering of the scene when the radial's selection finishes, activate the button.
		if (m_GazeOver) {

			StartCoroutine (coroutine);
		} else {
			StopCoroutine (coroutine);
		}
	}


	private IEnumerator ActivateButton()
	{


		// If the camera is already fading, ignore.
		//            if (m_CameraFade.IsFading)
		//                yield break;

		// If anything is subscribed to the OnButtonSelected event, call it.
		if (OnButtonSelected != null)
			OnButtonSelected(this);

		// Wait for the camera to fade out.
		// yield return StartCoroutine(m_CameraFade.BeginFadeOut(true));
		yield return null;
		iniciar_video ();
		//SceneManager.LoadSceneAsync (nameEscene);
		// Load the level.
		// SceneManager.LoadScene(m_SceneToLoad, LoadSceneMode.Single);
	}

	void OnMouseDown(){
		iniciar_video ();	}

	void iniciar_video (){ 
		Debug.Log ("ola k ase");

		inicio_animacion.inicar_viaje (); 


	}

}







