using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagedState : BaseState
{
    public float KBForce;
    public Vector2 KBAngle; 
    public DamagedState(Enemy enemy, string animationName) : base(enemy, animationName)
    {

    }

    public override void Enter()
    {
        base.Enter();

        ApplyKnocwback();
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

    private void ApplyKnocwback()
    {
        enemy.isKnockedBack = true;
        enemy.rb.velocity = KBAngle * KBForce;
        enemy.isKnockedBack = false;
    }
}
