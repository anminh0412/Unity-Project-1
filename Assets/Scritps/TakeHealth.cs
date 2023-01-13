using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeHealth : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "player")
        {
            GameObject.Find("player").GetComponent<DamageReceiver>().currentHealth += 500f;
            GameObject.Find("SpawnHealth").GetComponent<SpawnHealth>().elapsed = 0f;
            Destroy(gameObject);
        }
    }
}
