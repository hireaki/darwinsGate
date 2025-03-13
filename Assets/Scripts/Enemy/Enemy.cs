using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    #region Variables
    public BaseState currentState;
    public PatrolState patrolState;
    public PlayerDetectedState playerDetectedState;
    public ChargeState chargeState;
    public MeleeAttackState meleeAttackState;


    public Rigidbody2D rb;
    public Transform ledgeDectector;
    public LayerMask groundLayer, obstacleLayer, playerLayer, damageableLayer;

    public int facingDirection = 1;
    public float stateTime;

    public StatsSO stats;
    public GameObject alert;
    #endregion

    #region Unity Callbacks
    private void Awake()
    {
        patrolState = new PatrolState(this, "patrol");
        playerDetectedState = new PlayerDetectedState(this, "player");
        chargeState = new ChargeState(this, "charge");
        meleeAttackState = new MeleeAttackState(this, "meleeAttack");

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
        RaycastHit2D hit = Physics2D.Raycast(ledgeDectector.position, Vector2.down, stats.cliffCheckDistance, groundLayer);
        RaycastHit2D hitObstacle = Physics2D.Raycast(ledgeDectector.position, Vector2.right, stats.obstacleDistance, obstacleLayer);

        if (hit.collider == null || hitObstacle.collider == true)
            return true;
        else
            return false;
        
    }
   
    public bool CheckForPlayer()
    {
        RaycastHit2D hitPlayer = Physics2D.Raycast(ledgeDectector.position, facingDirection == 1 ? Vector2.right : Vector2.left, stats.playerDetectDistance, playerLayer);

        if (hitPlayer.collider == true)
            return true;
        else
            return false;
    }

    public bool CheckForMeleeTarget()
    {
        RaycastHit2D hitMeleeTarget = Physics2D.Raycast(ledgeDectector.position, facingDirection == 1 ? Vector2.right : Vector2.left, stats.meleeDetectDistance, playerLayer);

        if (hitMeleeTarget.collider == true)
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
        stateTime = Time.time;
    }
    #endregion
}