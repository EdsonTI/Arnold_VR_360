using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Manegador_videos : MonoBehaviour {
	public static Manegador_videos istancia;
	public VideoPlayer  videoplayer;

	void Awake  () {
		istancia = this;
	}

	public void play_video () {
		videoplayer.Play ();

	}
}
