using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class PlayerChangeWepon : MonoBehaviour
{
    [SerializeField] private SpriteRenderer WeponSprite;
    [SerializeField] private ItemData _curItemData;
    [SerializeField] private PlayerInputController _playerinput;

    private void Start()
    {
        _playerinput = GetComponent<PlayerInputController>();
        _playerinput.OnSlotEvent += SelectSlotWepon;
    }
    public ItemData SetItemData()
    {
        return _curItemData;
    }
    public void ChangeWepon(ItemData item)
    {
        Color color = WeponSprite.color;
        if (item != null) 
        {
            color.a = 1f;
            WeponSprite.color = color;
            WeponSprite.sprite = item.WeponImage;
            _curItemData = item;
        }
        else
        {
            color.a = 0f;
            WeponSprite.color = color;
            WeponSprite.sprite = null;
            _curItemData = null;
        }
    }
    public void SelectSlotWepon(float index)
    {
        ChangeWepon(Inventory.Instance.GetItemData((int)index - 1));
    }
}
