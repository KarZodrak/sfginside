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
        SceneManager.LoadScene(GameLogic.game.data.levelName);

        //hide cursor
        Cursor.visible = false;
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
        //hide cursor
        Cursor.visible = true;
    }
}
