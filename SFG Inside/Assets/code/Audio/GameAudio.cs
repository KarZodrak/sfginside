/*
 * GameAudio
 * 
 * GameAudio inisiates the audio calls
 */

using UnityEngine;

public class GameAudio : MonoBehaviour 
{
	//reference to the audio prefab with the audio source
	public GameObject audioPrefab;

	//creates an audio object and sets the clip
	public void play(AudioClip clip, Vector3 position, bool loop = false)
	{
		GameObject go = GameObject.Instantiate(audioPrefab, position, Quaternion.identity) as GameObject;
		go.GetComponent<AudioObject>().playClip(clip,loop);
	}
}
