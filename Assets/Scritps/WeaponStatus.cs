using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStatus : MonoBehaviour
{
    [SerializeField] public float Damage;

    [SerializeField] public float skill1Damage;
    [SerializeField] public float skill2Damage;
    [SerializeField] public float skill3Damage;
    [SerializeField] public float skill4Damage;

    [SerializeField] public float skill1Animation;
    [SerializeField] public float skill2Animation;
    [SerializeField] public float skill3Animation;
    [SerializeField] public float skill4Animation;

    [SerializeField] public float manaConsumptionSkill1;
    [SerializeField] public float manaConsumptionSkill2;
    [SerializeField] public float manaConsumptionSkill3;
    [SerializeField] public float manaConsumptionSkill4;
}
