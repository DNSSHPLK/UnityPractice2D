using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    //Стандартная функция, которая вызывается, 
    //когда данный объект сталкивается с другим 
    void OnTriggerEnter2D(Collider2D collider)
    {
        //Пытаемся получить компонент игрока
        PlayerController player = collider.GetComponent<PlayerController>();
        //Упасть мог не только игрок
        if (player != null)
        {
            //Сообщаем уровню, о смерти игрока
            LevelController.current.onPlayerDeath(player);
        }
    }
}