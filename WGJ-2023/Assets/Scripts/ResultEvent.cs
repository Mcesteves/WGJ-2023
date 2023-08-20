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
        Iteractable.onColected += checkIfAllCollected;
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
        GetComponent<Image>().enabled = true; ;
    }
}
