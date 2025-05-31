using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


public class Enemy : MonoBehaviour, IDamageable
{
    #region Variables
    public BaseState currentState;
    public PatrolState patrolState;
    public PlayerDetectedState playerDetectedState;
    public ChargeState chargeState;
    public MeleeAttackState meleeAttackState;
    public DamagedState damagedState;   


    public Rigidbody2D rb;
    public Transform ledgeDectector;
    public LayerMask groundLayer, obstacleLayer, playerLayer, damageableLayer;

    public bool isKnockedBack = false;
    public int facingDirection = 1;
    public float stateTime;

    public StatsSO stats;
    public float currentHealth;
    public GameObject alert;
    public List<GameObject> dropItems;
    private SpriteRenderer spriteRenderer;
    GameObject player;
    #endregion

    #region Unity Callbacks
    private void Awake()
    {
        patrolState = new PatrolState(this, "patrol");
        playerDetectedState = new PlayerDetectedState(this, "player");
        chargeState = new ChargeState(this, "charge");
        meleeAttackState = new MeleeAttackState(this, "meleeAttack");
        damagedState = new DamagedState(this, "damaged");
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentState = patrolState;
        currentState.Enter();
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currentHealth = stats.maxHealth;
    }
    private void Update()
    {
        currentState.LogicUpdate();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var dist = Vector2.Distance(transform.position, player.transform.position);
        if (dist <= 40)
        {
            currentState.PhysicsUpdate();
        }
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

    public void Damage(float damageAmount)
    {
        PlayerDamage(damageAmount);
    }

    async void PlayerDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            var dropItem = Instantiate(dropItems[UnityEngine.Random.Range(0, dropItems.Count)], transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        spriteRenderer.color = Color.red; // Change color to red on hit
        await Task.Delay(500); // Wait for 0.5 seconds
        spriteRenderer.color = Color.white; // Reset color after hit
    }
    public void Damage(float damageAmount, float KBForce, Vector2 KBAngle)
    {

    }
    #endregion
}