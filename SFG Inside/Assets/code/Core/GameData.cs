using System.Collections.Generic;

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

    //dialogs
    public int activeDialogIndex = 0;
    public string speakerName = "";
    public List<string> activeDialog = new List<string>();
}
