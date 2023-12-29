using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.RestService;
using UnityEngine;

public class CharacterStatsHandler : MonoBehaviour
{
    [SerializeField]
    private CharacterStats _characterStats;
    private PlayerChangeWepon _playerChangeWepon;
    public CharacterStats currentStates { get; private set; }
   

    private void Awake()
    {
        UpdateCharacterStats();
        _playerChangeWepon = GetComponent<PlayerChangeWepon>();
    }
    private void UpdateCharacterStats()
    {
        StatusData status = null;
        if (_characterStats.status != null)
        {
            status = Instantiate(_characterStats.status);
        }

        currentStates = new CharacterStats { status = status };

        currentStates.maxHealth = _characterStats.maxHealth;
        currentStates.speed = _characterStats.speed;
    }
    public float AttackDelayTime()
    {
        if (_playerChangeWepon.SetItemData() != null)
        {
            if (_playerChangeWepon.SetItemData().Type == ItemType.MeleeAttack)
            {
                return currentStates.status.delayTime + 1;
            }
            else
            {
                return currentStates.status.delayTime;
            }
        }
        return 0;
    }
}

