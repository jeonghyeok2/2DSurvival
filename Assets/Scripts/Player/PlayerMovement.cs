using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private TopDownCharacterController _controller;
    private CharacterStatsHandler _characterStatsHandler;

    private Rigidbody2D _rigidbody2D;
    private Vector2 _position;

    private void Awake()
    {
        _characterStatsHandler = GetComponent<CharacterStatsHandler>();
        _controller = GetComponent<TopDownCharacterController>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _controller.OnMoveEvent += Move;
    }
    private void FixedUpdate()
    {
        ApplyMovement(_position);
    }

    private void Move(Vector2 direction)
    {
        _position = direction;
    }

    private void ApplyMovement(Vector2 direction)
    {
        direction = direction * _characterStatsHandler.currentStates.speed; //스피드 곱해주기
        _rigidbody2D.velocity = direction;
    }
}
