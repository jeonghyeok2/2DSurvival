using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] private GameObject _slotIndexTxt;
    public Image itemImage;
    private int _slotIndex;

    public void GetSlotIndex(int index) 
    {
        _slotIndex = index;
        _slotIndexTxt.GetComponent<TextMeshProUGUI>().text = _slotIndex.ToString();
    }
    public void SetItemSlot(ItemData item)
    {
        if (item != null)
        {
            itemImage.sprite = item.WeponSlotImage;
        }
    }
}
