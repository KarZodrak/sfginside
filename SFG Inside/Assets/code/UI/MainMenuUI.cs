/*
 * MainMenuUI
 * 
 * Manages the UI elements and interactions of the intro screen
 */

using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    //load new level with level index as parameter
    public void playLevel(string levelname)
    {
        //set levelindex
        GameLogic.game.data.levelName = levelname;
        //unpause game
        GameLogic.game.data.gamePaused = false;
        //switch to play state
        GameLogic.game.changeState(new PlayState());
    }

    //display credits screen
    public void showCredits()
    {
        GameLogic.game.changeState(new CreditsState());
    }

    //exit the game
    public void exitGame()
    {
        Application.Quit();
    }
}
