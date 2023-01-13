using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackController : MonoBehaviour
{
    public GameObject bossSkill2SummonBossFrog;
    public GameObject bossSkill2SummonFrog;
    public GameObject bossSkill3;
    public Animator bossAnimation;

    public bool bossIsSkill = false;

    public GameObject player;
    private float bossCurrentHealth;
    public float bossMaxHealth;
    public float bossPercentHealth;
    float temp1 = 1;
    float temp2 = 2;
    float temp3 = 2;
    List<GameObject> frogs1;
    List<GameObject> frogs;
    List<GameObject> frogs2;
    private bool isRespond = false;
    private bool isSkill2 = false;
    private bool isSkill2LowHp = false;
    protected Transform bossFrogPos;
    protected Transform frogPos;
    public Transform homePos;

    float elapsed = -0.3f;
    float elapsed2 = -0.2f;
    bool isSummon1 = false;
    bool isSummon2 = false;
    bool checkFreeTime = true;

    public int checkOnTarget;

    private void Start()
    {
        this.frogs1 = new List<GameObject>();
        this.frogs = new List<GameObject>();
        this.frogs2 = new List<GameObject>();
    }
    private void Update()
    {
        if (GetComponent<BossDefaultAttack>().isAttack == true || GetComponent<BossDefaultAttack_II>().isAttack == true)
        {
            checkFreeTime = false;
        }
        else checkFreeTime = true;
        if (checkOnTarget >= 5)
        {
            Invoke("SetSkill3Animation", 0.5f);
            Invoke("SetSkill3Active", 1.2f);
        }
        this.bossCurrentHealth = GetComponent<BossHealthController>().currentHealth;
        this.bossMaxHealth = GetComponent<BossHealthController>().maxHealth;
        this.bossPercentHealth = this.bossCurrentHealth / this.bossMaxHealth;
        player = GameObject.Find("player");
        //startSkill2
        if (this.bossPercentHealth <= 0.67f && isSkill2 == false && checkFreeTime == true)
        {
            bossAnimation.SetBool("isBossSkill2", true);
            isSummon1 = true;
        }
        else
        {
            bossAnimation.SetBool("isBossSkill2", false);
        }
        if (this.bossPercentHealth <= 0.34f && isSkill2LowHp == false && isRespond == false  && checkFreeTime == true)
        {
            bossAnimation.SetBool("isBossSkill2", true);
            isSummon2 = true;
            Invoke("BossHided", 0.8f);
            Invoke("BossTele", 1.6f);
        }
        else
        {
            bossAnimation.SetBool("isBossSkill2", false);
        }
        if (player.GetComponent<PointManager>().playerPoint > 22 && isRespond == false)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            isRespond = true;
            bossAnimation.SetBool("isBossComback", true);
            BossTeleToPlayer();
        }
        elapsed += Time.deltaTime;
        if (elapsed >= 0.5f && isSummon1 && frogs.Count < 10)
        {
            elapsed = elapsed % 0.5f;
            BossSkill2();
        }
        elapsed2 += Time.deltaTime;
        if (elapsed2 >= 0.5f && isSummon2 && frogs2.Count < 15)
        {
            elapsed2 = elapsed2 % 0.5f;
            BossSkill2LowHp();
        }

    }
    void BossSkill2FirstTime()
    {
        if (frogs1.Count < 10)
        {
            if (!GameObject.Find("bossFrog"))
            {
                GameObject bossFrog = Instantiate(this.bossSkill2SummonBossFrog);
                bossFrog.name = "bossFrog";
                bossFrog.transform.position = new Vector3(player.transform.position.x + 3.5f, -0.34f, 0f);
                this.frogs1.Add(bossFrog);
            }
            GameObject frog = Instantiate(this.bossSkill2SummonFrog);
            frog.name = "frog";
            frog.transform.position = new Vector3(player.transform.position.x + temp1, -0.8f, 0f);
            this.frogs1.Add(frog);
            temp1 += 0.5f;
        }
        isSkill2 = true;
    }
    void BossSkill2()
    {
        GetComponent<BossDefaultAttack>().enabled = true;
        GetComponent<BossDefaultAttack_II>().enabled = true;
        GetComponent<BossController>().enabled = true;
        if (frogs.Count % 2 == 0)
        {
            if (!GameObject.Find("bossFrog"))
            {
                GameObject bossFrog = Instantiate(this.bossSkill2SummonBossFrog);
                bossFrog.name = "bossFrog";
                bossFrog.transform.position = new Vector3(player.transform.position.x + temp2, -6.35f, 0f);
                this.frogs.Add(bossFrog);
            }
            GameObject frog = Instantiate(this.bossSkill2SummonFrog);
            frog.name = "frog";
            frog.transform.position = new Vector3(player.transform.position.x + temp2, -6.8f, 0f);
            this.frogs.Add(frog);
            temp2 += 0.2f;
        }
        else
        {
            if (!GameObject.Find("bossFrog"))
            {
                GameObject bossFrog = Instantiate(this.bossSkill2SummonBossFrog);
                bossFrog.name = "bossFrog";
                bossFrog.transform.position = new Vector3(player.transform.position.x - temp2, -6.35f, 0f);
                this.frogs.Add(bossFrog);
            }
            GameObject frog = Instantiate(this.bossSkill2SummonFrog);
            frog.name = "frog";
            frog.transform.position = new Vector3(player.transform.position.x - temp2, -6.8f, 0f);
            this.frogs.Add(frog);
            temp2 += 0.2f;
        }
        isSkill2 = true;
    }
    void BossSkill2LowHp()
    {
        if (frogs.Count % 2 == 0)
        {
            if (frogs2.Count % 5 == 0)
            {
                GameObject bossFrog = Instantiate(this.bossSkill2SummonBossFrog);
                bossFrog.name = "bossFrog";
                bossFrog.transform.position = new Vector3(player.transform.position.x + temp3, -6.35f, 0f);
                this.frogs2.Add(bossFrog);
            }
            GameObject frog = Instantiate(this.bossSkill2SummonFrog);
            frog.name = "frog";
            Vector3 temp = new Vector3(temp3, 0.7f, 0f);
            frog.transform.position = new Vector3(player.transform.position.x + temp3, -6.8f, 0f);
            this.frogs2.Add(frog);
            temp3 += 0.2f;
        }
        else
        {
            if (frogs2.Count % 5 == 0)
            {
                GameObject bossFrog = Instantiate(this.bossSkill2SummonBossFrog);
                bossFrog.name = "bossFrog";
                bossFrog.transform.position = new Vector3(player.transform.position.x + temp3, -6.35f, 0f);
                this.frogs2.Add(bossFrog);
            }
            GameObject frog = Instantiate(this.bossSkill2SummonFrog);
            frog.name = "frog";
            Vector3 temp = new Vector3(temp3, 0.7f, 0f);
            frog.transform.position = new Vector3(player.transform.position.x + temp3, -6.8f, 0f);
            this.frogs2.Add(frog);
            temp3 += 0.2f;
        }
        isSkill2LowHp = true;
    }
    void BossHided()
    {
        bossAnimation.SetBool("isBossSkill2", false);
        bossAnimation.SetBool("isBossHided", true);
    }
    void BossComback()
    {
        bossAnimation.SetBool("isBossComback", false);
    }
    void BossTele()
    {
        transform.position = new Vector3(5f, 30f, 0f);
        bossAnimation.SetBool("isBossHided", false);
        GetComponent<BossHealthController>().currentHealth = bossMaxHealth * 0.75f;
    }
    void BossTeleToPlayer()
    {
        Vector3 temp1 = new Vector3(0f, 1f, 0f);
        transform.position = homePos.position + temp1;
        Invoke("BossComback", 0.8f);
    }
    void SetSkill3Animation()
    {
        bossAnimation.SetBool("isBossSkill3", true);
    }
    void SetSkill3Active()
    {
        bossAnimation.SetBool("isBossSkill3", false);
        bossSkill3.SetActive(true);
        bossSkill3.GetComponent<BossSkill3SetPosition>().activeTime = 15f;
        checkOnTarget = 0;
    }
}
