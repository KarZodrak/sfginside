/*
 * IGameState
 * 
 * Interface for all the gamestates. Defines the needed methodes.
 */

public interface IGameState 
{
	void enterState(GameLogic game);
	void update(GameLogic game);
	void lateUpdate(GameLogic game);
	void exitState(GameLogic game);
}
