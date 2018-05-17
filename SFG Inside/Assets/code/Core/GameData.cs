using System.Collections.Generic;
using UnityEngine;


/*
 * GameData
 * 
 * GameData stores core relevant data.
 */

public class GameData 
{
    public string levelName = "hub_zone";
	public bool gamePaused = false;
	public bool playerWins = true;

    //save point
    public bool checkpointsEnabled = true;
    public Vector3 lastCheckpoint = Vector3.zero;
    public Quaternion lastCheckpointRotation = Quaternion.identity;

    //dialogs
    public int activeDialogIndex = 0;
    public string speakerName = "";
    public List<string> activeDialog = new List<string>();

}
