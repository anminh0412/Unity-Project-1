using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    public bool escPanelOn = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !escPanelOn)
        {
            EscEvent();
            escPanelOn = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && escPanelOn)
        {
            EscOffEvent();
            escPanelOn= false;
        }
    }
    public void Win()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().audioSrc.Stop();
        GameObject.Find("MovementSoundManager").GetComponent<MovementSoundManager>().audioSrc.Stop();
        LevelManager.instance.Win();
        Time.timeScale = 0;
    }
    public void NextLevel()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().audioSrc.Stop();
        GameObject.Find("MovementSoundManager").GetComponent<MovementSoundManager>().audioSrc.Stop();
        LevelManager.instance.NextLevel();
        Time.timeScale = 0;
    }
    public void EscEvent()
    {
        LevelManager.instance.EscEvent();
        Time.timeScale = 0;
    }
    public void EscOffEvent()
    {
        LevelManager.instance.EscOffEvent();
        Time.timeScale = 1;
    }


}
