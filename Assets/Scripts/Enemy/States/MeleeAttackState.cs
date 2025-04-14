using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackState : BaseState
{
    public MeleeAttackState(Enemy enemy, string animationName) : base(enemy, animationName)
    {

    }

    public override void Enter()
    {
        base.Enter();

        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(enemy.ledgeDectector.position, enemy.stats.meleeDetectDistance, enemy.damageableLayer);

        foreach (Collider2D hitCollider in hitColliders)
        {
            IDamageable damageable = hitCollider.GetComponent<IDamageable>();

            if (damageable != null)
            {
                PlayerMovement playerMovement = hitCollider.GetComponent<PlayerMovement>();
                playerMovement.enabled = false;
                hitCollider.GetComponent<Rigidbody2D>().velocity = new Vector2(enemy.stats.knockBackAngle.x * enemy.facingDirection,
                    enemy.stats.knockBackAngle.y) * enemy.stats.knockbackForce;
                playerMovement.enabled = true;
                damageable.Damage(enemy.stats.damageAmount);
            }
        }

        enemy.SwitchState(enemy.patrolState);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
