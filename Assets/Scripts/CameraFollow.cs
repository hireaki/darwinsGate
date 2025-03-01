using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransfrom;
    public Vector3 offset;

    private void LateUpdate()
    {
        transform.position = playerTransfrom.position + offset;       
    }
}
