using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mes2Manager : MonoBehaviour
{
    public GameObject mes2Canvas;
    [SerializeField] GameObject playerCanvas;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            if (GameObject.Find("MovementSoundManager").GetComponent<MovementSoundManager>().audioSrc.isPlaying)
            {
                GameObject.Find("MovementSoundManager").GetComponent<MovementSoundManager>().audioSrc.Stop();
            }
            EventCollider();
        }
    }
    private void Update()
    {
        playerCanvas = GameObject.Find("PlayerCanvas");
    }
    public void OkeButton()
    {
        EventColliderEnd();
    }
    void EventCollider()
    {
        GameObject.Find("player").GetComponent<PlayerController>().enabled = false;
        playerCanvas.GetComponent<Canvas>().enabled = false;
        mes2Canvas.SetActive(true);
        GetComponent<Collider2D>().enabled = false;
        Time.timeScale = 0;
    }
    void EventColliderEnd()
    {
        GameObject.Find("player").GetComponent<PlayerController>().enabled = true;
        playerCanvas.GetComponent<Canvas>().enabled = true;
        mes2Canvas.SetActive(false);
        Time.timeScale = 1;
    }
}
