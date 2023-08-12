using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class MovementManager : MonoBehaviour, IPointerClickHandler
{

    [HideInInspector]public bool interrupted;
    public MovementStateSO movementStateSO;
    [HideInInspector] public Transform playerTransform;

    private void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        movementStateSO.startPos = playerTransform.position;
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        Vector2 target = new Vector2(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()).x, playerTransform.position.y);
        StartCoroutine(GoToPosition(target));
    }

    public virtual IEnumerator GoToPosition(Vector2 target)
    {
        if (movementStateSO.startPos.x != playerTransform.position.x)
        {
            movementStateSO.stopMovement = true;
        }

        movementStateSO.startPos = playerTransform.position;
        Vector2 diff = target - (Vector2)movementStateSO.startPos;

        yield return new WaitUntil(() => movementStateSO.stopMovement == false);

        while (diff.magnitude > 0.2f && !movementStateSO.stopMovement)
        {
            playerTransform.Translate(movementStateSO.speed * diff.normalized * Time.deltaTime);
            diff = target - (Vector2)playerTransform.position;
            yield return null;
        }

        if (!movementStateSO.stopMovement)
        {
            playerTransform.position = target;
            movementStateSO.startPos = playerTransform.position;
            interrupted = false;
        }

        yield return null;

        if (movementStateSO.stopMovement)
        {
            interrupted = true;
        }

        movementStateSO.stopMovement = false;
    }
}
