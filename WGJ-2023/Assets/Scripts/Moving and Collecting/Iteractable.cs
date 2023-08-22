using System;
using System.Collections;
using UnityEngine;

public class Iteractable : MovementManager
{
    public InventorySO inventory;
    public string message;
    public bool canInteract;
    public item itemType;
    public bool canCollect;
    public static event Action<string> OnShowMessage;
    public static event Action OnColected;
    public static event Action OnFlushed;
    public static event Action OnRitual;

    public void Awake()
    {
        if(itemType == item.chalk)
        {
            OnShowMessage = null;
            OnColected = null;
            OnFlushed = null;
            OnRitual = null;
        }
    }
    public override IEnumerator GoToPosition(Vector2 target)
    {
        yield return base.GoToPosition(target);
        movementStateSO.startPos = playerTransform.position;
        if (!interrupted && canInteract)
        {
            if (canCollect)
            {
                inventory.Collect(itemType);
                AudioManager.instance.Play("plim");
                OnColected?.Invoke();
                Destroy(this.gameObject);
            }
            else if(itemType == item.toilet)
            {
                int count  = inventory.IncreaseToiletCount();
                AudioManager.instance.Play("toilet");
                if (count == 3)
                {
                    inventory.Collect(itemType);
                    OnColected?.Invoke();
                    Destroy(this.gameObject);
                    OnFlushed?.Invoke();
                }
            }
            else if (itemType == item.ritual)
            {
                OnRitual?.Invoke();
            }
            else if(itemType == item.npc)
            {
                if(!UIManager.showingMessage)
                    OnShowMessage?.Invoke(message);
            }
        }
        interrupted = false;
        movementStateSO.stopMovement = false;
    }

}
