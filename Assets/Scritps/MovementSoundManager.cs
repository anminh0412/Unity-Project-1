using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSoundManager : MonoBehaviour
{
    public AudioClip playerRun;
    public AudioClip playerJump;

    public AudioSource audioSrc;

    public void PlaySound(string clip)
    {
        switch (clip)
        {
            case "run":
                audioSrc.PlayOneShot(playerRun);
                break;
            case "jump":
                audioSrc.PlayOneShot(playerJump);
                break;
        }

    }
}
