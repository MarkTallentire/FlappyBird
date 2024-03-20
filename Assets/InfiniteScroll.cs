
using System;
using UnityEngine;

public class Environment : MonoBehaviour
{
    [SerializeField] private float _scrollSpeed = 5f;
    [SerializeField] private float _cutPoint = -5.31f;
    private float _startPosition = 0f;

    private void Start()
    {
        _startPosition = transform.position.x;
    }

    void Update()
    {
        var newPosition = -Vector2.right * (_scrollSpeed * Time.deltaTime);
        transform.Translate(newPosition);

        if (transform.position.x <= _cutPoint)
        {
            var zeroPosition = new Vector2(_startPosition, transform.position.y);
            transform.position = zeroPosition;
        }
    }
}
