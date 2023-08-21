using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject MessageUI;
    [HideInInspector]public static bool showingMessage;
    private void Start()
    {
        Iteractable.OnShowMessage += ShowMessage;
        GameManager.onShowMessage += ShowMessage;
        DoorTrigger.OnShowDoorMessage += ShowMessage;
    }
    public void ShowMessage(string message)
    {
        MessageUI.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = message;
        MessageUI.GetComponent<CanvasGroup>().alpha = 1;
        showingMessage = true;
    }
}
