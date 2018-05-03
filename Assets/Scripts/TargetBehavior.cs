using UnityEngine;
using System.Collections;

public class TargetBehavior : MonoBehaviour
{
	// Reference to AudioClip to play
	public AudioClip shootSFX;
	public GameObject mainCanvas;
	public GameObject activeCanvas;

	// when collided with another gameObject
	void OnCollisionEnter (Collision newCollision)
	{
		// exit if there is a game manager and the game is over
		if (GameManager.gm) {
			if (GameManager.gm.gameIsOver)
				return;
		}

		// only do stuff if hit by a projectile
		if (newCollision.gameObject.tag == "Projectile") {
			// play sound effect if set
			if (shootSFX)
			{
				if (gameObject.GetComponent<AudioSource> ()) { // the projectile has an AudioSource component
					// play the sound clip through the AudioSource component on the gameobject.
					// note: The audio will travel with the gameobject.
					gameObject.GetComponent<AudioSource> ().PlayOneShot (shootSFX);
				} 
				/*else {
					// dynamically create a new gameObject with an AudioSource
					// this automatically destroys itself once the audio is done
					AudioSource.PlayClipAtPoint (shootSFX, gameObject.transform.position);
				}*/
			}

			bool isPlaying;
			while (gameObject.GetComponent<AudioSource> ().isPlaying) {
				isPlaying = true;
			}
			isPlaying = false;

			if (!isPlaying && activeCanvas) {
				mainCanvas.SetActive (false);
				// make the mouse pointer visible
				Cursor.visible = true;

				// unlock the mouse pointer so player can click on other windows
				Cursor.lockState = CursorLockMode.None;
				activeCanvas.SetActive(true);

			}
				
			// destroy the projectile
			Destroy (newCollision.gameObject);
		}
	}
}
