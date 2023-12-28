using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
public class ItemSlot
{
    public ItemData ItemData;
}
public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject _SlotsParent;
    [SerializeField] private Slot[] _slots;
    [SerializeField] private ItemData[] _itemDatas;
    [SerializeField] private PlayerChangeWepon _playerChangeWepon;
    public static Inventory Instance;

    private void Awake()
    {
        Instance = this;
        _slots = _SlotsParent.GetComponentsInChildren<Slot>();
        for (int i = 0; i < _slots.Length; ++i)
        {
            _slots[i].GetSlotIndex(i + 1);
        }
        _itemDatas = new ItemData[4];
        for (int i = 0; i < _itemDatas.Length; ++i)
        {
            _itemDatas[i] = new ItemData();
        }
    }
    public void AddItem(ItemData itemData)
    {
        if (ItemDataNum() != -1)
        {
            int index = ItemDataNum();
            _itemDatas[index] = itemData;
            _slots[index].SetItemSlot(itemData);
        }
    }
    public ItemData GetItemData(int index) 
    {
        return _itemDatas[index];
    }
    public int ItemDataNum()
    {
        
        for (int i = 0; i < _itemDatas.Length; i++)
        {
            if (_itemDatas[i].Name == null)
            {
                return i;
            }
        }
        return -1;
    }
}
