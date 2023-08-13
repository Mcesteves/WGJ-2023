using System;
using System.Collections;
using UnityEngine;

public class Iteractable : MovementManager
{
    public InventorySO inventory;
    public string message;
    [HideInInspector] public bool canInteract;
    public item itemType;
    [HideInInspector] public bool canCollect;

    public static event Action<string> onShowMessage;
    public override IEnumerator GoToPosition(Vector2 target)
    {
        yield return base.GoToPosition(target);
        movementStateSO.startPos = playerTransform.position;
        if (!interrupted && canInteract)
        {
            if (canCollect)
            {
                inventory.Collect(itemType);
                Destroy(this.gameObject);
            }
            else
            {
                if(!UIManager.showingMessage)
                    onShowMessage?.Invoke(message);
            }
        }
        interrupted = false;
    }

}
