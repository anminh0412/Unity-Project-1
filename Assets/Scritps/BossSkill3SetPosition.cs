using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkill3SetPosition : MonoBehaviour
{
    public Transform player;
    public float posX;
    public float posY;
    public float activeTime;
    public float dampTime = 0.5f;
    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        player = GameObject.Find("player").transform;
        
        activeTime -= Time.deltaTime;
        if(activeTime < 0)
        {
            SetActive();
        }
    }
    private void FixedUpdate()
    {
        Vector3 targetPoint = new Vector3(player.position.x + posX, player.position.y + posX, player.position.z);
        gameObject.transform.position =
         Vector3.MoveTowards(gameObject.transform.position, targetPoint, 1f * Time.deltaTime);
    }
    void SetActive()
    {
        gameObject.SetActive(false);
    }
}
