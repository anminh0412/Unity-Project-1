using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkill3FallTrajectory_2 : MonoBehaviour
{
    public float posX;
    protected float posY;
    public float posX1;
    public int posX1Int;
    protected float posY1 = -99f;
    protected float posY2 = 0.455f;
    protected float posY3 = -0.25f;
    public float speed;
    protected float setAxitTime = 12f;

    public bool checkCollider = false;
    public bool checkPlayerCollider = false;
    private bool isGrounded;
    public bool playerOnFire = false;

    public Animator fireBallAnimation;
    
    public LayerMask whatIsGround;
    public float checkRadius = 0.1f;
    public float Damage1;
    public float Damage2;
    public float Damage3;

    float elapsed = 0f;

    private void Start()
    {
        posX1Int = Random.Range(-100, 100);
        posX1 = (float)posX1Int;
        posX = gameObject.transform.position.x + posX1;
        posY = gameObject.transform.position.y + posY1;
        fireBallAnimation = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        setAxitTime -= Time.deltaTime;
        isGrounded = Physics2D.OverlapCircle(gameObject.transform.position, checkRadius, whatIsGround);
        if (!checkCollider)
        {
            Fall();
        }
        if (checkPlayerCollider == false && setAxitTime <= 0)
        {
            Destroy(gameObject);
        }
        if (playerOnFire)
        {
            elapsed += Time.deltaTime;
            if (elapsed >= 1f)
            {
                elapsed = elapsed % 1f;
                TakeDame3();
            }
        }
    }
    public void Fall()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(posX, posY, 0f), speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Fire_Napalm(Clone)")
        {

        }
        else if (isGrounded)
        {
            checkCollider = true;
        }
        if (collision.gameObject.name == "player" && !checkPlayerCollider && checkCollider)
        {
            GameObject.Find("BossSoundManager").GetComponent<BossSoundManager>().PlaySound("bossSkill3_C_2");
            Invoke("OnSound", 0.1f);
            checkPlayerCollider = true;
            transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + posY2, 0f);
            GameObject.Find("player").GetComponent<DamageReceiver>().ReceiveDamege(Damage2 + Damage1);
            fireBallAnimation.SetBool("isCollider", true);
            //Invoke("TakeDame2", 0.15f);
            Invoke("Animation3", 0.5f);   
        }
        if (collision.gameObject.name == "player" && checkPlayerCollider && checkCollider)
        {
            playerOnFire = true;
            elapsed = 1f;
        }
        if (collision.gameObject.tag == "Weapon" && !checkPlayerCollider && checkCollider)
        {
            GameObject.Find("BossSoundManager").GetComponent<BossSoundManager>().PlaySound("bossSkill3_C_2");
            Invoke("OnSound", 0.1f);
            checkPlayerCollider = true;
            transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + posY2, 0f);
            fireBallAnimation.SetBool("isCollider", true);
            //Invoke("TakeDame2", 0.15f);
            Invoke("Animation3", 0.5f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player" && checkPlayerCollider && checkCollider)
        {
            playerOnFire = false;
        }
    }
    private void Animation3()
    {
        transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + posY3, 0f);
        fireBallAnimation.SetBool("isBum", true);
        Invoke("Destroy", 10f);
    }
    private void TakeDame2()
    {
        GameObject.Find("player").GetComponent<DamageReceiver>().ReceiveDamege(Damage2);
    }
    private void TakeDame3()
    {
        GameObject.Find("player").GetComponent<DamageReceiver>().ReceiveDamege(Damage3);
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }
    void OnSound()
    {
        GameObject.Find("BossSoundManager").GetComponent<BossSoundManager>().PlaySound("bossSkill3_C_3");
    }
}
