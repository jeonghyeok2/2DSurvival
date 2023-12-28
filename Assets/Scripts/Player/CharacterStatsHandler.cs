using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.RestService;
using UnityEngine;

public class CharacterStatsHandler : MonoBehaviour
{
    [SerializeField]
    private CharacterStats _characterStats;
    public CharacterStats currentStates { get; private set; }
    public List<CharacterStats> statsModifiers = new List<CharacterStats>();

    private void Awake()
    {
        UpdateCharacterStats();
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
}

