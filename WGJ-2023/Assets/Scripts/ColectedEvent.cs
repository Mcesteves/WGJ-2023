using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ColectedEvent : MonoBehaviour
{
    public UnityEvent OnItemCollected;
    public item itemType;
    public InventorySO inventory;
    public Image stick;

    public void UpdateInventory ()
    {
        if(inventory.GetType(itemType) == true)
        {
            OnItemCollected?.Invoke();
        }
    }

    public void ActiveItemOnInventory ()
    {
        stick.enabled = true;
    }
}
