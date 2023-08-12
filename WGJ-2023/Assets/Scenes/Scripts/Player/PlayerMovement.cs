using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private bool stopMovement;
    private bool isMoving;
    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 target = new Vector2(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()).x, transform.position.y);
            StartCoroutine(GoToPosition(target));
        }
    }

    private IEnumerator GoToPosition(Vector2 target)
    {
        Vector2 diff = target - (Vector2)transform.position;
        if (isMoving)
            stopMovement = true;

        yield return new WaitUntil(() => stopMovement == false);

        isMoving = true;

        while (diff.magnitude > 0.2f && !stopMovement)
        {
            transform.Translate(speed * diff.normalized * Time.deltaTime);
            diff = target - (Vector2)transform.position;
            yield return null;
        }

        if (stopMovement)
        {
            stopMovement = false;
        }

        isMoving = false;
    }
}
