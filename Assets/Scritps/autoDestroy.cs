using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoDestroy : MonoBehaviour
{
    private bool checkF;
    private void Update()
    {
        if(GameObject.Find("TutorialScene"))
        {
            checkF = GameObject.Find("TutorialScene").GetComponent<TutorialManager>().checkF;
            if (checkF)
            {
                Destroy(gameObject);
            }
        }else Destroy(gameObject);
    } 
}
