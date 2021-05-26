using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public Cell UpCell;
    public Cell DownCell;
    public Cell RightCell;
    public Cell LeftCell;

    public bool Check()
    {
        if(gameObject.transform.childCount != 0)
        {
            if (UpCell)
            {
                if (UpCell.transform.GetChild(UpCell.transform.childCount - 1).gameObject.tag.Equals(
                    gameObject.transform.GetChild(gameObject.transform.childCount - 1).gameObject.tag))
                    return true;
            }
            if (DownCell)
            {
                if (DownCell.transform.GetChild(DownCell.transform.childCount - 1).gameObject.tag.Equals(
                    gameObject.transform.GetChild(gameObject.transform.childCount - 1).gameObject.tag))
                    return true;
            }
            if (RightCell)
            {
                if (RightCell.transform.GetChild(RightCell.transform.childCount - 1).gameObject.tag.Equals(
                    gameObject.transform.GetChild(gameObject.transform.childCount - 1).gameObject.tag))
                    return true;
            }
            if (LeftCell)
            {
                if (LeftCell.transform.GetChild(LeftCell.transform.childCount - 1).gameObject.tag.Equals(
                    gameObject.transform.GetChild(gameObject.transform.childCount - 1).gameObject.tag))
                    return true;
            }
            return false;
        }
        return true;
    }
}
