using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionManager : MonoBehaviour
{
    public Transform player;
    private void Start()
    {
        GameObject.Find("nextLevelPanel").SetActive(false);
        player = GameObject.Find("player").transform;
        player.position = new Vector3(0, 0, 0);
        Time.timeScale = 1;
    }
}
