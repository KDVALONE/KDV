using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour {

    ///<summary>
    /// Задание очко жизни и урона.
    ///</summary>>

    //всего хитпоинтов
    public int hp = 1;

    //врга или игрок
    public bool isEnemy = true;

    //наносим урон, и проверяем должен ли обьект быть уничтожен
    public void Damage(int damageCount)
    {
        hp -= damageCount;
        if (hp <= 0)
        {
            //смерть
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        //Это выстрел ?
        ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
        if (shot != null)
        {
            //избегайте дружественног оогня
            if (shot.isEnemyShot != isEnemy)
            {
                Damage(shot.damage);
                //уничтожить выстрел
                Destroy(shot.gameObject); //Всегда цельтесь в игровой обьект иначе вы просто удалите 

            }

        }

    }

}
