using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepTileMapController : MonoBehaviour
{
    public Collider2D tileMap;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player" || collision.gameObject.name == "boss")
        {
            tileMap.isTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player" || collision.gameObject.name == "boss")
        {
            tileMap.isTrigger = false;
        }
    }
}
