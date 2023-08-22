using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class MovementManager : MonoBehaviour, IPointerClickHandler
{
    [HideInInspector]public bool interrupted;
    public MovementStateSO movementStateSO;
    [HideInInspector] public Transform playerTransform;
    static public float janitorMin;
    static public float principalMax;
    static public UIManager uiManager;
    
    private void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        uiManager = GameObject.FindWithTag("GameManager").GetComponent<UIManager>();
        movementStateSO.startPos = playerTransform.position;
        GameManager.OnJanitorUnlock += movementStateSO.UnlockJanitorRoom;
        GameManager.OnPrincipalUnlock += movementStateSO.UnlockPrincipalRoom;
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {

        if (UIManager.showingMessage)
        {
            uiManager.MessageUI.GetComponent<CanvasGroup>().alpha = 0;
            UIManager.showingMessage = false;
        }
            
        Vector2 target = new Vector2(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()).x, playerTransform.position.y);
        StartCoroutine(GoToPosition(target));
    }

    public virtual IEnumerator GoToPosition(Vector2 target)
    {
        if (movementStateSO.janitorLocked && playerTransform.position.y < 7.0f)
            target.x = Mathf.Clamp(target.x, janitorMin + 0.7f, 100f);
        if (movementStateSO.principalLocked && playerTransform.position.y > 7.0f)
            target.x = Mathf.Clamp(target.x, -100f, principalMax - 0.5f);
        if (Mathf.Abs(movementStateSO.startPos.x - playerTransform.position.x) > 0.15f)
        {
            movementStateSO.stopMovement = true;
        }

        movementStateSO.startPos = playerTransform.position;
        Vector2 diff = target - (Vector2)movementStateSO.startPos;
        
        if(target.x < playerTransform.position.x && playerTransform.localScale.x > 0f)
        {
            playerTransform.localScale = new Vector3(-playerTransform.localScale.x, playerTransform.localScale.y, playerTransform.localScale.z);
        }
        else if (target.x > playerTransform.position.x && playerTransform.localScale.x < 0f)
        {
            playerTransform.localScale = new Vector3(-playerTransform.localScale.x, playerTransform.localScale.y, playerTransform.localScale.z);
        }

        yield return new WaitUntil(() => movementStateSO.stopMovement == false);

        while (diff.magnitude > 0.15f && !movementStateSO.stopMovement)
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
