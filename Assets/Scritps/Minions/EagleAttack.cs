using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleAttack : MonoBehaviour
{
    private float Damage;
    private bool checkCollider = false;
    float elapsed = 0f;

    private void Start()
    {
        Damage = GetComponent<MinionStatus>().Damage;
    }
    private void Update()
    {
        if (checkCollider)
        {
            GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyHealthController>().TakeDame(Damage);          
        }
        if (GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyHealthController>().isDead)
        {
            checkCollider = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        checkCollider = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "boss")
        {
            elapsed += Time.deltaTime;
            if (elapsed >= 1f)
            {
                elapsed = elapsed % 1f;
                SendDame();
            }
        }
    }
    void SendDame()
    {
        GameObject.Find("boss").GetComponent<BossHealthController>().BossTakeDame(Damage*20f);
    }
}
