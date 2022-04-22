using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour {

    ///<summory>
    /// просто перемещаяет текущий обьект игры
    /// </summory>

        //скорость обьекта
    public Vector2 speed = new Vector2(10, 10);
    private Rigidbody2D rigb2;

    // направление движения обьекта
    public Vector2 direction = new Vector2(-1, 0);

    private Vector2 movement;

    void Update()
    {
        movement = new Vector2(speed.x * direction.x, speed.y * direction.y);

    }

    void FixedUpdate()
    {
        rigb2 = GetComponent<Rigidbody2D>();
        rigb2.velocity = movement;

    }

         



}
