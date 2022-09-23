using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    public int tileLine;

    public List<int> triggerObjectTileLineList;

    private GameObject tileXSprite;

    private GridManager gridManager;

    [SerializeField] GameObject tileParent;

    private void Awake()
    {
        gridManager = GameObject.FindObjectOfType<GridManager>();
        tileXSprite = transform.GetChild(0).gameObject;
    }

    public void ShowXSprite()//X Sprite' ýný görünür yapýp trigger özelliðimizi açýyor
    {
        transform.tag = "Selected";
        tileXSprite.SetActive(true);
    }
    public void SetTileSelectable()//Tile'larý tekrardan seçilebilir hale getirmemize yarýyor 
    {
        tileXSprite.SetActive(false);
        gameObject.tag = "Tile";
    }

    public void CheckTileMatch()
    {
        if (!gameObject.CompareTag("Selected"))
        {
            return;
        }

        if (gridManager.gridWidth == 3)
        {
            if (tileLine - 1 < gridManager.gridWidth)// 3x3 teki ilk sýrada mý diye kontrol ediyor
            {
                if (tileLine == 1)// en sola koyulan X ler için filtreleme yapýyor
                {
                    if (CheckRightDown() && CheckRightDoubleDown())
                    {
                        SetSelectableTile(gameObject);
                        SetSelectableTile(gridManager.tileList[CalculateRightDownCross(tileLine)].gameObject);
                        SetSelectableTile(gridManager.tileList[CalculateRightDownCross(CalculateRightDownCross(tileLine)) + 1].gameObject);
                    }
                    if (CheckDown() && CheckDoubleDown())
                    {
                        SetSelectableTile(gameObject);
                        SetSelectableTile(gridManager.tileList[CalculateDown(CalculateDown(tileLine)) + 1].gameObject);
                        SetSelectableTile(gridManager.tileList[CalculateDown(tileLine)].gameObject);
                    }
                    if (CheckRight() && CheckDoubleRight())
                    {
                        SetSelectableTile(gameObject);
                        SetSelectableTile(gridManager.tileList[tileLine - 2].gameObject);
                        SetSelectableTile(gridManager.tileList[tileLine - 3].gameObject);
                    }
                }
                else
                {
                    if (CheckDown() && CheckDoubleDown())
                    {
                        SetSelectableTile(gameObject);
                        SetSelectableTile(gridManager.tileList[CalculateDown(CalculateDown(tileLine)) + 1].gameObject);
                        SetSelectableTile(gridManager.tileList[CalculateDown(tileLine)].gameObject);
                    }
                    if (CheckLeftDown() && CheckLeftDoubleDown())
                    {
                        SetSelectableTile(gameObject);
                        SetSelectableTile(gridManager.tileList[CalculateLeftDownCross(tileLine)].gameObject);
                        SetSelectableTile(gridManager.tileList[CalculateLeftDownCross(CalculateLeftDownCross(tileLine)) + 1].gameObject);
                    }
                    if (CheckLeft() && CheckDoubleLeft())
                    {
                        SetSelectableTile(gameObject);
                        SetSelectableTile(gridManager.tileList[tileLine].gameObject);
                        SetSelectableTile(gridManager.tileList[tileLine + 1].gameObject);
                    }
                }
            }
            else if (tileLine > (gridManager.gridWidth * 2) && tileLine < (gridManager.gridWidth * gridManager.gridWidth))//3x3 teki son sýradayý kontrol ediyor
            {
                if (CheckLeftUp() && CheckDoubleLeftUp())
                {
                    SetSelectableTile(gameObject);
                    SetSelectableTile(gridManager.tileList[CalculateLeftUpCross(tileLine)].gameObject);
                    SetSelectableTile(gridManager.tileList[CalculateLeftUpCross(CalculateLeftUpCross(tileLine)) + 1].gameObject);
                }
                if (CheckUp() && CheckDoubleUp())
                {
                    SetSelectableTile(gameObject);
                    SetSelectableTile(gridManager.tileList[CalculateUp(tileLine)].gameObject);
                    SetSelectableTile(gridManager.tileList[CalculateUp(CalculateUp(tileLine)) + 1].gameObject);
                }
                if (CheckRightUp() && CheckDoubleRightUp())
                {
                    SetSelectableTile(gameObject);
                    SetSelectableTile(gridManager.tileList[CalculateRightUpCross(tileLine)].gameObject);
                    SetSelectableTile(gridManager.tileList[CalculateRightUpCross(CalculateRightUpCross(tileLine)) + 1].gameObject);
                }
                if (CheckRight() && CheckLeft())
                {
                    SetSelectableTile(gameObject);
                    SetSelectableTile(gridManager.tileList[tileLine - 2].gameObject);
                    SetSelectableTile(gridManager.tileList[tileLine].gameObject);
                }
                if (CheckLeft() && CheckDoubleLeft())
                {
                    SetSelectableTile(gameObject);
                    SetSelectableTile(gridManager.tileList[tileLine].gameObject);
                    SetSelectableTile(gridManager.tileList[tileLine + 1].gameObject);
                }
                if (CheckRight() && CheckDoubleRight())
                {
                    SetSelectableTile(gameObject);
                    SetSelectableTile(gridManager.tileList[tileLine - 2].gameObject);
                    SetSelectableTile(gridManager.tileList[tileLine - 3].gameObject);
                }
            }
        }
        else
        {
            if (tileLine - 1 < gridManager.gridWidth * 2)
            {
                if (CheckRightDown() && CheckRightDoubleDown())
                {
                    SetSelectableTile(gameObject);
                    SetSelectableTile(gridManager.tileList[CalculateRightDownCross(tileLine)].gameObject);
                    SetSelectableTile(gridManager.tileList[CalculateRightDownCross(CalculateRightDownCross(tileLine)) + 1].gameObject);
                }
                if (CheckDown() && CheckDoubleDown())
                {
                    SetSelectableTile(gameObject);
                    SetSelectableTile(gridManager.tileList[CalculateDown(CalculateDown(tileLine)) + 1].gameObject);
                    SetSelectableTile(gridManager.tileList[CalculateDown(tileLine)].gameObject);
                }
                if (CheckLeftDown() && CheckLeftDoubleDown())
                {
                    SetSelectableTile(gameObject);
                    SetSelectableTile(gridManager.tileList[CalculateLeftDownCross(tileLine)].gameObject);
                    SetSelectableTile(gridManager.tileList[CalculateLeftDownCross(CalculateLeftDownCross(tileLine)) + 1].gameObject);
                }
                if (CheckRight() && CheckLeft())
                {
                    SetSelectableTile(gameObject);
                    SetSelectableTile(gridManager.tileList[tileLine - 2].gameObject);
                    SetSelectableTile(gridManager.tileList[tileLine].gameObject);
                }
                if (CheckLeft() && CheckDoubleLeft())
                {
                    SetSelectableTile(gameObject);
                    SetSelectableTile(gridManager.tileList[tileLine].gameObject);
                    SetSelectableTile(gridManager.tileList[tileLine + 1].gameObject);
                }
                if (CheckRight() && CheckDoubleRight())
                {
                    SetSelectableTile(gameObject);
                    SetSelectableTile(gridManager.tileList[tileLine - 2].gameObject);
                    SetSelectableTile(gridManager.tileList[tileLine - 3].gameObject);
                }
                return;
            }
            else if (tileLine - 1 < gridManager.gridWidth * gridManager.gridWidth && tileLine > gridManager.gridWidth * (gridManager.gridWidth - 2))
            {
                if (CheckLeftUp() && CheckDoubleLeftUp())
                {
                    SetSelectableTile(gameObject);
                    SetSelectableTile(gridManager.tileList[CalculateLeftUpCross(tileLine)].gameObject);
                    SetSelectableTile(gridManager.tileList[CalculateLeftUpCross(CalculateLeftUpCross(tileLine)) + 1].gameObject);
                }
                if (CheckUp() && CheckDoubleUp())
                {
                    SetSelectableTile(gameObject);
                    SetSelectableTile(gridManager.tileList[CalculateUp(tileLine)].gameObject);
                    SetSelectableTile(gridManager.tileList[CalculateUp(CalculateUp(tileLine)) + 1].gameObject);
                }
                if (CheckRightUp() && CheckDoubleRightUp())
                {
                    SetSelectableTile(gameObject);
                    SetSelectableTile(gridManager.tileList[CalculateRightUpCross(tileLine)].gameObject);
                    SetSelectableTile(gridManager.tileList[CalculateRightUpCross(CalculateRightUpCross(tileLine)) + 1].gameObject);
                }
                if (CheckRight() && CheckLeft())
                {
                    SetSelectableTile(gameObject);
                    SetSelectableTile(gridManager.tileList[tileLine - 2].gameObject);
                    SetSelectableTile(gridManager.tileList[tileLine].gameObject);
                }
                return;
            }

            if (CheckDoubleLeftUp() && CheckRightDown())
            {
                SetSelectableTile(gameObject);
                SetSelectableTile(gridManager.tileList[CalculateLeftUpCross(tileLine)].gameObject);
                SetSelectableTile(gridManager.tileList[CalculateRightDownCross(tileLine)].gameObject);
            }
            if (CheckLeftUp() && CheckDoubleLeftUp())
            {
                SetSelectableTile(gameObject);
                SetSelectableTile(gridManager.tileList[CalculateLeftUpCross(tileLine)].gameObject);
                SetSelectableTile(gridManager.tileList[CalculateLeftUpCross(CalculateLeftUpCross(tileLine)) + 1].gameObject);
            }
            if (CheckRightDown() && CheckRightDoubleDown())
            {
                SetSelectableTile(gameObject);
                SetSelectableTile(gridManager.tileList[CalculateRightDownCross(tileLine)].gameObject);
                SetSelectableTile(gridManager.tileList[CalculateRightDownCross(CalculateRightDownCross(tileLine)) + 1].gameObject);
            }
            if (CheckUp() && CheckDown())
            {
                SetSelectableTile(gameObject);
                SetSelectableTile(gridManager.tileList[CalculateUp(tileLine)].gameObject);
                SetSelectableTile(gridManager.tileList[CalculateDown(tileLine)].gameObject);
            }
            if (CheckDown() && CheckDoubleDown())
            {
                SetSelectableTile(gameObject);
                SetSelectableTile(gridManager.tileList[CalculateDown(CalculateDown(tileLine)) + 1].gameObject);
                SetSelectableTile(gridManager.tileList[CalculateDown(tileLine)].gameObject);
            }
            if (CheckUp() && CheckDoubleUp())
            {
                SetSelectableTile(gameObject);
                SetSelectableTile(gridManager.tileList[CalculateUp(tileLine)].gameObject);
                SetSelectableTile(gridManager.tileList[CalculateUp(CalculateUp(tileLine)) + 1].gameObject);
            }
            if (CheckRightUp() && CheckLeftDown())
            {
                SetSelectableTile(gameObject);
                SetSelectableTile(gridManager.tileList[CalculateRightUpCross(tileLine)].gameObject);
                SetSelectableTile(gridManager.tileList[CalculateLeftDownCross(tileLine)].gameObject);
            }
            if (CheckRightUp() && CheckDoubleRightUp())
            {
                SetSelectableTile(gameObject);
                SetSelectableTile(gridManager.tileList[CalculateRightUpCross(tileLine)].gameObject);
                SetSelectableTile(gridManager.tileList[CalculateRightUpCross(CalculateRightUpCross(tileLine)) + 1].gameObject);
            }
            if (CheckLeftDown() && CheckLeftDoubleDown())
            {
                SetSelectableTile(gameObject);
                SetSelectableTile(gridManager.tileList[CalculateLeftDownCross(tileLine)].gameObject);
                SetSelectableTile(gridManager.tileList[CalculateLeftDownCross(CalculateLeftDownCross(tileLine)) + 1].gameObject);
            }
            if (CheckRight() && CheckLeft())
            {
                SetSelectableTile(gameObject);
                SetSelectableTile(gridManager.tileList[tileLine - 2].gameObject);
                SetSelectableTile(gridManager.tileList[tileLine].gameObject);
            }
            if (CheckLeft() && CheckDoubleLeft())
            {
                SetSelectableTile(gameObject);
                SetSelectableTile(gridManager.tileList[tileLine - 2].gameObject);
                SetSelectableTile(gridManager.tileList[tileLine - 3].gameObject);
            }
            if (CheckRight() && CheckDoubleRight())
            {
                SetSelectableTile(gameObject);
                SetSelectableTile(gridManager.tileList[tileLine].gameObject);
                SetSelectableTile(gridManager.tileList[tileLine + 1].gameObject);
            }
        }
    }
    private void SetSelectableTile(GameObject _gameObject)
    {
        _gameObject.transform.GetChild(0).gameObject.SetActive(false);
        _gameObject.tag = "Tile";
    }

    #region CheckMethods
    private bool CheckRightDown()
    {
        return gridManager.tileList[CalculateRightDownCross(tileLine)].gameObject.CompareTag("Selected");
    }
    private bool CheckRightDoubleDown()
    {
        return gridManager.tileList[CalculateRightDownCross(CalculateRightDownCross(tileLine)) + 1].gameObject.CompareTag("Selected");
    }
    private bool CheckDown()
    {
        return gridManager.tileList[CalculateDown(tileLine)].gameObject.CompareTag("Selected");
    }
    private bool CheckDoubleDown()
    {
        return gridManager.tileList[CalculateDown(CalculateDown(tileLine)) + 1].gameObject.CompareTag("Selected");
    }
    private bool CheckRight()
    {
        return gridManager.tileList[tileLine].gameObject.CompareTag("Selected");
    }
    private bool CheckDoubleRight()
    {
        return gridManager.tileList[tileLine + 1].gameObject.CompareTag("Selected");
    }

    private bool CheckLeft()
    {
        return gridManager.tileList[tileLine - 2].gameObject.CompareTag("Selected");
    }
    private bool CheckDoubleLeft()
    {
        return gridManager.tileList[tileLine - 3].gameObject.CompareTag("Selected");
    }

    private bool CheckLeftDown()
    {
        return gridManager.tileList[CalculateLeftDownCross(tileLine)].gameObject.CompareTag("Selected");
    }
    private bool CheckLeftDoubleDown()
    {
        return gridManager.tileList[CalculateLeftDownCross(CalculateLeftDownCross(tileLine)) + 1].gameObject.CompareTag("Selected");
    }
    private bool CheckLeftUp()
    {
        return gridManager.tileList[CalculateLeftUpCross(tileLine)].gameObject.CompareTag("Selected");
    }
    private bool CheckDoubleLeftUp()
    {
        return gridManager.tileList[CalculateLeftUpCross(CalculateLeftUpCross(tileLine)) + 1].gameObject.CompareTag("Selected");
    }

    private bool CheckUp()
    {
        return gridManager.tileList[CalculateUp(tileLine)].gameObject.CompareTag("Selected");
    }

    private bool CheckDoubleUp()
    {
        return gridManager.tileList[CalculateUp(CalculateUp(tileLine)) + 1].gameObject.CompareTag("Selected");
    }
    private bool CheckRightUp()
    {
        return gridManager.tileList[CalculateRightUpCross(tileLine)].gameObject.CompareTag("Selected");
    }
    private bool CheckDoubleRightUp()
    {
        return gridManager.tileList[CalculateRightUpCross(CalculateRightUpCross(tileLine)) + 1].gameObject.CompareTag("Selected");
    }
    #endregion
    #region CalculateMethods
    private int CalculateUp(int tileLine)
    {
        int result = Convert.ToInt32(tileLine - (gridManager.gridWidth + 1));
        return result;
    }
    private int CalculateDown(int tileLine)
    {
        int result = Convert.ToInt32(gridManager.gridWidth + tileLine - 1);
        return result;
    }
    private int CalculateLeftUpCross(int tileLine)
    {
        int result = Convert.ToInt32(tileLine - (gridManager.gridWidth + 2));
        return result;
    }
    private int CalculateRightDownCross(int tileLine)
    {
        int result = Convert.ToInt32(gridManager.gridWidth + tileLine);
        return result;
    }
    private int CalculateRightUpCross(int tileLine)
    {
        int result = Convert.ToInt32(tileLine - (gridManager.gridWidth));
        return result;
    }
    private int CalculateLeftDownCross(int tileLine)
    {
        int result = Convert.ToInt32(gridManager.gridWidth + tileLine - 2);
        return result;
    }
    #endregion

}
