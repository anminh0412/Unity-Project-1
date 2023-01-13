using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mes1Manager : MonoBehaviour
{
    public GameObject mes1Canvas;
    [SerializeField] GameObject playerCanvas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            EventCollider();
        }
    }
    private void Update()
    {
        playerCanvas = GameObject.Find("PlayerCanvas");
        if (GameObject.Find("player").GetComponent<PlayerShieldController>().hadShield == true)
        {
            Destroy(gameObject);
        }
    }
    public void BrrBrrButton()
    {
        EventColliderEnd();
    }
    void EventCollider()
    {
        GameObject.Find("player").GetComponent<PlayerController>().enabled = false;
        playerCanvas.GetComponent<Canvas>().enabled = false;
        mes1Canvas.SetActive(true);
        GetComponent<Collider2D>().enabled = false;
    }
    void EventColliderEnd()
    {
        GameObject.Find("player").GetComponent<PlayerController>().enabled = true;
        playerCanvas.GetComponent<Canvas>().enabled = true;
        mes1Canvas.SetActive(false);
    }
}
