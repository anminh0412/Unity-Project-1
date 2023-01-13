using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isCollider : MonoBehaviour
{
    public Collider2D posCollider;
    private Collider2D playerCollider;
    public bool collided = false;

    private void Update()
    {
        playerCollider = GameObject.Find("player").GetComponent<Collider2D>();
        if (posCollider.IsTouching(playerCollider))
        {
            collided = true;
        }
    }
}
