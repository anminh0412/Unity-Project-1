using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkill3FallTrajectory : MonoBehaviour
{
    public float Damage = 100f;
    protected float posX;
    protected float posY;
    public float posX1;
    public float posY1;
    public float posY2;
    public float speed;
    public bool checkCollider = false;
    public Animator fireBallAnimation;
    private void Start()
    {
        posX = gameObject.transform.position.x + posX1;
        posY = gameObject.transform.position.y + posY1;
        fireBallAnimation = gameObject.GetComponent<Animator>();
        GameObject.Find("BossSoundManager").GetComponent<BossSoundManager>().PlaySound("bossSkill3_A_1");
    }
    void Update()
    {
        if (!checkCollider)
        {
            Fall();
        } 
    }
    public void Fall()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(posX, posY, 0f), speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "BossSkill1(Clone)" || collision.gameObject.name == "Fire_Napalm(Clone)" || collision.gameObject.name == "Skill1_II(Clone)" || collision.gameObject.tag == "InvisibleBlock" || collision.gameObject.tag == "Enemy")
        {

        }
        else if (!checkCollider)
        {
            checkCollider = true;
            transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + posY2, 0f);
            fireBallAnimation.SetBool("isCollider", true);
            GameObject.Find("BossSoundManager").GetComponent<BossSoundManager>().PlaySound("bossSkill3_A_2");
            Invoke("Destroy", 0.5f);
        }
        if (collision.gameObject.name == "player")
        {
            GameObject.Find("player").GetComponent<DamageReceiver>().ReceiveDamege(Damage);
        }
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }
}
