using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAimRotation : MonoBehaviour
{
    private TopDownCharacterController _controller;

    //플레이어 이미지
    [SerializeField]
    private SpriteRenderer _chracterSprite;

    //화살이미지와, 회전 중심
    [SerializeField]
    private SpriteRenderer _weponSprite;
    [SerializeField]
    private Transform _armPivot;

    private void Awake()
    {
        _controller = GetComponent<TopDownCharacterController>();
        _chracterSprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        _controller.OnLookEvent += Aim;
    }

    private void Aim(Vector2 aimDirection)
    {
        RotateArm(aimDirection);
    }

    private void RotateArm(Vector2 aimDirection)
    {
        float rotZ = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

        _weponSprite.flipY = Mathf.Abs(rotZ) > 90f;
        _chracterSprite.flipX = !_weponSprite.flipY;
        _armPivot.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}
