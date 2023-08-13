using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseDoor : MovementManager
{
    public Transform goToTransform;
    public override IEnumerator GoToPosition(Vector2 target)
    {
        yield return base.GoToPosition(target);
        movementStateSO.startPos = playerTransform.position;
        if (!interrupted)
        {
            playerTransform.position = goToTransform.position;
            movementStateSO.startPos = playerTransform.position;
        }
        interrupted = false;
    }
}
