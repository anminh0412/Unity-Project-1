using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSoundManager : MonoBehaviour
{
    public AudioClip bossDefautlAttack_1;
    public AudioClip bossDefautlAttack_2;
    public AudioClip bossDefautlAttack_2_Col1;
    public AudioClip bossDefautlAttack_2_Col2;
    public AudioClip bossSummon;
    public AudioClip bossTelepost;
    public AudioClip bossSkill2Summon_1;
    public AudioClip bossSkill2Summon_2;
    public AudioClip bossSkill3;
    public AudioClip bossSkill3_A_1;
    public AudioClip bossSkill3_A_2;
    public AudioClip bossSkill3_B_1;
    public AudioClip bossSkill3_B_2;
    public AudioClip bossSkill3_C_1;
    public AudioClip bossSkill3_C_2;
    public AudioClip bossSkill3_C_3;

    public AudioSource audioSrc;

    public void PlaySound(string clip)
    {
        switch (clip)
        {
            case "bossDefautlAttack_1":
                audioSrc.PlayOneShot(bossDefautlAttack_1);
                break;
            case "bossDefautlAttack_2":
                audioSrc.PlayOneShot(bossDefautlAttack_2);
                break;
            case "bossDefautlAttack_2_Col1":
                audioSrc.PlayOneShot(bossDefautlAttack_2_Col1);
                break;
            case "bossDefautlAttack_2_Col2":
                audioSrc.PlayOneShot(bossDefautlAttack_2_Col2);
                break;
            case "bossSummon":
                audioSrc.PlayOneShot(bossSummon);
                break;
            case "bossTelepost":
                audioSrc.PlayOneShot(bossTelepost);
                break;
            case "bossSkill2Summon_1":
                audioSrc.PlayOneShot(bossSkill2Summon_1);
                break;
            case "bossSkill2Summon_2":
                audioSrc.PlayOneShot(bossSkill2Summon_2);
                break;
            case "bossSkill3":
                audioSrc.PlayOneShot(bossSkill3);
                break;
            case "bossSkill3_A_1":
                audioSrc.PlayOneShot(bossSkill3_A_1);
                break;
            case "bossSkill3_A_2":
                audioSrc.PlayOneShot(bossSkill3_A_2);
                break;
            case "bossSkill3_B_1":
                audioSrc.PlayOneShot(bossSkill3_B_1);
                break;
            case "bossSkill3_B_2":
                audioSrc.PlayOneShot(bossSkill3_B_2);
                break;
            case "bossSkill3_C_1":
                audioSrc.PlayOneShot(bossSkill3_C_1);
                break;
            case "bossSkill3_C_2":
                audioSrc.PlayOneShot(bossSkill3_C_2);
                break;
            case "bossSkill3_C_3":
                audioSrc.PlayOneShot(bossSkill3_C_3);
                break;
        }

    }
}
