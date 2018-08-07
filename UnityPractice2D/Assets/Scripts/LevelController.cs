using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour 
{
    public static LevelController current;
    void Awake()
    {
        current = this;
    }
    //class LevelController
    Vector3 startingPosition;

    public void setStartPosition(Vector3 pos)
    {
        this.startingPosition = pos;
    }
    public void onPlayerDeath(PlayerController player)
    {
        //При смерти игрока возвращаем на начальную позицию
        player.transform.position = startingPosition;
    }
}

