using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public LayerMask groundLayer, obstacleLayer, playerLayer;
    public Transform ledgeDectector;

    private bool facingRight = true;
    private bool playerDetected;
    public float raycastDistance, obstacleDistance, playerDetectDistance;
    public float speed;
    public float detectionPauseTime;

    private void Update()
    {
        CheckForObstacles();
        CheckForPlayer();
    }

    void FixedUpdate()
    {
        if (!playerDetected)
        {
            if (facingRight)
                rb.velocity = new Vector2(speed, rb.velocity.y);
            else
                rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
    }

    void CheckForObstacles()
    {
        RaycastHit2D hit = Physics2D.Raycast(ledgeDectector.position, Vector2.down, raycastDistance, groundLayer);
        RaycastHit2D hitObstacle = Physics2D.Raycast(ledgeDectector.position, Vector2.right, obstacleDistance, obstacleLayer);

        if (hit.collider == null || hitObstacle.collider == true)
            Rotate();
    }

    void CheckForPlayer()
    {
        RaycastHit2D hitPlayer = Physics2D.Raycast(ledgeDectector.position, facingRight ? Vector2.right : Vector2.left, playerDetectDistance, playerLayer);

        if (hitPlayer.collider == true)
            StartCoroutine(PlayerDetected());
    }

    IEnumerator PlayerDetected()
    {
        playerDetected = true;
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(detectionPauseTime);
    }

    IEnumerator PlayerNotDetected()
    {
        yield return new WaitForSeconds(detectionPauseTime);
        playerDetected = false;
    }

    void Rotate()
    {
        transform.Rotate(0, 180, 0);
        facingRight = !facingRight;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(ledgeDectector.position, (facingRight ? Vector2.right : Vector2.left) * playerDetectDistance);
    }
}