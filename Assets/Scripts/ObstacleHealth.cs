using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHleath : MonoBehaviour, IDamageable
{
    public int health;

    public void Damage(float damageAmount)
    {
        health -= (int)damageAmount;
    }

    public void Damage(float damageAmount, float KBForce, Vector2 KBAngle)
    {
        
    }

    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
