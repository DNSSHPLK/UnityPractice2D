using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroFollower : MonoBehaviour {
    public GameObject Player;
    private void FixedUpdate()
    {
        //Получаем доступ к компоненте Transform кролика
        Transform Player_transform = Player.transform;

        //Получаем доступ к компоненте Transform камеры
        Transform camera_transform = this.transform;

        //Получаем доступ к координатам кролика
        Vector3 rabit_position = Player_transform.position;
        Vector3 camera_position = camera_transform.position;

        //Двигаем камеру только по X,Y
        camera_position.x = rabit_position.x;
        camera_position.y = rabit_position.y;

        //Задаем координаты камеры
        camera_transform.position = camera_position;
    }
}
