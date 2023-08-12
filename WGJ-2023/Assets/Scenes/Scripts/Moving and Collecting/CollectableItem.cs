using System.Collections;
using UnityEngine;

public class CollectableItem : MovementManager
{
    public override IEnumerator GoToPosition(Vector2 target)
    {
        yield return base.GoToPosition(target);
        movementStateSO.startPos = playerTransform.position;
        if (!interrupted)
        {
            Debug.Log("coleta");
        }
        interrupted = false;
    }
}
