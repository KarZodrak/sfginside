/*
 * GameLogic
 * 
 * this is the game core. it contains: 
 * - game loop with gamestates
 * - level change functions
 * - references to important systems
 */

using UnityEngine;

[RequireComponent (typeof (GameAudio))]
public class GameLogic : MonoBehaviour 
{
    private static GameLogic _game = null;
	public static GameLogic game {
		get{return _game;}
	}

	private IGameState _state = null;
	public IGameState state {
		get{return _state;}
	}
	private IGameState _lastState = null;

	private GameData _data = null;
	public GameData data {
		get{return _data;}
	}

	private GameAudio _gameAudio = null;
	public GameAudio gameAudio {
		get{return _gameAudio;}
	}

	private Inventory _inventory = null;
	public Inventory inventory {
		get{return _inventory;}
	}

    // unity awake, inizialic the game
    public void Awake()
	{
		//check if gamelogic already exists
		if (GameLogic.game == null)
		{
			//make sure, gamelogic stays alive
			DontDestroyOnLoad(gameObject);
			_game = this;
		}
		else
		{
			//destroy additional gamelogic
			Destroy(gameObject);
		}
	}

	// unity start
	private void Start ()
	{
		//init systems
		_gameAudio = GetComponent<GameAudio>();
		_data = new GameData();
		_inventory = new Inventory();

		//switch to default starting state
		changeState(new MainMenuState());
	}

    // main gameloop
    private void Update()
	{
		if (_data.gamePaused) 
		{
			Time.timeScale = 0;
		} 
		else
		{
			Time.timeScale = 1;
		}
		_state.update(this);
	}

    // late update loop
    private void LateUpdate()
	{
		_state.lateUpdate(this);
	}

	// restart this level
	public void restartLevel()
	{
		_data.gamePaused = false;
		changeState(new PlayState());
	}

	// change game state
	public void changeState(IGameState newState)
	{
		// exit old state if available
		if(_state != null)
		{
			_state.exitState(this);
		}
		//change state
		_lastState = _state;
		_state = newState;
		//enter new state
		_state.enterState(this);
    }

	// switch back to last game state
	public void changeToLastState()
	{
		// check if laststate exists
		if (_lastState != null)
		{
            //execute state change
			changeState(_lastState);
		}
	}
}
