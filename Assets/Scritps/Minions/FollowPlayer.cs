using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    private float speed;
    private float disLimit = 0.5f;

    // Update is called once per frame
    private void Start()
    {
        speed = GetComponent<MinionStatus>().speed;
    }
    void Update()
    {
        this.Follow();
    }
    void Follow()
    {
        Vector3 distance = this.player.position - transform.position;
        if (distance.magnitude >= this.disLimit)
        {
            Vector3 targetPoint = this.player.position - distance.normalized * this.disLimit;
            gameObject.transform.position =
                Vector3.MoveTowards(gameObject.transform.position, targetPoint, this.speed * Time.deltaTime);
            if(transform.position.x > player.position.x)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }else if (transform.position.x < player.position.x)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
        }
        
    }
}
