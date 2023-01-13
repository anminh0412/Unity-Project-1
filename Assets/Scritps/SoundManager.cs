using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{ 
    public AudioClip playerSkillJ;
    public AudioClip playerSkillE;
    public AudioClip playerSkillR;
    public AudioClip playerSkillU;
    public AudioClip playerSkillI;
    public AudioClip playerSkillO;
    public AudioClip playerSkillP;
    public AudioClip playerHurt;
    public AudioClip playerDie;
    public AudioClip enemyDie;
    public AudioClip winScene;
    public AudioClip buttonClick;
    public AudioClip bossDie;
    public AudioClip playerShield;
    public AudioClip playerFallOver;

    public AudioSource audioSrc;
    public AudioSource ShiedlAudioSrc;

    public void PlaySound (string clip)
    {
        switch (clip)
        {
            case "skillJ":
                audioSrc.PlayOneShot(playerSkillJ);
                break;
            case "skillE":
                audioSrc.PlayOneShot(playerSkillE);
                break;
            case "skillR":
                audioSrc.PlayOneShot(playerSkillR);
                break;
            case "skillU":
                audioSrc.PlayOneShot(playerSkillU);
                break;
            case "skillI":
                audioSrc.PlayOneShot(playerSkillI);
                break;
            case "skillO":
                audioSrc.PlayOneShot(playerSkillO);
                break;
            case "skillP":
                audioSrc.PlayOneShot(playerSkillP);
                break;
            case "playerHurt":
                audioSrc.PlayOneShot(playerHurt);
                break;
            case "playerDie":
                audioSrc.PlayOneShot(playerDie);
                break;
            case "enemyDie":
                audioSrc.PlayOneShot(enemyDie);
                break;
            case "bossDie":
                audioSrc.PlayOneShot(bossDie);
                break;
            case "win":
                audioSrc.PlayOneShot(winScene);
                break;
            case "buttonClick":
                audioSrc.PlayOneShot(buttonClick);
                break;
            case "playerShield":
                ShiedlAudioSrc.Play();
                break;
            case "playerFallOver":
                audioSrc.PlayOneShot(playerFallOver);
                break;
        }

    }
}
