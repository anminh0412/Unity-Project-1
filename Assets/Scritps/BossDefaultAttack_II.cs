using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDefaultAttack_II : MonoBehaviour
{
    public float bossSkill1CD = 0f;
    public float bossSkill1TimeAnimation = 0.1f;
    public Transform skill1Point_II;
    public GameObject bossSkill1_II;
    public Animator bossAnimation;
    public float elapsed = 0.4f;
    public GameObject skill1_II;

    public bool isAttack = false;
    //public bool bossIsSkill = false;

    void Start()
    {
        skill1Point_II = GameObject.Find("Skill1Point_II").transform;
    }

    void Update()
    {
        bossSkill1CD -= Time.deltaTime;
        if (bossSkill1CD <= 3f && bossSkill1CD > 0f)
        {
            //bossIsSkill = false;
            bossAnimation.SetBool("isBossSkill1_II", false);
            skill1_II.SetActive(false);
            isAttack = false;
            GetComponent<BossController>().enabled = true;
        }
        else if (bossSkill1CD <= 0f)
        {
            //bossIsSkill = true;
            skill1_II.SetActive(true);
            bossAnimation.SetBool("isBossSkill1_II", true);
            if (bossSkill1CD <= -0.5f)
            {
                elapsed += Time.deltaTime;
                if (elapsed >= 0.4f)
                {
                    elapsed = elapsed % 0.21f;
                    BossSkill1();
                }
                isAttack = true;
                GetComponent<BossController>().enabled = false;
            }
            if (bossSkill1CD <= -0.8f)
            {
                bossSkill1CD = 3f;
            }
            
        }
    }
    void BossSkill1()
    {
        GameObject.Find("BossSoundManager").GetComponent<BossSoundManager>().PlaySound("bossDefautlAttack_2");
        SpawnFire();
    }
    void SpawnFire()
    {
        GameObject newFire = Instantiate(bossSkill1_II);
        newFire.transform.position = skill1Point_II.position;
        newFire.SetActive(true);
    }
}
