using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSkills : MonoBehaviour
{
    private bool checkExist;
    private bool beingsetSKill1 = false;
    private bool beingsetSKill2 = false;
    private bool beingsetSKill3 = false;
    private bool beingsetSKill4 = false;
    public bool onSkills = false;

    private float skill1Dame;
    private float skill2Dame;
    private float skill3Dame;
    private float skill4Dame;

    private float skill1Animation;
    private float skill2Animation;
    private float skill3Animation;
    private float skill4Animation;

    private float playerDamage;
    private float weaponDamage;
    private float currentMana;

    [SerializeField] private float currentDameSkill1;
    [SerializeField] private float currentDameSkill2;
    [SerializeField] private float currentDameSkill3;
    [SerializeField] private float currentDameSkill4;

    [SerializeField] public float manaConsumptionSkill1;
    [SerializeField] public float manaConsumptionSkill2;
    [SerializeField] public float manaConsumptionSkill3;
    [SerializeField] public float manaConsumptionSkill4;

    public Animator animator;
    protected bool onShield;
    private void Start()
    {
        playerDamage = GetComponent<PlayerStatus>().damage;

        skill1Dame = GameObject.Find("Weapon").GetComponent<WeaponStatus>().skill1Damage;
        skill2Dame = GameObject.Find("Weapon").GetComponent<WeaponStatus>().skill2Damage;
        skill3Dame = GameObject.Find("Weapon").GetComponent<WeaponStatus>().skill3Damage;
        skill4Dame = GameObject.Find("Weapon").GetComponent<WeaponStatus>().skill4Damage;

        skill1Animation = GameObject.Find("Weapon").GetComponent<WeaponStatus>().skill1Animation;
        skill2Animation = GameObject.Find("Weapon").GetComponent<WeaponStatus>().skill2Animation;
        skill3Animation = GameObject.Find("Weapon").GetComponent<WeaponStatus>().skill3Animation;
        skill4Animation = GameObject.Find("Weapon").GetComponent<WeaponStatus>().skill4Animation;

        manaConsumptionSkill1 = GameObject.Find("Weapon").GetComponent<WeaponStatus>().manaConsumptionSkill1;
        manaConsumptionSkill2 = GameObject.Find("Weapon").GetComponent<WeaponStatus>().manaConsumptionSkill2;
        manaConsumptionSkill3 = GameObject.Find("Weapon").GetComponent<WeaponStatus>().manaConsumptionSkill3;
        manaConsumptionSkill4 = GameObject.Find("Weapon").GetComponent<WeaponStatus>().manaConsumptionSkill4;
    }
    void Update()
    {
        onShield = GetComponent<PlayerShieldController>().onShield;
        currentMana = GetComponent<ManaUsed>().currentMana;
        animator = GameObject.Find("Weapon").GetComponent<Animator>();
        weaponDamage = GameObject.Find("Weapon").GetComponent<WeaponCollide>().Damage;
        currentDameSkill1 = skill1Dame + playerDamage + weaponDamage;
        currentDameSkill2 = skill2Dame + playerDamage + weaponDamage;
        currentDameSkill3 = skill3Dame + playerDamage + weaponDamage;
        currentDameSkill4 = skill4Dame + playerDamage + weaponDamage;
        checkExist = GetComponent<SummonWeapon>().exist;
        if (checkExist && !onShield)
        {
            if (Input.GetKeyDown(KeyCode.I) && !onSkills && manaConsumptionSkill1 <= currentMana)
            {
                GameObject.Find("player").GetComponent<ManaUsed>().UseMana(manaConsumptionSkill1);
                this.Skill1();
                GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySound("skillI");
                //imageSkill1.color = new Color(imageSkill1.color.r, imageSkill1.color.g, imageSkill1.color.b, 0.4f);
                //Invoke("ResetAlphaSkill1", 0.2f);
            }
            else if (Input.GetKeyDown(KeyCode.I) && !onSkills && manaConsumptionSkill1 > currentMana) 
            { 
                GameObject.Find("player").GetComponent<ManaUsed>().ManaLessNotificationOn();
            }
            if (Input.GetKeyDown(KeyCode.O) && !onSkills && manaConsumptionSkill2 <= currentMana)
            {
                GameObject.Find("player").GetComponent<ManaUsed>().UseMana(manaConsumptionSkill2);
                this.Skill2();
                GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySound("skillO");
                //imageSkill2.color = new Color(imageSkill2.color.r, imageSkill2.color.g, imageSkill2.color.b, 0.4f);
                //Invoke("ResetAlphaSkill2", 0.2f);
            }
            else if (Input.GetKeyDown(KeyCode.O) && !onSkills && manaConsumptionSkill2 > currentMana)
            {
                GameObject.Find("player").GetComponent<ManaUsed>().ManaLessNotificationOn();
            }
            if (Input.GetKeyDown(KeyCode.P) && !onSkills && manaConsumptionSkill3 <= currentMana)
            {
                GameObject.Find("player").GetComponent<ManaUsed>().UseMana(manaConsumptionSkill3);
                this.Skill3();
                GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySound("skillP");
                //imageSkill3.color = new Color(imageSkill3.color.r, imageSkill3.color.g, imageSkill3.color.b, 0.4f);
                //Invoke("ResetAlphaSkill3", 0.2f);
            }
            else if (Input.GetKeyDown(KeyCode.P) && !onSkills && manaConsumptionSkill3 > currentMana)
            {
                GameObject.Find("player").GetComponent<ManaUsed>().ManaLessNotificationOn();
            }
            if (Input.GetKeyDown(KeyCode.U) && !onSkills && manaConsumptionSkill4 <= currentMana)
            {
                GameObject.Find("player").GetComponent<ManaUsed>().UseMana(manaConsumptionSkill4);
                this.Skill4();
                GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySound("skillU");
                //imageSkill4.color = new Color(imageSkill4.color.r, imageSkill4.color.g, imageSkill4.color.b, 0.4f);
                //Invoke("ResetAlphaSkill4", 0.2f);
            }
            else if (Input.GetKeyDown(KeyCode.U) && !onSkills && manaConsumptionSkill4 > currentMana)
            {
                GameObject.Find("player").GetComponent<ManaUsed>().ManaLessNotificationOn();
            }
        }
    }
    void Skill1()
    {
        Debug.Log("Chem chet con me may ne!!!");
        animator.SetBool("isSkill1", true);
        if (!beingsetSKill1)
        {
            StartCoroutine(setSkill1());
        }
    }
    void Skill2()
    {
        Debug.Log("Ngu ne!!!");
        animator.SetBool("isSkill2", true);
        if (!beingsetSKill2)
        {
            StartCoroutine(setSkill2());
        }
    }
    void Skill3()
    {
        Debug.Log("An DB an C ne!!!");
        animator.SetBool("isSkill3", true);
        if (!beingsetSKill3)
        {
            StartCoroutine(setSkill3());
        }
    }
    void Skill4()
    {
        Debug.Log("kiem to vailon brr brr!!!");
        animator.SetBool("isSkill4", true);
        if (!beingsetSKill4)
        {
            StartCoroutine(setSkill4());
        }
    }
    private IEnumerator setSkill1()
    {
        beingsetSKill1 = true;
        onSkills = true;
        GameObject.Find("Weapon").GetComponent<WeaponCollide>().currentDamage = currentDameSkill1;
        yield return new WaitForSeconds(skill1Animation);
        animator.SetBool("isSkill1", false);
        GameObject.Find("Weapon").GetComponent<WeaponCollide>().currentDamage = GameObject.Find("Weapon").GetComponent<WeaponCollide>().Damage;
        onSkills = false;
        beingsetSKill1 = false;
    }
    private IEnumerator setSkill2()
    {
        beingsetSKill2 = true;
        onSkills = true;
        GameObject.Find("Weapon").GetComponent<WeaponCollide>().currentDamage = currentDameSkill2;
        yield return new WaitForSeconds(skill2Animation);
        animator.SetBool("isSkill2", false);
        GameObject.Find("Weapon").GetComponent<WeaponCollide>().currentDamage = GameObject.Find("Weapon").GetComponent<WeaponCollide>().Damage;
        onSkills = false;
        beingsetSKill2 = false;
    }
    private IEnumerator setSkill3()
    {
        beingsetSKill3 = true;
        onSkills = true;
        GameObject.Find("Weapon").GetComponent<WeaponCollide>().currentDamage = currentDameSkill3;
        yield return new WaitForSeconds(skill3Animation);
        animator.SetBool("isSkill3", false);
        GameObject.Find("Weapon").GetComponent<WeaponCollide>().currentDamage = GameObject.Find("Weapon").GetComponent<WeaponCollide>().Damage;
        onSkills = false;
        beingsetSKill3 = false;
    }
    private IEnumerator setSkill4()
    {
        beingsetSKill4 = true;
        onSkills = true;
        GameObject.Find("Weapon").GetComponent<WeaponCollide>().currentDamage = currentDameSkill4;
        yield return new WaitForSeconds(skill4Animation);
        animator.SetBool("isSkill4", false);
        GameObject.Find("Weapon").GetComponent<WeaponCollide>().currentDamage = GameObject.Find("Weapon").GetComponent<WeaponCollide>().Damage;
        onSkills = false;
        beingsetSKill4 = false;
    }

}
