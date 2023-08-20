using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public InventorySO inventory;
    public GameObject fallenTrophy;
    public GameObject trophy;
    public Iteractable candle;
    public Iteractable broom;
    public Iteractable tube;
    public GameObject janitorDoor;
    public GameObject principalDoor;
    public static event Action OnJanitorUnlock;
    public static event Action OnPrincipalUnlock;
    void Start()
    {
        inventory.ResetInventory();
        Iteractable.onFlushed += ActivateFallenTrophy;
        Iteractable.onColected += UnlockJanitorDoor;
        Iteractable.onColected += UnlockPrincipalDoor;
        Iteractable.onColected += UnlockTube;
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
            OnPrincipalUnlock?.Invoke();
        }
    }

    public void UnlockJanitorDoor()
    {
        if (inventory.GetType(item.key))
        {
            janitorDoor.SetActive(false);
            OnJanitorUnlock?.Invoke();
            candle.canCollect = true;
            broom.canCollect = true;
        }
            
    }

    public void UnlockTube()
    {
        if (inventory.GetType(item.plants) && inventory.GetType(item.chalk))
        {
            tube.canCollect = true;
        }
    }
}
