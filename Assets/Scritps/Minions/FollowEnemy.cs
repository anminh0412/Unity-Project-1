using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemy : MonoBehaviour
{
    public Transform enemyTrans;
    protected GameObject enemy;
    protected float speed;
    protected float disLimit = 0.2f;
    private void Start()
    {
        speed = GetComponent<MinionStatus>().speed;
    }
    void Update()
    {
        try
        {
            if (!GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyHealthController>().isDead)
            {
                this.enemy = GameObject.FindGameObjectWithTag("Enemy");
                Debug.Log(enemy);
                this.enemyTrans = this.enemy.transform;
                this.Follow();
                GetComponent<MinionFollowBoss>().enabled = false;
                GetComponent<FollowPlayer>().enabled = false;
            }
        }
        catch
        {
            GetComponent<MinionFollowBoss>().enabled = true;
            GetComponent<FollowPlayer>().enabled = false;
            if (!GameObject.Find("boss"))
            {
                GetComponent<FollowPlayer>().enabled = true;
            }
        }
    }
    void Follow()
    {
        Vector3 distance = this.enemyTrans.position - transform.position;
        if (distance.magnitude >= this.disLimit)
        {
            Vector3 targetPoint = this.enemyTrans.position - distance.normalized * this.disLimit;
            gameObject.transform.position =
                Vector3.MoveTowards(gameObject.transform.position, targetPoint, this.speed * Time.deltaTime);
            if (transform.position.x > enemyTrans.position.x)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else if (transform.position.x < enemyTrans.position.x)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
        }
    }
}
