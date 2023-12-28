using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BaseData", menuName = "ObjectData/BaseData")]
public class StatusData : ScriptableObject
{
    [Header("Status")]
    public float health;
    public float speed;
    public float attackPower;
    public float delayTime;
}

[CreateAssetMenu(fileName = "BaseData", menuName = "ObjectData/RangedData")]
public class RangedAttackData : StatusData
{
    [Header("Ranged Attack Data")]
    public string bulletNameTag;
    public float duration; //지속시간
    public float spread;
    public int numberofProjectilesPerShot;
    public float multipleProjectilesAngel;
    public Color projectileColor;
}
