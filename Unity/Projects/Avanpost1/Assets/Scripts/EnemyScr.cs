using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScr : MonoBehaviour {

    List<GameObject> wayPoints = new List<GameObject>();

    int wayIndex = 0;
    int speed = 10;
    private void Start()
    {
        wayPoints = GameObject.Find("Main Camera").GetComponent<GameControllerScr>().wayPoints;
     }
    


    void Update () {
        Move();
        	
	}

    private void Move() // функция движения врага.
    {
        Vector3 dir = wayPoints[wayIndex].transform.position - transform.position; // dir хранит направление движения врага. Из индекса текущего вейпоинта вычетаем индекс врага.

        transform.Translate(dir.normalized * Time.deltaTime * speed); //функция перемешения врага, приставка нормалайзд делает из вектора 1 для удобства контроля. По Delta time нужно гуглит в нете.
        if (Vector3.Distance(transform.position, wayPoints[wayIndex].transform.position) < 3f)    //проверка на расстояние врага до текущего вейпойнта

            if (wayIndex < wayPoints.Count - 1)
                wayIndex++;
            else
                Destroy(gameObject);
     }

}
