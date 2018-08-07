using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    //class MovingPlatform
    public Vector3 MoveBy;
    Vector3 pointA;
    Vector3 pointB;
    Vector3 my_pos;
    Vector3 target;
    bool going_to_a = false;
    float time_to_wait;
    public float stop_time;
    public float speed;
    // Use this for initialization
    void Start()
    {
        pointA = transform.position;
        pointB = pointA + MoveBy;
        time_to_wait = stop_time;
        
        // Как проверить доехала ли платформа
    }
    // Как проверить доехала ли платформа
    private void Update()
    {
        my_pos = transform.position;
        // Определение направления движения
        if (going_to_a)
        {
            target = pointA;
        }
        else
        {
            target = pointB;
        }
        Vector3 destination = target - my_pos;
        destination.z = 0;
        // Засекания времени
        if (isArrived(my_pos, target))
        {
            time_to_wait -= Time.deltaTime;
            if (time_to_wait <= 0)
            {
                //Do something
                time_to_wait = stop_time;
                going_to_a = !going_to_a;   
            }
        }
        else
        {
            transform.position = transform.position + destination.normalized * speed;
        }
        
    }
    bool isArrived(Vector3 pos, Vector3 target)
    {
        pos.z = 0;
        target.z = 0;
        return Vector3.Distance(pos, target) < 0.02f;
    }
}
