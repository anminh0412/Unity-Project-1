using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSkills : MonoBehaviour
{
    private bool checkExist;
    private bool beingsetSwordDownAnimation = false;
    private bool beingsetSwordRainAnimation = false;
    private bool beingsetSwordComboAnimation = false;
    private bool beingsetSwordUltiAnimation = false;
    private float skillDame;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        checkExist = GetComponent<SummonExcalibur>().exist;
        if (checkExist)
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                skillDame = 1000;
                this.Down();
            }
            if (Input.GetKeyDown(KeyCode.O))
            {
                skillDame = 600;
                this.Rain();
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                skillDame = 50;
                this.Combo();
            }
            if (Input.GetKeyDown(KeyCode.U))
            {
                skillDame = 10000;
                this.Ulti();
                
            }
        }
    }
    void Down()
    {
        Debug.Log("Chem chet con me may ne!!!");
        animator.SetBool("isSwordDown", true);
        if (!beingsetSwordDownAnimation)
        {
            StartCoroutine(setSwordDownAnimation());
        }
    }
    void Rain()
    {
        Debug.Log("Ngu ne!!!");
        animator.SetBool("isSwordRain", true);
        if (!beingsetSwordRainAnimation)
        {
            StartCoroutine(setSwordRainAnimation());
        }
    }
    void Combo()
    {
        Debug.Log("An DB an C ne!!!");
        animator.SetBool("isSwordCombo", true);
        if (!beingsetSwordComboAnimation)
        {
            StartCoroutine(setSwordComboAnimation());
        }
    }
    void Ulti()
    {
        Debug.Log("kiem to vailon brr brr!!!");
        animator.SetBool("isSwordUlti", true);
        if (!beingsetSwordUltiAnimation)
        {
            StartCoroutine(setSwordUltiAnimation());
        }
    }
    private IEnumerator setSwordDownAnimation()
    {
        beingsetSwordDownAnimation = true;
        GameObject.Find("Sword").GetComponent<ExcaliburSendDame>().currentDamage = skillDame;
        yield return new WaitForSeconds(1f);
        animator.SetBool("isSwordDown", false);
        GameObject.Find("Sword").GetComponent<ExcaliburSendDame>().currentDamage = GameObject.Find("Sword").GetComponent<ExcaliburSendDame>().Damage;
        beingsetSwordDownAnimation = false;
    }
    private IEnumerator setSwordRainAnimation()
    {
        beingsetSwordRainAnimation = true;
        GameObject.Find("Sword").GetComponent<ExcaliburSendDame>().currentDamage = skillDame;
        yield return new WaitForSeconds(1.5f);
        animator.SetBool("isSwordRain", false);
        GameObject.Find("Sword").GetComponent<ExcaliburSendDame>().currentDamage = GameObject.Find("Sword").GetComponent<ExcaliburSendDame>().Damage;
        beingsetSwordRainAnimation = false;
    }
    private IEnumerator setSwordComboAnimation()
    {
        beingsetSwordComboAnimation = true;
        GameObject.Find("Sword").GetComponent<ExcaliburSendDame>().currentDamage = skillDame;
        yield return new WaitForSeconds(1.1f);
        animator.SetBool("isSwordCombo", false);
        GameObject.Find("Sword").GetComponent<ExcaliburSendDame>().currentDamage = GameObject.Find("Sword").GetComponent<ExcaliburSendDame>().Damage;
        beingsetSwordComboAnimation = false;
    }
    private IEnumerator setSwordUltiAnimation()
    {
        beingsetSwordUltiAnimation = true;
        GameObject.Find("Sword").GetComponent<ExcaliburSendDame>().currentDamage = skillDame;
        yield return new WaitForSeconds(1.1f);
        animator.SetBool("isSwordUlti", false);
        GameObject.Find("Sword").GetComponent<ExcaliburSendDame>().currentDamage = GameObject.Find("Sword").GetComponent<ExcaliburSendDame>().Damage;
        beingsetSwordUltiAnimation = false;
    }
}
