using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] private float _forceToPush = 20f;
    [SerializeField] private float _idleAnimationSpeed = 20f;
    
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;

    [SerializeField] private Sprite _up;
    [SerializeField] private Sprite _down;
    [SerializeField] private Sprite _neutral;

    private Sprite _current;

    private float _previousFramePositionY;

    private Game _game;

    private bool _isStarted = false;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _previousFramePositionY = 0;

        _game = FindObjectOfType<Game>();
        
        StartCoroutine(AnimationTimer());
    }

    // Update is called once per frame
    void Update()
    {
        if (_game.CurrentState != GameState.Running)
            return;

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            _isStarted = true;
            _rigidbody2D.WakeUp();
            
            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.AddForce(new Vector2(0, _forceToPush), ForceMode2D.Impulse);
        }

        if (!_isStarted) return; 
        
        if (_previousFramePositionY > transform.position.y)
        {
            _rigidbody2D.MoveRotation(-20f);
        }
        else
        {
            _rigidbody2D.MoveRotation(20f);
        }

        _previousFramePositionY = transform.position.y;

    }

    void Animate()
    {
        if (_current == _up)
        {
            _current = _neutral;
        }
        else if (_current == _neutral)
        {
            _current = _down;
        }
        else
        {
            _current = _up;
        }

        _spriteRenderer.sprite = _current;
    }


    IEnumerator AnimationTimer()
    {
        while (true)
        {
            Animate();
            yield return new WaitForSeconds(.15f);
        }
    }
    
   
}