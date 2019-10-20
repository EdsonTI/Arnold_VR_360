using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contenedor_de_escenarios : MonoBehaviour {

	public static Contenedor_de_escenarios instancia;

	public GameObject  [  ]  Escenarios;

	void Awake () { 
		instancia = this;

	}

	public void  Actualizador_escenarios (int index) { 

		for ( int I=0;I<Escenarios.Length;I++) {   
			Escenarios [I].SetActive (false);
		}

		Escenarios [index].SetActive (true);

	}

}
