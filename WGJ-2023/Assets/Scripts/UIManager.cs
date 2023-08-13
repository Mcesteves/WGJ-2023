using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject MessageUI;
    public float messageTime;
    [HideInInspector]public static bool showingMessage;
    private void Start()
    {
        Iteractable.onShowMessage += ShowMessage;
    }
    public void ShowMessage(string message)
    {
        StartCoroutine(ShowMessageCoroutine(message));
    }


    private IEnumerator ShowMessageCoroutine(string message)
    {
        MessageUI.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = message;
        MessageUI.GetComponent<CanvasGroup>().alpha = 1;
        showingMessage = true;
        yield return new WaitForSeconds(messageTime);
        MessageUI.GetComponent<CanvasGroup>().alpha = 0;
        showingMessage = false;
    }
}
