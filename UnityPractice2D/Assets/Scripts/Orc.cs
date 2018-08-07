using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : MonoBehaviour {
    public float Delta;
    public Vector3 pointA;
    public Vector3 pointB;
    public float speed;
    public float speedrun;
    public enum Mode
    {
        Go_To_A, Go_To_B, Attack
    }
    Mode mode = Mode.Go_To_B;   //начальное состояние
    Rigidbody2D RB;
    SpriteRenderer SR;
    private void Start()
    {
        pointA = transform.position;
        pointB = pointA + new Vector3(Delta, 0, 0);
        RB = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();

    }
    private void FixedUpdate()
    {

        Vector3 vel = RB.velocity;
        if (mode == Mode.Go_To_A)
        {
            vel.x = -0.5f;
            SR.flipX = true;
            if (isArrived(transform.position, pointA))
            {
                mode = Mode.Go_To_B;
                Debug.Log("B");
            }
        }
        else if (mode == Mode.Go_To_B)
        {
            vel.x = 0.5f;
            SR.flipX = false;
            if (isArrived(transform.position, pointB))
            {
                mode = Mode.Go_To_A;
                Debug.Log("A");
            }
        }
        else
        {
          Vector3  Player_position = PlayerController.current.transform.position;
            if ((transform.position - Player_position).x > 0)
            {
                vel.x = -speedrun;
            }
            else
            {
                vel.x = speedrun;
            }
        }
        //Debug.Log(mode);
        //Debug.Log(vel);
        transform.position += vel*Time.deltaTime;
        
    }
    bool isArrived(Vector3 pos, Vector3 target)
    {
        
        pos.z = 0;
        target.z = 0;
        Debug.Log(pos.x  - target.x);
        return (pos.x - target.x) > 0.01f;
    }
}
