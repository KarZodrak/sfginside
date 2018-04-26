/*
 * Riddler
 * 
 * Manages the properties of an Riddler
 */

using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Collider))]
public class Riddler : MonoBehaviour 
{
	// accessible properties
	public string npcName = "";
	public float interactionRange = 3f;
	public AudioClip npcAudio = null;
    public List<string> npcDialog = new List<string>();

    // unity awake
    public void Awake() 
	{
		//sets tag of gameobject
		gameObject.tag = "NPC";
		//renames item if overwrite name is set
		if (npcName != "") 
		{
			name = npcName;
		}
	}

	// contains things that happen, when itme is picked up
	public void startDialog(GameObject player)
	{
		//check if pickup is within range
		if (Vector3.Distance(player.transform.position, transform.position) <= interactionRange)
		{
            //activate riddle
            //TODO
            

            //play audio, if available
            if (npcAudio != null)
			{
				GameLogic.game.gameAudio.play(npcAudio, transform.position);
			}
        }
		else
		{
			Debug.Log("'" + gameObject.name + "' is to far away. (" + Vector3.Distance(player.transform.position, transform.position) + ")");
		}
	}
}