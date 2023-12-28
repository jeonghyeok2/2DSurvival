using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownCharacterController
{
    private Camera _camera;
    protected override void Awake()
    {
        base.Awake();
        _camera = Camera.main;
    }

    public void OnMove(InputValue inputValue)
    {
        Vector2 vector2 = inputValue.Get<Vector2>().normalized;
        CallMoveEvent(vector2);
    }
    public void OnLook(InputValue mouseValue) //스크린상의 마우스의 방향을 알려줌
    {
        Vector2 mousePosition = mouseValue.Get<Vector2>();
        Vector2 worldMousePosition = _camera.ScreenToWorldPoint(mousePosition);
        mousePosition = (worldMousePosition - (Vector2)transform.position).normalized;
        CallLookEvent(mousePosition);
    }
    public void OnAttack(InputValue value)
    {
        IsAttacking = value.isPressed;
    }
    public void OnSlotSelect(InputValue Value)
    {
        float inputValue = Value.Get<float>();
        CallSlotEvent(inputValue);
    }
}
