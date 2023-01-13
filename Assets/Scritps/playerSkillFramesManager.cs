using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerSkillFramesManager : MonoBehaviour
{
    public Image imageSkill1;
    public Image imageSkill2;
    public Image imageSkill3;
    public Image imageSkill4;
    public Image imageSkillJ;
    public Image onOffImage;
    public bool onSkills = false;
    public bool onShield;

    private float skill1Animation;
    private float skill2Animation;
    private float skill3Animation;
    private float skill4Animation;

    public Text manaConsumptionSkillJText;
    public Text manaConsumptionSkillRText;
    public Text manaConsumptionSkillEText;
    public Text manaConsumptionSkill1Text;
    public Text manaConsumptionSkill2Text;
    public Text manaConsumptionSkill3Text;
    public Text manaConsumptionSkill4Text;

    [SerializeField] public float manaConsumptionSkillJ;
    [SerializeField] public float manaConsumptionSkillR;
    [SerializeField] public float manaConsumptionSkillE;
    [SerializeField] public float manaConsumptionSkill1;
    [SerializeField] public float manaConsumptionSkill2;
    [SerializeField] public float manaConsumptionSkill3;
    [SerializeField] public float manaConsumptionSkill4;

    void Start()
    {
        onOffImage.color = new Color(onOffImage.color.r, onOffImage.color.g, onOffImage.color.b, 0.4f);
    }
    void Update()
    {
        manaConsumptionSkillJ = 0f;
        manaConsumptionSkillR = GetComponent<SummonMinion>().manaConsumption;
        manaConsumptionSkillE = GetComponent<SummonWeapon>().manaConsumption;

        manaConsumptionSkillJText.text = "0";
        manaConsumptionSkillRText.text = manaConsumptionSkillR.ToString("0");
        manaConsumptionSkillEText.text = manaConsumptionSkillE.ToString("0");

        onShield = GetComponent<PlayerShieldController>().onShield;

        if (GameObject.Find("Weapon"))
        {
            manaConsumptionSkill1 = GameObject.Find("Weapon").GetComponent<WeaponStatus>().manaConsumptionSkill1;
            manaConsumptionSkill2 = GameObject.Find("Weapon").GetComponent<WeaponStatus>().manaConsumptionSkill2;
            manaConsumptionSkill3 = GameObject.Find("Weapon").GetComponent<WeaponStatus>().manaConsumptionSkill3;
            manaConsumptionSkill4 = GameObject.Find("Weapon").GetComponent<WeaponStatus>().manaConsumptionSkill4;

            manaConsumptionSkill1Text.text = manaConsumptionSkill1.ToString("0");
            manaConsumptionSkill2Text.text = manaConsumptionSkill2.ToString("0");
            manaConsumptionSkill3Text.text = manaConsumptionSkill3.ToString("0");
            manaConsumptionSkill4Text.text = manaConsumptionSkill4.ToString("0");

            skill1Animation = GameObject.Find("Weapon").GetComponent<WeaponStatus>().skill1Animation;
            skill2Animation = GameObject.Find("Weapon").GetComponent<WeaponStatus>().skill2Animation;
            skill3Animation = GameObject.Find("Weapon").GetComponent<WeaponStatus>().skill3Animation;
            skill4Animation = GameObject.Find("Weapon").GetComponent<WeaponStatus>().skill4Animation;

            onOffImage.color = new Color(onOffImage.color.r, onOffImage.color.g, onOffImage.color.b, 0f);
            imageSkillJ.color = new Color(imageSkillJ.color.r, imageSkillJ.color.g, imageSkillJ.color.b, 0.4f);
            if (onShield)
            {
                onOffImage.color = new Color(onOffImage.color.r, onOffImage.color.g, onOffImage.color.b, 0.4f);
            }else onOffImage.color = new Color(onOffImage.color.r, onOffImage.color.g, onOffImage.color.b, 0f);
            if (Input.GetKeyDown(KeyCode.I) && !onSkills && !onShield)
            {
                Debug.Log("Doi mau 1 ne");
                onSkills = true;
                imageSkill1.color = new Color(imageSkill1.color.r, imageSkill1.color.g, imageSkill1.color.b, 0.4f);
                Invoke("ResetAlphaSkill1", skill1Animation);
            }
            if (Input.GetKeyDown(KeyCode.O) && !onSkills && !onShield)
            {
                Debug.Log("Doi mau 2 ne");
                onSkills = true;
                imageSkill2.color = new Color(imageSkill2.color.r, imageSkill2.color.g, imageSkill2.color.b, 0.4f);
                Invoke("ResetAlphaSkill2", skill2Animation);
            }
            if (Input.GetKeyDown(KeyCode.P) && !onSkills && !onShield)
            {
                Debug.Log("Doi mau 3 ne");
                onSkills = true;
                imageSkill3.color = new Color(imageSkill3.color.r, imageSkill3.color.g, imageSkill3.color.b, 0.4f);
                Invoke("ResetAlphaSkill3", skill3Animation);
            }
            if (Input.GetKeyDown(KeyCode.U) && !onSkills && !onShield)
            {
                Debug.Log("Doi mau 4 ne");
                onSkills = true;
                imageSkill4.color = new Color(imageSkill4.color.r, imageSkill4.color.g, imageSkill4.color.b, 0.4f);
                Invoke("ResetAlphaSkill4", skill4Animation);
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                onOffImage.color = new Color(onOffImage.color.r, onOffImage.color.g, onOffImage.color.b, 0.4f);
                imageSkillJ.color = new Color(imageSkillJ.color.r, imageSkillJ.color.g, imageSkillJ.color.b, 1f);
            }

        }
        else 
        {
            onOffImage.color = new Color(onOffImage.color.r, onOffImage.color.g, onOffImage.color.b, 0.4f);
            manaConsumptionSkill1Text.text = "";
            manaConsumptionSkill2Text.text = "";
            manaConsumptionSkill3Text.text = "";
            manaConsumptionSkill4Text.text = "";
        } 
    }
    void ResetAlphaSkill1()
    {
        imageSkill1.color = new Color(imageSkill1.color.r, imageSkill1.color.g, imageSkill1.color.b, 1);
        onSkills = false;
    }
    void ResetAlphaSkill2()
    {
        imageSkill2.color = new Color(imageSkill2.color.r, imageSkill2.color.g, imageSkill2.color.b, 1);
        onSkills = false;
    }
    void ResetAlphaSkill3()
    {
        imageSkill3.color = new Color(imageSkill3.color.r, imageSkill3.color.g, imageSkill3.color.b, 1);
        onSkills = false;
    }
    void ResetAlphaSkill4()
    {
        imageSkill4.color = new Color(imageSkill4.color.r, imageSkill4.color.g, imageSkill4.color.b, 1);
        onSkills = false;
    }
}
