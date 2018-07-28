
using UnityEngine;

public class PlayerController : MonoBehaviour {
    Rigidbody2D RB;
    SpriteRenderer SR;    
    public float speed = 3;

    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        RB.freezeRotation = true;   
    }
    void FixedUpdate()
    {
        //[-1, 1]
        float value = Input.GetAxis("Horizontal");
        if (Mathf.Abs(value) > 0)
        {
            Vector2 vel = RB.velocity;
            vel.x = value * speed;
            RB.velocity = vel;
            if (value < 0)
            {
                SR.flipX = true;
            }
            else 
            {
                SR.flipX = false;
            }
        }
        float value1 = Input.GetAxis("Vertical");
        if (Mathf.Abs(value1) > 0)
        {
            Vector2 vel = RB.velocity;
            vel.y = value1 * speed;
            RB.velocity = vel;
        }

    }
    private void Update()
    {
        Debug.Log(Time.deltaTime);
    }
}
