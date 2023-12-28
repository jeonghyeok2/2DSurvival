using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action<StatusData> OnAttackEvent;

    private float _timeSinceLastAttack = float.MaxValue;
    protected bool IsAttacking { get; set; }

    protected CharacterStatsHandler CharacterStatsHandler { get; private set; }

    protected virtual void Awake()
    {
        CharacterStatsHandler = GetComponent<CharacterStatsHandler>();
    }
    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }
    protected virtual void Update()
    {
        HandleAttackDelay();
    }

    private void HandleAttackDelay()
    {
        float delay = CharacterStatsHandler.currentStates.status.delayTime;
        if (_timeSinceLastAttack <= delay) //딜레이 시간보다 작으면 발사 금지
        {
            _timeSinceLastAttack += Time.deltaTime;
        }
        if (IsAttacking && _timeSinceLastAttack > delay)
        {
            _timeSinceLastAttack = 0;
            CallAttackEvent(CharacterStatsHandler.currentStates.status);
        }
    }
    public void CallAttackEvent(StatusData statusData)
    {
        OnAttackEvent?.Invoke(statusData);
    }
}
