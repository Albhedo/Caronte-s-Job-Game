using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed = 1f;







    void FixedUpdate()
    {
        rb.MovePosition(rb.position + Vector2.right * Time.fixedDeltaTime * speed);
        rb.velocity = new Vector2( speed * Time.fixedDeltaTime, rb.velocity.y);

    }

   
}
