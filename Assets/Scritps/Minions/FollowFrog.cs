using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowFrog : MonoBehaviour
{
    public Transform frog;
    protected GameObject frogPos;
    protected float speed = 3f;
    protected float disLimit = 0.2f;

    private void Awake()
    {
        
    }
    void Update()
    {
        try
        {
            if (!GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyHealthController>().isDead)
            {
                this.frogPos = GameObject.FindGameObjectWithTag("Enemy");
                this.frog = this.frogPos.transform;
                this.Follow();
                GetComponent<FollowPlayer>().enabled = false;
            }
        }  
        catch 
        {
            GetComponent<FollowPlayer>().enabled = true;
        }
    }
    void Follow()
    {
        Vector3 distance = this.frog.position - transform.position;
        if (distance.magnitude >= this.disLimit)
        {
            Vector3 targetPoint = this.frog.position - distance.normalized * this.disLimit;
            gameObject.transform.position =
                Vector3.MoveTowards(gameObject.transform.position, targetPoint, this.speed * Time.deltaTime);
            if (transform.position.x > frog.position.x)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else if (transform.position.x < frog.position.x)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
        }
    }
}
