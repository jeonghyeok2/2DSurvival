using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownAnimationController : TopDownAnimation
{
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");
    private static readonly int Bow = Animator.StringToHash("Bow");
    private static readonly int Sword = Animator.StringToHash("Sword");

    private PlayerChangeWepon _playerChangeWepon;

    protected override void Awake()
    {
        base.Awake();
        _playerChangeWepon = GetComponent<PlayerChangeWepon>();
    }
    private void Start()
    {
        controller.OnMoveEvent += Move;
        controller.OnAttackEvent += Attacking;
    }

    private void Attacking(StatusData statusData)
    {
        if (_playerChangeWepon.SetItemData().Name == "Bow")
        {
            animator.SetTrigger(Bow);
        }
        else
        {
            animator.SetTrigger(Sword);
        }
    }

    private void Move(Vector2 vector)
    {
        animator.SetBool(IsWalking, vector.magnitude > .3f);
    }
}
