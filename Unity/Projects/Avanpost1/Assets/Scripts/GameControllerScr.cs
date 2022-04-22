using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScr : MonoBehaviour {



    public List<GameObject> wayPoints = new List<GameObject>();


}

/*
    public int cellCount;
    int[] pathID = {    23, 24, 25, 47, 69, 70, 71, 93, 94, 95, 96,
                        97, 119, 141, 142, 164, 165, 166, 167,
                        189, 211, 212, 213, 214, 215, 193, 194,
                        195, 196, 196, 197, 198};

    List<CellScr> AllCells = new List<CellScr>();

    public GameObject cellPref;
    public Transform cellGroup;

	void Start ()
    {
        CreateCells();
        CreatePath();
        	
	}

    void CreateCells()
    {
        for (int i = 0; i < cellCount; i++)
        {
            GameObject tmpCell = Instantiate(cellPref);
            tmpCell.transform.SetParent(cellGroup, false);
           // tmpCell.GetComponent<CellScr>().id = i + 1;
           // tmpCell.GetComponent<CellScr>().SetState(0);
            AllCells.Add(tmpCell.GetComponent<CellScr>());//Добавляем текущую ячейку в список AllCells
        }
    }

    void CreatePath()
    {
      //  for (int i = 0; i < pathID.Length; i++)
       //     AllCells[pathID[i] - 1].SetState(1);// так как списки и массивы начинаются с 0 а ID у нас с 1 то мы вычетаем из ID -1

    } */ // код с первого урока