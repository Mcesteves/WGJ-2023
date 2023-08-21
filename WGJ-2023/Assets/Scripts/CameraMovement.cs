using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float minX, maxX;
    public float cameraSpeed;
    private Transform playerTransform;
    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        if (CanFollow())
        {
            MoveCamera();
        }
    }
    public void MoveCamera()
    {
        Vector3 target = new Vector3(playerTransform.position.x - 1f, playerTransform.position.y + 4.8f, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, cameraSpeed);
    }

    public bool CanFollow()
    {
        if(playerTransform.position.x <= maxX && playerTransform.position.x >= minX)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
