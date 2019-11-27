using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CellScr : MonoBehaviour {

	public int  state;
    public Color normCol, pathCol;
	void Start () {
		
	}

    public void SetState(int i)
    {
        //устанавливает состояние нашей ячейки- обычная или путь
        state = i;
            
        if (i == 0)
                GetComponent<Image>().color = normCol;
        if (i == 1)
            { GetComponent<Image>().color = pathCol;  }

    }

}
