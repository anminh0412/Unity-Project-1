using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkill1_IIController : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float axistTime;
    public Animator bossSkill1_II;
    private bool isCollider = false;
    void Start()
    {
        bossSkill1_II = gameObject.GetComponent<Animator>();
        Invoke("Destroy", axistTime);
    }
    void Update()
    {
        player = GameObject.Find("player");
    }
    void FixedUpdate()
    {
        if(!isCollider) FollowPlayer();
    }
    public void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player" || collision.gameObject.name == "defaultAttackPrefab(Clone)" || collision.gameObject.tag == "Weapon")
        {
            isCollider = true;
            bossSkill1_II.SetBool("isCollider", true);
            Invoke("onSound", 0.1f);
            Invoke("Destroy", 1f);
        }
        if (collision.gameObject.name == "shield")
        {
            GameObject.Find("BossSoundManager").GetComponent<BossSoundManager>().PlaySound("bossDefautlAttack_2_Col1");
            isCollider = true;
            bossSkill1_II.SetBool("isCollider", true);
            Invoke("Destroy", 0.3f);
        }
    }
    void onSound()
    {
        //GameObject.Find("BossSoundManager").GetComponent<BossSoundManager>().audioSrc.Stop();
        GameObject.Find("BossSoundManager").GetComponent<BossSoundManager>().PlaySound("bossDefautlAttack_2_Col2");
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
}
