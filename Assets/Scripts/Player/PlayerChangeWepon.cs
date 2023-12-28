using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerChangeWepon : MonoBehaviour
{
    [SerializeField] private SpriteRenderer WeponSprite;
    [SerializeField] private ItemData _curItemData;

    public ItemData SetItemData()
    {
        return _curItemData;
    }
    public void ChangeWepon(ItemData item)
    {
        Debug.Log("Before Change: " + WeponSprite.sprite); // 변경 전
        WeponSprite.sprite = item.WeponImage;
        Debug.Log("After Change: " + WeponSprite.sprite); // 변경 후
        _curItemData = item;
    }
}
