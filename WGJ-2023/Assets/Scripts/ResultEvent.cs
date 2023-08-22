using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ResultEvent : MonoBehaviour
{
    public item[] conditionalItems;
    public InventorySO inventory;
    private void Start()
    {
        Iteractable.OnColected += checkIfAllCollected;
    }
    public void checkIfAllCollected ()
    {
        foreach(item item in conditionalItems)
        {
            if(inventory.GetType(item) == false)
            {
                return;
            }
        }
        gameObject.GetComponent<Image>().enabled = true;
    }
}
