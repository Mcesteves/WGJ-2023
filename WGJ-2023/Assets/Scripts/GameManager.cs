using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public InventorySO inventory;
    public GameObject fallenTrophy;
    public GameObject trophy;
    public GameObject janitorDoor;
    public GameObject principalDoor;
    public static event Action onJanitorUnlock;
    public static event Action onPrincipalUnlock;
    void Start()
    {
        inventory.ResetInventory();
        Iteractable.onFlushed += ActivateFallenTrophy;
        Iteractable.onColected += UnlockJanitorDoor;
        Iteractable.onColected += UnlockPrincipalDoor;
        MovementManager.janitorMin = janitorDoor.transform.position.x;
        MovementManager.principalMax = principalDoor.transform.position.x;
    }

    public void ActivateFallenTrophy()
    {
        fallenTrophy.SetActive(true);
        fallenTrophy.GetComponent<Iteractable>().canCollect = true;
        fallenTrophy.GetComponent<Iteractable>().canInteract = true;
        trophy.SetActive(false);
    }

    public void UnlockPrincipalDoor()
    {
        if (inventory.IsAllCollected())
        {
            principalDoor.SetActive(false);
            onPrincipalUnlock?.Invoke();
        }
    }

    public void UnlockJanitorDoor()
    {
        if (inventory.GetType(item.key))
        {
            janitorDoor.SetActive(false);
            onJanitorUnlock?.Invoke();
        }
            
    }
}
