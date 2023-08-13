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
            if(transform.position.y < 7.0f)
                playerTransform.position = new Vector3 (goToTransform.position.x, 8.0f, playerTransform.position.z);
            else
                playerTransform.position = new Vector3(goToTransform.position.x, -2.7f, playerTransform.position.z);
            movementStateSO.startPos = playerTransform.position;
        }
        interrupted = false;
        movementStateSO.stopMovement = false;
    }
}
