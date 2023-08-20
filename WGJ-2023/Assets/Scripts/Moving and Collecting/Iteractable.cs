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
    public static event Action<string> onShowMessage;
    public static event Action onColected;
    public static event Action onFlushed;
    public override IEnumerator GoToPosition(Vector2 target)
    {
        yield return base.GoToPosition(target);
        movementStateSO.startPos = playerTransform.position;
        if (!interrupted && canInteract)
        {
            if (canCollect)
            {
                inventory.Collect(itemType);
                onColected?.Invoke();
                Destroy(this.gameObject);
            }
            else if(itemType == item.toilet)
            {
                int count  = inventory.IncreaseToiletCount();
                AudioManager.instance.Play("toilet");
                if (count == 3)
                {
                    inventory.Collect(itemType);
                    onColected?.Invoke();
                    Destroy(this.gameObject);
                    onFlushed?.Invoke();
                }
            }
            else
            {
                if(!UIManager.showingMessage)
                    onShowMessage?.Invoke(message);
            }
        }
        interrupted = false;
        movementStateSO.stopMovement = false;
    }

}
