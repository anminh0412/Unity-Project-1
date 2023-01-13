using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadEvend : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<PlayerController>().enabled = false;
        transform.eulerAngles = new Vector3(0, 0, 0);
        if (GameObject.Find("TutorialScene"))
        {
            GameObject.Find("TutorialScene").GetComponent<TutorialManager>().DestroyEvent();
        }
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySound("playerDie");
        Invoke("Destroy", 1.8f);
    }
    void Destroy()
    {
        LevelManager.instance.GameOver();
        Time.timeScale = 0;
        gameObject.SetActive(false);
    }
}
