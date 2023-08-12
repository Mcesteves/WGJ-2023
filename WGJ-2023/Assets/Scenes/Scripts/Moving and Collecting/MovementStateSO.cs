using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MovementStateSO", menuName = "ScriptableObjects/MovementState")]
public class MovementStateSO : ScriptableObject
{
    [HideInInspector]public Vector3 startPos;
    public float speed;
    [HideInInspector]public bool stopMovement = false;
}
