using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    #region Variables
    public BaseState currentState;
    public PatrolState patrolState;
    public PlayerDetectedState playerDetectedState;

    public Rigidbody2D rb;
    public Transform ledgeDectector;
    public LayerMask groundLayer, obstacleLayer, playerLayer;

    public bool facingRight = true;

    public float raycastDistance, obstacleDistance, playerDetectDistance;
    public float speed;
    public float detectionPauseTime;

    public GameObject alert;
    #endregion

    #region Unity Callbacks
    private void Awake()
    {
        patrolState = new PatrolState(this, "patrol");
        playerDetectedState = new PlayerDetectedState(this, "player");

        currentState = patrolState;
        currentState.Enter();
    }

    private void Update()
    {
        currentState.LogicUpdate();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentState.PhysicsUpdate();
    }
    #endregion

    #region Checks
    public bool CheckForObstacle()
    {
        RaycastHit2D hit = Physics2D.Raycast(ledgeDectector.position, Vector2.down, raycastDistance, groundLayer);
        RaycastHit2D hitObstacle = Physics2D.Raycast(ledgeDectector.position, Vector2.right, obstacleDistance, obstacleLayer);

        if (hit.collider == null || hitObstacle.collider == true)
            return true;
        else
            return false;
        
    }

   public bool CheckForPlayer()
    {
        RaycastHit2D hitPlayer = Physics2D.Raycast(ledgeDectector.position, facingRight ? Vector2.right : Vector2.left, playerDetectDistance, playerLayer);

        if (hitPlayer.collider == true)
            return true;
        else
            return false;
    }
    #endregion

    #region Other Functions

    public void SwitchState(BaseState newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(ledgeDectector.position, (facingRight ? Vector2.right : Vector2.left) * playerDetectDistance);
    }
    #endregion
}