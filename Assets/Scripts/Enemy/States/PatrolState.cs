using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PatrolState : BaseState
{
    public PatrolState(Enemy enemy, string animationName) : base (enemy, animationName)
    {
        
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (enemy.CheckForPlayer())
            enemy.SwitchState(enemy.playerDetectedState);
        if (enemy.CheckForObstacle())
            Rotate();

    }
    
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        if (enemy.isKnockedBack)
            return;
        enemy.rb.velocity = enemy.facingDirection == 1 ? Vector2.right * enemy.stats.speed : Vector2.left * enemy.stats.speed;
    }

    void Rotate()
    {
        enemy.transform.Rotate(0, 180, 0);
        enemy.facingDirection = -enemy.facingDirection;
    }
}
