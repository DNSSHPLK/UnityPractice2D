using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour {
    [Range(1, 10)]
    public float jumpVelocity;
    Animator AN;
    bool isGrounded = false;
    bool secondJump = false;

    private void Awake()
    {
        AN = GetComponent<Animator>();
    }
    private void Update()
    {
        if (!isGrounded && Input.GetButtonDown("Jump") && !secondJump) {
            secondJump = true;
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVelocity;
        }
        if (Input.GetButtonDown("Jump") && !secondJump)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVelocity;
        }
    }
    private void FixedUpdate()
    {
        Vector3 from = transform.position + Vector3.up * 0.3f;
        Vector3 to = transform.position + Vector3.down * 2f;
        int layer_id = 1 << LayerMask.NameToLayer("Ground");
        RaycastHit2D hit = Physics2D.Linecast(from, to, layer_id);
        if (hit)
        {
            isGrounded = true;
            secondJump = false;
            if (hit.transform.GetComponent<MovingPlatform>())
            {
                PlayerController.SetNewParent(transform, hit.transform);
            }
            
        }
        else
        {
            isGrounded = false;
            PlayerController.SetNewParent(transform, transform.GetComponent<PlayerController>().heroParent);
        }
        //Нарисовать линию (для разработчика)
        Debug.DrawLine(from, to, Color.red);
        AN.SetBool("IsJumping", !isGrounded);
    }
}
