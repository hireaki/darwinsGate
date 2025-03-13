using System.Collections;
using UnityEngine;

public class NPCJumping : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce;
    [SerializeField] private float minPause = 1f, maxPause = 3f;

    void Start()
    {
        StartCoroutine(JumpRoutine());
    }
    void Update()
    {
        Physics2D.IgnoreLayerCollision(10, 8);
    }
    IEnumerator JumpRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minPause, maxPause));
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
