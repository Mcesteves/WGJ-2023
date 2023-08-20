using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MovementStateSO", menuName = "ScriptableObjects/MovementState")]
public class MovementStateSO : ScriptableObject
{
    [HideInInspector]public Vector3 startPos;
    public float speed;
    public bool stopMovement = false;
    public bool janitorLocked = true;
    public bool principalLocked = true;

    public void UnlockJanitorRoom()
    {
        janitorLocked = false;
    }

    public void UnlockPrincipalRoom()
    {
        principalLocked = false;
    }

    public void ResetMovementStateSO()
    {
        stopMovement = false;
        janitorLocked = true;
        principalLocked = true;
    }
}
