using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public GameState gameState;

    public enum GameState
    {
        SplashScreen,
        Menu,
        Playing,
        Pause,
    }

    void Awake()
    {
        if(instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(this.gameObject);
        }
    }

	public bool CompareGameState(GameState state)
    {
        if(state == gameState)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ChangeGameState(GameState state)
    {
        gameState = state;
    }
}
