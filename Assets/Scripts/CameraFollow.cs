using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransfrom;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;
    private void LateUpdate()
    {
        Vector3 desiredPosition = playerTransfrom.position + offset;
        Vector3 smootherPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smootherPosition;      
    }
}
