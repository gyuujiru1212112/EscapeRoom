using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonMusicPlay : MonoBehaviour {

	public AudioClip audioSFX;

	public Button yourButton;

	void Start()
	{
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
	{
		// play sound effect if set
		if (audioSFX) {
			if (gameObject.GetComponent<AudioSource> ()) { // the projectile has an AudioSource component
				// play the sound clip through the AudioSource component on the gameobject.
				// note: The audio will travel with the gameobject.
				gameObject.GetComponent<AudioSource> ().PlayOneShot (audioSFX);
			} else {
				// dynamically create a new gameObject with an AudioSource
				// this automatically destroys itself once the audio is done
				AudioSource.PlayClipAtPoint (audioSFX, gameObject.transform.position);
			}
		}	
	}

}