using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointManager : MonoBehaviour
{
    public Text playerPointText;
    public int playerPoint = 0;
    private string stringPointText;

    private void Update()
    {
        stringPointText = playerPoint.ToString("0");
        playerPointText.text = stringPointText; 
    }
    public virtual void CheckPoint(int kill)
    {
        playerPoint += kill;
    }
}
