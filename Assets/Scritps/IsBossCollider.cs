using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsBossCollider : MonoBehaviour
{
    public Collider2D posCollider;
    public GameObject mess2;
    private Collider2D bossCollider;

    private void Update()
    {
        bossCollider = GameObject.Find("boss").GetComponent<Collider2D>();
        if (posCollider.IsTouching(bossCollider))
        {
            mess2.SetActive(true);
        }
    }
}
