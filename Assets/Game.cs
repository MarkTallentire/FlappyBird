using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameState CurrentState { get; private set; }= GameState.NotStarted;

    // Update is called once per frame
    void Update()
    {
        if (CurrentState == GameState.NotStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                CurrentState = GameState.Transitioning;
            }
        }
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