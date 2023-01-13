using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{

    public Transform player;
    public float distance;
    public float speedEnemy;

    public Animator enemyAnimation;
    public Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("player").transform;
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        if (distToPlayer < distance)
        {
            ChasePlayer();
        }
        else
        {
            StopChasingPlayer();
        }
    }
    void ChasePlayer()
    {
        if (transform.position.x < player.position.x)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x, player.position.y, player.position.z), speedEnemy * Time.deltaTime);
            //rb.velocity = new Vector2(speedEnemy, 0);
            transform.eulerAngles = new Vector3(0, 180, 0);
            enemyAnimation.SetBool("isJumping", true);
        }
        else if (transform.position.x > player.position.x)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x, player.position.y, player.position.z), speedEnemy * Time.deltaTime);
            //rb.velocity = new Vector2(-speedEnemy, 0);
            transform.eulerAngles = new Vector3(0, 0, 0);
            enemyAnimation.SetBool("isJumping", true);
        }
    }
    void StopChasingPlayer()
    {
        rb.velocity = new Vector2(0, 0);
        enemyAnimation.SetBool("isJumping", false);
    }
}
