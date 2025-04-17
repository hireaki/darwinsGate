using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float damage;
    public float KBForce;
    public Vector2 KBAngle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponent<IDamageable>();

        if(damageable != null)
        {
            int FacingDirection = transform.position.x > collision.transform.position.x ? 1 : -1;
            collision.GetComponent<Rigidbody2D>().velocity = new Vector2(KBAngle.x * FacingDirection,
                KBAngle.y) * KBForce;
            damageable.Damage(damage);
        }
    }
}
