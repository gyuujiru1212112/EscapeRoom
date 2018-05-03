using UnityEngine;
using System.Collections;

public class MusicTest : MonoBehaviour {

	private MusicPlayer music;

	void Start () {

		music = (GetComponent("MusicPlayer") as MusicPlayer);

	}

	void OnGUI()
	{
		if(GUI.Button(new Rect(750, 500, 50, 50), "music")){

			music.Play("water");

		}

	}

}