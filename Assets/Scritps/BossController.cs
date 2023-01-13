using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public Transform player;
    public Transform homePos;
    public float distance;
    public float distToPlayerY;
    public float attackDistance;
    public float unTargetDistance;
    public float speed;
    public bool isHome = true;
    public bool playerIsComing = true;

    public GameObject skill1_II;

    public Animator bossAnimation;
    public Rigidbody2D rb;
    [HideInInspector] public bool isFacingRight;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //skill1_II.SetActive(false);
    }
    void FixedUpdate()
    {
        player = GameObject.Find("player").transform;
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        float distToHome = Vector2.Distance(transform.position, homePos.position);
        //distToPlayerY = player.position.y - gameObject.transform.position.y;
        //GetComponent<BossDefaultAttack_II>().enabled = false;
        if (distToPlayer <= distance && distToPlayer > attackDistance)
        {
            playerIsComing = true;
            ChasePlayer();
            GetComponent<BossAttackController>().enabled = false;
            GetComponent<BossDefaultAttack_II>().enabled = false;
            GetComponent<BossDefaultAttack>().enabled = false;
            skill1_II.SetActive(false);
        }
        else if (distToPlayer <= attackDistance )
        {
            playerIsComing = true;
            StopChasingPlayer();
            GetComponent<BossAttackController>().enabled = true;
            GetComponent<BossDefaultAttack_II>().enabled = true;
            GetComponent<BossDefaultAttack>().enabled = true;
        }
        else if (distToPlayer > attackDistance && distToPlayer <= unTargetDistance)
        {
            skill1_II.SetActive(false);
            bossAnimation.SetBool("isRunning", false);
            GetComponent<BossAttackController>().enabled = false;
            GetComponent<BossDefaultAttack_II>().enabled = false;
            GetComponent<BossDefaultAttack>().enabled = false;
        }
        else if(distToPlayer > unTargetDistance)
        {
            playerIsComing = false;
            GetComponent<BossDefaultAttack_II>().enabled = false;
            GetComponent<BossDefaultAttack>().enabled = false;
        }
      
        if (distToHome <= 0.5f)
        {
            isHome = true;
        } else if (distToHome > 0.5f)
        {
            isHome = false;
        }

        if (isHome == false && playerIsComing == false)
        {
            CombackLocal();
        }
        else if (isHome == true && playerIsComing == false)
        {
            StopCombackLocal();
            GetComponent<BossHealthController>().currentHealth = GetComponent<BossHealthController>().maxHealth;
        }
    }
    void ChasePlayer()
    {
        if (transform.position.x < player.position.x)
        {
            Debug.Log("dang duoi ne");
            rb.velocity = new Vector2(speed, 0);
            transform.eulerAngles = new Vector3(0, 180, 0);
            bossAnimation.SetBool("isRunning", true);
            bossAnimation.SetBool("isBossSkill1", false);
            bossAnimation.SetBool("isBossSkill1_II", false);
        }
        else if (transform.position.x > player.position.x)
        {
            Debug.Log("dang duoi ne");
            rb.velocity = new Vector2(-speed, 0);
            transform.eulerAngles = new Vector3(0, 0, 0);
            bossAnimation.SetBool("isRunning", true);
            bossAnimation.SetBool("isBossSkill1", false);
            bossAnimation.SetBool("isBossSkill1_II", false);
        }
    }
    void StopChasingPlayer()
    {
        rb.velocity = new Vector2(0, 0);
        bossAnimation.SetBool("isRunning", false);
        if (transform.position.x < player.position.x)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            isFacingRight = true;
        }
        else if (transform.position.x > player.position.x)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            isFacingRight = false;
        }
    }
    void CombackLocal()
    {
        if (transform.position.x < homePos.position.x)
        {
            Debug.Log("dang ve ne");
            rb.velocity = new Vector2(speed, 0);
            transform.eulerAngles = new Vector3(0, 180, 0);
            bossAnimation.SetBool("isRunning", true);
        }
        else if (transform.position.x > homePos.position.x)
        {
            Debug.Log("dang ve ne");
            rb.velocity = new Vector2(-speed, 0);
            transform.eulerAngles = new Vector3(0, 0, 0);
            bossAnimation.SetBool("isRunning", true);
        }
    }
    void StopCombackLocal()
    {
        rb.velocity = new Vector2(0, 0);
        bossAnimation.SetBool("isRunning", false);
    }
}
