using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectedState : BaseState
{
    public PlayerDetectedState(Enemy enemy, string animationName) : base(enemy, animationName)
    {

    }

    public override void Enter()
    {
        base.Enter();

        enemy.rb.velocity = Vector2.zero;
        enemy.alert.SetActive(true);
    }

    public override void Exit()
    {
        enemy.alert.SetActive(false);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!enemy.CheckForPlayer())
            enemy.SwitchState(enemy.patrolState);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
