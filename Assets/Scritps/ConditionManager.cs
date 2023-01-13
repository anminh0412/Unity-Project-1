using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConditionManager : MonoBehaviour
{
    public int neededPoint;
    private int playerPoint;
    private GameObject player;
    protected string sceneName;

    private void Update()
    {
        sceneName = SceneManager.GetActiveScene().name;
        player = GameObject.Find("player");
        playerPoint = player.GetComponent<PointManager>().playerPoint;
        if (playerPoint >= neededPoint && sceneName == "GameScene1")
        {
            GameObject.Find("LevelManager").GetComponent<LevelComplete>().NextLevel();
        }
        if(!GameObject.Find("boss") && sceneName == "GameScene2")
        {
            GameObject.Find("LevelManager").GetComponent<LevelComplete>().Win();
        }
    }
}
