using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ColectedEvent : MonoBehaviour
{
    public item itemType;
    public InventorySO inventory;

    private void Start()
    {
        Iteractable.OnColected += UpdateInventory;
    }
    public void UpdateInventory ()
    {
        if(inventory.GetType(itemType) == true)
        {
            gameObject.GetComponent<Image>().enabled = true;
        }
    }
}
