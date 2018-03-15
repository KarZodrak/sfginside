/*
 * MainMenuState
 * 
 * Contains the actions that happen, when the game enters the main menu state.
 */

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuState : IGameState 
{
	public void enterState(GameLogic game)
	{
        //load intro
        SceneManager.LoadScene("main_menu");
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
