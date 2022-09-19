using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    public Item Item;

    public Button removeButton;

    public void RemoveItem()
    {
        InventoryManager.Instance.Remove(Item);
    }

    public void AddItem(Item newItem)
    {
        Item = newItem;
    }
}
