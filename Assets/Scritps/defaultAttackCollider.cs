using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defaultAttackCollider : MonoBehaviour
{
    public float Damage;
    public float currentDamage;
    public Collider2D posCollider;
    public Collider2D enemyCollider;
    private void Start()
    {
        currentDamage = Damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "eagle" || collision.gameObject.name == "Fire_Napalm(Clone)" || collision.gameObject.tag == "InvisibleBlock")
        {

        }
        else if (collision.gameObject.name == "boss")
        {
            GameObject.Find("boss").GetComponent<BossHealthController>().BossTakeDame(currentDamage);
            Destroy();
        }
        else Destroy();
        EnemyHealthController damageReceiver = collision.GetComponent<EnemyHealthController>();
        damageReceiver.TakeDame(currentDamage);
        Destroy();
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }
}
