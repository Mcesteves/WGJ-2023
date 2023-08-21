using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public string message;
    public static event Action<string> OnShowDoorMessage;
    private void Awake()
    {
        OnShowDoorMessage = null;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnShowDoorMessage?.Invoke(message);
    }
}
