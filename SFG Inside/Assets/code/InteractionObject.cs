﻿/*
 * InteractionObject
 * 
 * 
 */

using UnityEngine;
using System.Collections;

//possible action a interaction object can do additionaly
public enum SpecialActions
{
	NONE,
    TO_HUB_LEVEL,
    TO_RED_ZONE,
    TO_GREEN_ZONE,
    TO_BLUE_ZONE,
	RESTARTLEVEL,
	ENDSCREEN
}

public class InteractionObject : MonoBehaviour 
{
    //public accessible properties
    public bool isTrigger = false;
	public bool interactionEnabled = true;
	public float interactionRange = 3f;
	public string neededItem = "";

	public GameObject[] activateObjects;
	public GameObject[] deactivateObjects;
	public InteractionObject[] enableInteractionObjects;
	public InteractionObject[] disableInteractionObjects;
	public AudioClip playAudio = null;

	public SpecialActions doSpecialAction = SpecialActions.NONE;

	//unity awake
	public void Awake() 
	{
		//set tag
		gameObject.tag = "InteractionObject";
	}

    void OnTriggerEnter(Collider other)
    {
        if (isTrigger)
        {
            doAction(other.gameObject);
        }
    }

    //execute action depending on the designers setup
    public void doAction(GameObject player)
	{
		// check if player is allowed to exectue the action
		if (isActionAllowed(player))
		{
			// activate objects
			if (activateObjects.Length > 0)
			{
				for (int i = 0; i<activateObjects.Length; i++)
				{
					activateObjects[i].SetActive(true);
				}
			}
			// deactivate objects
			if (deactivateObjects.Length > 0)
			{
				for (int i = 0; i<deactivateObjects.Length; i++)
				{
					deactivateObjects[i].SetActive(false);
				}
			}
			// enable interaction objects
			if (enableInteractionObjects.Length > 0)
			{
				for (int i = 0; i<enableInteractionObjects.Length; i++)
				{
					enableInteractionObjects[i].interactionEnabled = true;
				}
			}
			// disable interaction objects
			if (disableInteractionObjects.Length > 0)
			{
				for (int i = 0; i<disableInteractionObjects.Length; i++)
				{
					disableInteractionObjects[i].interactionEnabled = false;
				}
			}
			// play audio
			if (playAudio != null)
			{
				GameLogic.game.gameAudio.play(playAudio, transform.position);
			}
		
			// at the end execute special actions
			executeSpecialAction();
		}
	}

	//checks all the requirements are met for an action
	private bool isActionAllowed(GameObject player)
	{
		// check if active
		if (!interactionEnabled)
		{
			Debug.Log("'" + gameObject.name + "' is not enabled.");
			return false;
		}
		// check interaction range
		if (Vector3.Distance(player.transform.position, transform.position) > interactionRange && !isTrigger)
		{
            Debug.Log("'" + gameObject.name + "' is to far away. (" + Vector3.Distance(player.transform.position, transform.position) + ")");
            return false;
		}
		// check if item requirement is ok
		if (neededItem != "" && !GameLogic.game.inventory.hasItemInInventory(neededItem))
		{
            Debug.Log("'" + neededItem + "' is not in your inventory.");
			return false;
		}
		return true;
	}

	//defines the special actions and executes them
	private void executeSpecialAction()
	{
		//execute the special action
		switch (doSpecialAction)
		{
        case SpecialActions.TO_HUB_LEVEL:
            //set levelindex
            GameLogic.game.data.levelName = "hub_zone";
            //unpause game
            GameLogic.game.data.gamePaused = false;
            GameLogic.game.data.lastCheckpoint = Vector3.zero;
            //switch to play state
            GameLogic.game.changeState(new PlayState());
            break;
        case SpecialActions.TO_RED_ZONE:
            //set levelindex
            GameLogic.game.data.levelName = "red_zone";
            //unpause game
            GameLogic.game.data.gamePaused = false;
            GameLogic.game.data.lastCheckpoint = Vector3.zero;
            //switch to play state
            GameLogic.game.changeState(new PlayState());
            break;
        case SpecialActions.TO_GREEN_ZONE:
            //set levelindex
            GameLogic.game.data.levelName = "green_zone";
            //unpause game
            GameLogic.game.data.gamePaused = false;
            GameLogic.game.data.lastCheckpoint = Vector3.zero;
            //switch to play state
            GameLogic.game.changeState(new PlayState());
            break;
        case SpecialActions.TO_BLUE_ZONE:
            //set levelindex
            GameLogic.game.data.levelName = "blue_zone";
            //unpause game
            GameLogic.game.data.gamePaused = false;
            GameLogic.game.data.lastCheckpoint = Vector3.zero;
            //switch to play state
            GameLogic.game.changeState(new PlayState());
            break;
            case SpecialActions.RESTARTLEVEL:
			GameLogic.game.restartLevel();
			break;
		case SpecialActions.ENDSCREEN:
			GameLogic.game.changeState(new EndGameState());
			break;
		}
	}
}
