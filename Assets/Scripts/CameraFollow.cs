using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 5f;

    private Vector2 minBounds;
    private Vector2 maxBounds;
    private Camera cam;
    private float groundY;

    private void Start()
    {
        cam = Camera.main;
        GameObject bounds = GameObject.FindWithTag("CameraBounds");

        if (bounds != null)
        {
            BoxCollider2D box = bounds.GetComponent<BoxCollider2D>();
            minBounds = box.bounds.min;
            maxBounds = box.bounds.max;
            groundY = maxBounds.y; // I-set ang max Y (ground level)
        }
    }

    private void LateUpdate()
    {
        if (player == null) return;

        Vector3 targetPosition = new Vector3(player.position.x, player.position.y, transform.position.z);

        float camHalfWidth = cam.orthographicSize * Screen.width / Screen.height;
        float camHalfHeight = cam.orthographicSize;

        targetPosition.x = Mathf.Clamp(targetPosition.x, minBounds.x + camHalfWidth, maxBounds.x - camHalfWidth);
        targetPosition.y = Mathf.Clamp(targetPosition.y, minBounds.y + camHalfHeight, groundY - camHalfHeight);

        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
    }
}
