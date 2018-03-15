/*
 * CreditsState
 * 
 * Contains the actions that happen, when the game enters the credit state.
 */

using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsState : IGameState 
{
	public void enterState(GameLogic game)
	{
        //load intro
        SceneManager.LoadScene("Credits");
    }

	public void update(GameLogic game)
	{
		//do nothing
	}

	public void lateUpdate(GameLogic game)
	{
		//do nothing
	}

	public void exitState(GameLogic game)
	{
		//do nothing
	}
}
