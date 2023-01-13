using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defaultAttack : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    private void Start()
    {
        if (GameObject.Find("player").GetComponent<PlayerController>().isFacingRight)
        {
            rb.velocity = Vector2.right * speed;
        }
        else if (!GameObject.Find("player").GetComponent<PlayerController>().isFacingRight)
        {
            rb.velocity = Vector2.left * speed;
        }
    }
}
