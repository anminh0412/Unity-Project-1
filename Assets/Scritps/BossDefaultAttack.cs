using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDefaultAttack : MonoBehaviour
{
    public float bossSkill1CD = 0f;
    public float bossSkill1TimeAnimation = 0.1f;
    public Transform skill1Point;
    public GameObject bossSkill1;
    BossController bossController;
    public Animator bossAnimation;
    public bool isAttack = false;
    //public bool bossIsSkill = false;

    void Start()
    {
        bossController = gameObject.GetComponent<BossController>();
    }

    // Update is called once per frame
    void Update()
    {
        bossSkill1CD -= Time.deltaTime;
        if (bossSkill1CD <= 3f && bossSkill1CD > 0f)
        {
            //bossIsSkill = false;
            isAttack = false;
            bossAnimation.SetBool("isBossSkill1", false);
            GetComponent<BossController>().enabled = true;
        }
        else if (bossSkill1CD <= 0f)
        {
            //bossIsSkill = true;
            bossAnimation.SetBool("isBossSkill1", true);
            if (bossSkill1CD <= -0.5f)
            {
                BossSkill1();
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
        if (!GameObject.FindGameObjectWithTag("BossBullet"))
        {
            float angle = bossController.isFacingRight ? 0f : 180f;
            Instantiate(bossSkill1, skill1Point.position, Quaternion.Euler(new Vector3(0f, angle, 0f)));
        }
    }
}
