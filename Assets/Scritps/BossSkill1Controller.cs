using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkill1Controller : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    private void Start()
    {
        GameObject.Find("BossSoundManager").GetComponent<BossSoundManager>().PlaySound("bossDefautlAttack_1");
        if (GameObject.Find("boss").GetComponent<BossController>().isFacingRight)
        {
            rb.velocity = Vector2.right * speed;
        }
        else if (!GameObject.Find("boss").GetComponent<BossController>().isFacingRight)
        {
            rb.velocity = Vector2.left * speed;
        }
    }
    private void Update()
    {
        Invoke("Destroy", 2f);
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            GameObject.Find("boss").GetComponent<BossAttackController>().checkOnTarget += 1;
        }
    }
}
