using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	public AudioSource Sound;

	public void Play(string str)
	{
		Sound.clip = (AudioClip)Resources.Load(str, typeof(AudioClip));
		Sound.Play();
	}

}