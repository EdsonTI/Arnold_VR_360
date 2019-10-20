using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; // libreria de animacion
using UnityEngine.SceneManagement;


public class Inicio_animacion : MonoBehaviour {

	public Transform  Esfera;
	public GameObject carga_escena;
	public GameObject Activar_escenas;

	void Update ()  
	{ if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			SceneManager.LoadScene ("TourPanponoma");
		}
		
	}

	public void  inicar_viaje  (   )
	{
		Esfera.DOMove (new Vector3(0,0,0), 5f).SetEase (Ease.InSine).OnComplete(()=> Activar_recorrido  ());
		carga_escena.transform.DOMove (new Vector3 (0, 0, 0), 5f).SetEase (Ease.InSine);
	}
	public void  inicar_viaje_videos  (   )
	{
	Esfera.DOMove (new Vector3(0,0,0), 5f).SetEase (Ease.InSine).OnComplete(()=> carga_escena.SetActive (false));
		carga_escena.transform.DOMove (new Vector3 (0, 0, 0), 5f).SetEase (Ease.InSine);
	}


	private void  Activar_recorrido ()
	{

		carga_escena.SetActive (false);
		Activar_escenas.SetActive (true);
	}
}


