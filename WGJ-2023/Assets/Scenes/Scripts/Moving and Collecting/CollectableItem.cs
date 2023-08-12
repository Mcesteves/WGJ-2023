using System.Collections;
using UnityEngine;

public class CollectableItem : MovementManager
{
    public InventorySO inventory;
    public item itemType;
    public override IEnumerator GoToPosition(Vector2 target)
    {
        yield return base.GoToPosition(target);
        movementStateSO.startPos = playerTransform.position;
        if (!interrupted)
        {
            inventory.Collect(itemType);
            Destroy(this.gameObject);
        }
        interrupted = false;
    }
}
