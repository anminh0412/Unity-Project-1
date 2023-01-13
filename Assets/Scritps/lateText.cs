using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lateText : MonoBehaviour
{
    public Text lastText;
    public Collider2D posCollider;
    public Collider2D playerCollider;
    void Update()
    {
        if (posCollider.IsTouching(playerCollider))
        {
            lastText.text = "CHAY CHAY CL DAM NHAU VOI COC DE DU 100 CON THI DUOC CUT";
            Invoke("nextText", 2f);
        }
    }
    void nextText()
    {
        lastText.text = "";
    }
}
