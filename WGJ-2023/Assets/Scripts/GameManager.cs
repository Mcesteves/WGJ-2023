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
    public GameObject ritual;
    public GameObject ritualTable;
    public static event Action OnJanitorUnlock;
    public static event Action OnPrincipalUnlock;
    public static event Action<string> onShowMessage;
    public MovementStateSO movementStateSO;

    private bool janitorLock = true;
    private void Awake()
    {
        OnJanitorUnlock = null;
        OnPrincipalUnlock = null;
        onShowMessage = null;
        movementStateSO.ResetMovementStateSO();
    }
    void Start()
    {
        inventory.ResetInventory();
        Iteractable.OnFlushed += ActivateFallenTrophy;
        Iteractable.OnColected += UnlockJanitorDoor;
        Iteractable.OnColected += UnlockPrincipalDoor;
        Iteractable.OnColected += UnlockTube;
        Iteractable.OnRitual += MakeRitual;
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
            onShowMessage?.Invoke("Voc� foi chamada na sala da diretora");
            principalDoor.SetActive(false);
            ritualTable.GetComponent<Iteractable>().canInteract = true;
            OnPrincipalUnlock?.Invoke();
        }
    }

    public void UnlockJanitorDoor()
    {
        if (janitorLock && inventory.GetType(item.key))
        {
            janitorDoor.SetActive(false);
            OnJanitorUnlock?.Invoke();
            candle.canCollect = true;
            broom.canCollect = true;
            janitorLock = false;
        }    
    }

    public void UnlockTube()
    {
        if (inventory.GetType(item.plants) && inventory.GetType(item.chalk))
        {
            tube.canCollect = true;
        }
    }

    public void MakeRitual()
    {
        StartCoroutine(StartRitual());
    }

    private IEnumerator StartRitual()
    {
        onShowMessage?.Invoke(ritualTable.GetComponent<Iteractable>().message);
        AudioManager.instance.Play("blabla_player");
        yield return new WaitForSeconds(0.2f);
        ritual.SetActive(true);
        AudioManager.instance.Play("pop_sound");
    }
}
