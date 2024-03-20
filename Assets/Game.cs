using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameState CurrentState { get; private set; }= GameState.NotStarted;
    private GameObject _gameOver;

    private void Start()
    {
        _gameOver = GameObject.Find("GameOver");
        _gameOver.SetActive(false);
    }

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

        if (CurrentState == GameState.Ended)
        {
            _gameOver.SetActive(true);
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