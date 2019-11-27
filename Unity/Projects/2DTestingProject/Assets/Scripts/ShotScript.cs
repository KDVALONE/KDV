using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour {

    ///<summary>
    ///поведение снаряда
    ///</summary>>

    //причененный вреж (переменная дизайнера)
    public int damage = 1;

    //снаряд наносит повреждение игроку или врагу.

    public bool isEnemyShot = false;

    void Start()
    {
        Destroy(gameObject, 20); // ограничение времяни жизни в 20 секунд, чтоб избежать утечек.


    }


}
