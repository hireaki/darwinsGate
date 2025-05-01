using UnityEngine;

public class ParallaxBounded : MonoBehaviour
{
    public float sensitivity = 0.5f;
    public float smoothSpeed = 5f;

    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private Vector2 maxOffset;
    private Camera mainCam;
    private Renderer rend;

    void Start()
    {
        mainCam = Camera.main;
        initialPosition = transform.position;
        targetPosition = initialPosition;

        rend = GetComponent<Renderer>();
        Bounds bgBounds = rend.bounds;

        float camHeight = 2f * mainCam.orthographicSize;
        float camWidth = camHeight * mainCam.aspect;

        // Calculate max offset so edges stay inside camera
        maxOffset.x = Mathf.Max(0f, (bgBounds.size.x - camWidth) / 2f);
        maxOffset.y = Mathf.Max(0f, (bgBounds.size.y - camHeight) / 2f);
    }

    void Update()
    {
        Vector2 input;

#if UNITY_EDITOR
        Vector2 mousePos = Input.mousePosition;
        input.x = (mousePos.x / Screen.width - 0.5f) * 2f;
        input.y = (mousePos.y / Screen.height - 0.5f) * 2f;
#else
        input = new Vector2(Input.acceleration.x, Input.acceleration.y);
#endif

        // Optional: reduce how far it can move downward
        float offsetX = input.x * sensitivity;
        float offsetY = input.y * sensitivity;

        // You can tighten this if it moves too much downward
        offsetY = Mathf.Clamp(offsetY, -maxOffset.y * 0.5f, maxOffset.y);
        offsetX = Mathf.Clamp(offsetX, -maxOffset.x, maxOffset.x);

        targetPosition = new Vector3(
            initialPosition.x + offsetX,
            initialPosition.y + offsetY,
            initialPosition.z
        );
    }

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smoothSpeed);
    }

    // Optional: visualize movement box in Scene view
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(initialPosition, new Vector3(maxOffset.x * 2f, maxOffset.y * 2f, 0));
    }
}
