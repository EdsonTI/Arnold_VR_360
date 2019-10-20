	using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Manegador_imagen : MonoBehaviour {

	public static Manegador_imagen instancia;

	public Texture2D [  ]  Imagenes_autonoma;

	public Renderer esfera ;

	void Awake () { 
		instancia = this;

	}

	public  void cambiar_textura  (int index ) { 

		esfera.material.mainTexture = Imagenes_autonoma [index];


	}



}
