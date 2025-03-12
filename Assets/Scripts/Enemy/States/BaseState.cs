using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState 
{
    protected Enemy enemy;
    protected string animationName;

    public BaseState(Enemy enemy, string animationName)
    {
        this.enemy = enemy;
        this.animationName = animationName;
    }

    public virtual void Enter()
    {
        Debug.Log("Entered" + animationName);
    }

    public virtual void Exit()
    {

    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {

    }
}
