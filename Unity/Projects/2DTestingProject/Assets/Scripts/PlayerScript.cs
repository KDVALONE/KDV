using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    // Скорость движения
    //(Сначала определим публичную переменную, которая будет 
    //отображаться в окне "Инспектор". Это скорость, используемая для корабля.)
    public Vector2 speed = new Vector2(50, 50); // в UNITY публичные переменные можно редактировать напрямую из IDE, по этому мы не всегда должны их делать приват.

    private Rigidbody2D rigb2;
    //Направлене движения
    //(Сохраним движение для каждого кадра)
    private Vector2 movement;
    
	void Update ()
    {
        //Извлечь информацию оси.
        //(Используем дефолтную ось, которую можно отредактировать в "Edit" -> "Project Settings" -> "Input".
        //При этом мы получим целые значения между [-1, 1],
        //где 0 будет означать, что корабль неподвижен, 1 - движение вправо, -1 - влево.)
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        // Движение в каждом направлении
        // (Умножим направление на скорость.)
        movement = new Vector2(speed.x * inputX, speed.y * inputY);

        // 5 - Стрельба
        bool shoot = Input.GetButtonDown("Fire1");
        shoot |= Input.GetButtonDown("Fire2");
        // Замечание: Для пользователей Mac, Ctrl + стрелка - это плохая идея

        if (shoot)
        {
            WeaponScript weapon = GetComponent<WeaponScript>();
            if (weapon != null)
            {
                // ложь, так как игрок не враг
                weapon.Attack(false);
            }
        }


    }

    void FixedUpdate()
    {
        //перемещение в любом направлении, () FixedUpdate() вызывается каждый раз через определеннок 
        //число кадров. Вы можете вызывать этот метод вместо Update() когда имеете дело с физикой ("RigidBody" и др.).
        
        rigb2 = GetComponent<Rigidbody2D>();
        rigb2.velocity = movement;
    }

                                                                                    

}
