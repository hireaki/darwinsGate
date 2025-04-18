using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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
               PlayerHasDamaged(hitCollider, damageable);
            }
        }
        enemy.SwitchState(enemy.patrolState);
    }

    async void PlayerHasDamaged(Collider2D player, IDamageable damageable)
    {
        SpriteRenderer spriteRenderer = player.GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.red; // Change color to red on hit
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(enemy.stats.knockBackAngle.x * enemy.facingDirection,
            enemy.stats.knockBackAngle.y) * enemy.stats.knockbackForce;
        ; damageable.Damage(enemy.stats.damageAmount);

        await Task.Delay(500); // Wait for 0.1 seconds
        spriteRenderer.color = Color.white; // Reset color after hit
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
