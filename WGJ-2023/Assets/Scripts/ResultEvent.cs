using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ResultEvent : MonoBehaviour
{
    public item[] conditionalItems;
    public Image resultStick;
    public InventorySO inventory;
    public UnityEvent OnConditionsTrue;
    private bool isAllTrue;

    public void checkIfAllCollected ()
    {
        foreach(item item in conditionalItems)
        {
            if(inventory.GetType(item) == false)
            {
                isAllTrue = false;
                return;
            }
            isAllTrue = true;
        }
    }

    public void showResult ()
    {
        if(isAllTrue)
        {
            OnConditionsTrue?.Invoke();
        }
    }

    public void ActiveResult ()
    {
        resultStick.enabled = true;
    }

}
