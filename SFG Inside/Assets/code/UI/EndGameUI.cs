/*
 * EndGameUI
 * 
 * Manages the UI elements and interactions of the endgame screen
 */

using UnityEngine;
using UnityEngine.UI;

public class EndGameUI : MonoBehaviour
{
    //text element for endscreen text
    public Text endGameText;

    // unity start
    public void Start()
    {
        //set the text according to the game data
        if (GameLogic.game.data.playerWins)
        {
            endGameText.text = "You WIN!";
        }
        else
        {
            endGameText.text = "You LOOSE!";
        }
    }

    // unity update
    public void Update()
    {
        //check for any key input
        if (Input.anyKeyDown)
        {
            //change to main menu
            GameLogic.game.changeState(new MainMenuState());
        }
    }
}
