using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSceneManager : MonoBehaviour
{
    public GameObject choseScreenPanel;
    public GameObject indexPanel;
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Game closed");
    }
    public void Scene1()
    {
        Debug.Log("click roi");
        SceneManager.LoadScene("GameScene1");
    }
    public void Scene2()
    {
        SceneManager.LoadScene("GameScene2");
    }
    public void ChoseScenePanel()
    {
        indexPanel.SetActive(false);
        choseScreenPanel.SetActive(true);
    }
    public void BackToIndex()
    {
        indexPanel.SetActive(true);
        choseScreenPanel.SetActive(false);
    }
}
