using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    public Animator hitParticleAnimation;
    public GameObject hitParticleObject;
    public int health;
    public int maxHealth = 50;
    public Slider slider;

    void Start()
    {
        health = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = health;
    }

    public void Damage(float damageAmount)
    {
        hitParticleObject.SetActive(true);
        hitParticleAnimation.Play("HitParticle");
        slider.maxValue = maxHealth;
        slider.value = health;

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
