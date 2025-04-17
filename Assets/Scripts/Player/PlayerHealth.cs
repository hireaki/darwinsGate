using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    public Animator hitParticleAnimation;
    public GameObject hitParticleObject;
    public int health;
    public void Damage(float damageAmount)
    {
        hitParticleObject.SetActive(true);
        hitParticleAnimation.Play("HitParticle");

        health -= (int)damageAmount;
    }

    public void Damage(float damageAmount, float KBForce, Vector2 KBAngle)
    {
        
    }

    public void DoneHitBox()
    {
        hitParticleObject.SetActive(false);
    }
    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
