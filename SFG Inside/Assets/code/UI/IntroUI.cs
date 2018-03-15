/*
 * IntroUI
 * 
 * Manages the UI elements and interactions of the intro screen
 */

using UnityEngine;

public class IntroUI : MonoBehaviour
{
    // unity update
    public void Update()
    {
        //check for any key input
        if (Input.anyKeyDown)
        {
            //skip intro
            GameLogic.game.changeState(new MainMenuState());
        }
    }
}
