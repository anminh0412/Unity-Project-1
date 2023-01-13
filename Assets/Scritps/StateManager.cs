using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StateManager : MonoBehaviour
{

    public void ReloadCurrentScrene()
    {
        GameObject.Find("ConditionsToNextLevel").GetComponent<ConditionManager>().enabled = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameObject.Find("DeadEventManager").GetComponent<TryAgainEvent>().TryAgain();
    }
    public void ChangeSceneByName(string name)
    {
        if (name != null)
        {
            GameObject.Find("ConditionsToNextLevel").GetComponent<ConditionManager>().enabled = false; 
            Time.timeScale = 1;
            SceneManager.LoadScene(name);
        }
    }
    public void ReloadCurrentScreneDead()
    {       
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameObject.Find("DeadEventManager").GetComponent<TryAgainEvent>().TryAgain();
    }
    public void ChangeSceneByNameDead(string name)
    {
        if (name != null)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(name);
        }
    }
    public void GoMenuScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenuScene");
        GameObject.Find("DeadEventManager").GetComponent<TryAgainEvent>().TryAgain();
    }
}
