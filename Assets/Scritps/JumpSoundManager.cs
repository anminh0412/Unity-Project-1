using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSoundManager : MonoBehaviour
{
    public AudioClip playerJump;
    public AudioSource audioSrc;
    public void PlaySound()
    {     
        audioSrc.PlayOneShot(playerJump);
    }
}
