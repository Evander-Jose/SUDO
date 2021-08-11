using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BetterJump : MonoBehaviour
{
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    Rigidbody2D rb2D;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rb2D.velocity.y < 0)
        {
            rb2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        } else if(rb2D.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
}
