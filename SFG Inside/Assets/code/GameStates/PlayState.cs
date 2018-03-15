/*
 * PlayState
 * 
 * Contains the actions that happen, when the game enters the ingame state.
 */

using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayState : IGameState 
{
	public void enterState(GameLogic game)
	{
        //load corect level (read levelindex form data)
        SceneManager.LoadScene("Level" +GameLogic.game.data.levelIndex);
	}

	public void update(GameLogic game)
	{
		//check for escaop key
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			//if game is not paused, pause game
			if (game.data.gamePaused) 
			{
				game.data.gamePaused = false;
			}
			//if game is paused, unpause game
			else
			{
				game.data.gamePaused = true;
			}
		}
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
