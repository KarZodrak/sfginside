/*
 * CreditsUI
 * 
 * Manages the UI elements and interactions of the credits screen
 */

using UnityEngine;

public class CreditsUI : MonoBehaviour
{
    // go back to the previous state
    public void back()
    {
        GameLogic.game.changeToLastState();
    }
}
