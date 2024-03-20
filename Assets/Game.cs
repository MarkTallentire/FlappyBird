using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameState CurrentState { get; private set; }= GameState.NotStarted;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateState(GameState gameState)
    {
        CurrentState = gameState;
    }
}

public enum GameState
{
    NotStarted,
    Transitioning,
    Running,
    Ended
}