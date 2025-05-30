using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="StatsSO")]
public class StatsSO : ScriptableObject
{
    [Header("General Stats")]
    public float maxHealth = 20;

    [Header("PatrolState")]
    public float speed;
    public float cliffCheckDistance;
    public float obstacleDistance;

    [Header("Player Detection")]
    public float playerDetectDistance;
    public float detectionPauseTime;
    public float playerDetectedWaitTime;

    [Header("Charge State")]
    public float chargeTime;
    public float chargeSpeed;
    public float meleeDetectDistance;

    [Header("Melee Attack State")]
    public float damageAmount;
    public Vector2 knockBackAngle;
    public float knockbackForce;
}
