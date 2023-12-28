using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    [SerializeField] 
    private ItemData _itemData;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerChangeWepon>() != null)
        {
            collision.gameObject.GetComponent<PlayerChangeWepon>().ChangeWepon(_itemData);
            Inventory.Instance.AddItem(_itemData);
            Destroy(gameObject);
        }
    }
}
