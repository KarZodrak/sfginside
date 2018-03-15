/*
 * AudioObject
 * 
 * AudioObject has basic audio play functions. It requires an AudioSource to function properly.
 */

using UnityEngine;

[RequireComponent (typeof (AudioSource))]
public class AudioObject : MonoBehaviour 
{
	private AudioSource _audioSrc;
	private bool audioStarted = false;

	// unity awake
	public void Awake()
	{
		_audioSrc = gameObject.GetComponent<AudioSource>();
	}

	// unity update
	public void Update()
	{
		//destroy audio object when playing is done 
		if (!_audioSrc.isPlaying && audioStarted)
		{
			Destroy(gameObject);
		}
	}

	// play desired audio clip
	public void playClip(AudioClip clip, bool loop)
	{
		_audioSrc.loop = loop;
		_audioSrc.clip = clip;
		_audioSrc.Play();
		audioStarted = true;
	}
}
