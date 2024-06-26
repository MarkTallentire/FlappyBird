using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GetReady : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    private float _offset = 0f;

    private Game game;

    void Start()
    {
        game = FindObjectOfType<Game>();
        StartCoroutine(Animate());
    }

    IEnumerator Animate()
    {
        while (true)
        {
            _offset += Time.deltaTime;
            
            if (game.CurrentState != GameState.Transitioning)
                yield return null;
            else if (transform.position.y < 0f)
            {
                var moveTowards = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, 0f), _speed * Time.deltaTime);
                transform.position = moveTowards;
                yield return null;
            }
            
            if (transform.position.y == 0f)
            {
                yield return new WaitForSeconds(1f);
            }
            if (transform.position.y >= 0f)
            {
                var moveTowards = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, 6f), _speed * Time.deltaTime);
                transform.position = moveTowards;
                yield return null;
            }
            if (transform.position.y == 6f)
            {
                game.UpdateState(GameState.Running);
                yield break;
            }
                
        }
    }
}