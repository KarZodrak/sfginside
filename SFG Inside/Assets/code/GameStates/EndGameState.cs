/*
 * EndGameState
 * 
 * Contains the actions that happen, when the game enters the end game state.
 */

using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameState : IGameState 
{
	public void enterState(GameLogic game)
	{
        //load intro
        SceneManager.LoadScene("EndGame");
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
