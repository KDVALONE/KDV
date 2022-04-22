using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCotrollerScr : MonoBehaviour {

    public int CellCount;

    public Transform cellGroup;
    public GameObject cellPref;

    void Start ()
    {
        CreateCells();
    }

    void CreateCells() // метод создания ячеек
    {
        for (int i = 0; i<CellCount; i++) 
        {
            // мы создаем обьект префаб в нашей ячейки и присваеваем ей родителя cellGroup
            GameObject tmpCell = Instantiate(cellPref);
            tmpCell.transform.SetParent(cellGroup,false);
            tmpCell.GetComponent<CellScr>().SetState(0);
        }
    }

    void CreatePath()
    { }

}
