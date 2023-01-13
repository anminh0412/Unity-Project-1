using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExcaliburSendDame : MonoBehaviour
{
    public float Damage;
    public float currentDamage;
    private void Start()
    {
        currentDamage = Damage;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHealthController damageReceiver = collision.GetComponent<EnemyHealthController>();
        damageReceiver.TakeDame(currentDamage);
    }
}
