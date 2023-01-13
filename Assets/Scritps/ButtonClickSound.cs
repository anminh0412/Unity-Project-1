using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClickSound : MonoBehaviour
{
    public void ButtonClick()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySound("buttonClick");
    }
}
