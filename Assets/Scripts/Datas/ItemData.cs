using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    MeleeAttack,
    RangedAttack
}

[CreateAssetMenu(fileName = "ItemBaseData", menuName = "ItemData/BaseData")]
public class ItemData : ScriptableObject
{
    public ItemType Type;
    public string Name;
    public Sprite WeponImage;
}
