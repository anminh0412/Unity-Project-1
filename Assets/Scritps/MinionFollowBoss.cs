using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionFollowBoss : MonoBehaviour
{
    public Transform enemyTrans;
    protected GameObject enemy;
    protected float speed;
    protected float disLimit = 0f;
    void Start()
    {
        speed = GetComponent<MinionStatus>().speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Boss"))
        {
            this.enemy = GameObject.FindGameObjectWithTag("Boss");
            Debug.Log(enemy);
            this.enemyTrans = this.enemy.transform;
            this.Follow();
            GetComponent<FollowPlayer>().enabled = false;
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
