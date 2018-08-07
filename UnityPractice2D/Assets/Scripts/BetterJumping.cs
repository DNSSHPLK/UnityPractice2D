using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJumping : MonoBehaviour {
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    Rigidbody2D RB;
    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (RB.velocity.y  < 0)
        {
            RB.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (RB.velocity.y > 0)
        {
            RB.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

}
