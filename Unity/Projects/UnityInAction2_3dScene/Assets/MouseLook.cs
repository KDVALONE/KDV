using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {

	public enum RotationAxes // обьявляем структуру данных enum, которая будет сопоставлять имена с параметрами
	{
		MouseXAndY = 0,
		    MouseX = 1,
		    MouseY = 2

	}
	public RotationAxes axes = RotationAxes.MouseXAndY; // общедоступная переменная которая появиться в редакторе Unity
	public float sensitivityHor = 9.0f;
	public float sensitivityVert = 9.0f;

	public float minimumVert = -45.0f;
	public float maximumVert = 45.0f;

	private float _rotationX = 0; // закрытая переменаая для угла поворота по вертикале
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (axes == RotationAxes.MouseX) {// здесь код для вращения только по горизонтали
			transform.Rotate (0, Input.GetAxis ("Mouse X") * sensitivityHor, 0); // поворот по вокруг Y, GetAxis возвращает координаты мыши, а на вход принимает требемую координатиу

		} else if(axes == RotationAxes.MouseY) {// здесь код для вращения только по вертикали.
		
			_rotationX -= Input.GetAxis ("Mouse Y") * sensitivityVert; // увеличиваем угол поворота в соответствии c перемещеньем указателя.

			_rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert); // фиксируем угол поворота по вертикали, в диапазоне заданным минимальными значениями

			float rotationY = transform.localEulerAngles.y; // сохраняем одинаковый угол поворота вокруг Y, вращение в горизонтальной плоскости отсутствует.
				
			transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0); // создаем новый ектор из сохраненнхзначений поворота

				

		} else {// это комбинированный поворот


		}
	}

 	
}
