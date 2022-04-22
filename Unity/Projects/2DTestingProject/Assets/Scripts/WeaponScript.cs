using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {

    ///<summary>
    ///Скрипт создания выстрела перед персонажем (враг или герой)
    ///</summary>>


    //Пребаф снаряда для стрельбы
    public Transform shotPrefab;

    //время перезарядки в секундах
    public float shootingRate = 0.25f;

    //---------Перезарядка---------
    //Мы вычитаем прошедшее время из каждого кадра, если его значение превышает 0, мы просто не можем стрелять
    private float shootCooldown;

    void Start()
    {
        shootCooldown = 0f;
    }

    void Update()
    {
        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }
    }
    /// Создайте новый снаряд, если это возможно
    public void Attack(bool isEnemy)
    {
        if (CanAttack)
        {
            shootCooldown = shootingRate;

            // Создайте новый выстрел
            var shotTransform = Instantiate(shotPrefab) as Transform;

            // Определите положение
            shotTransform.position = transform.position;

            // Свойство врага
            ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
            if (shot != null)
            {
                shot.isEnemyShot = isEnemy;
            }

            // Сделайте так, чтобы выстрел всегда был направлен на него
            MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
            if (move != null)
            {
                move.direction = this.transform.right; // в двухмерном пространстве это будет справа от спрайта
            }
        }
    }
    /// Готово ли оружие выпустить новый снаряд?

    public bool CanAttack
    {
        get
        {
            return shootCooldown <= 0f;
        }
    }
}




