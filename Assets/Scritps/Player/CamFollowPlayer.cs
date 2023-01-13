using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{
    private Transform player;
    public float dampTime = 0.5f;
    private Vector3 velocity = Vector3.zero;
    public Camera camera;

    private void Update()
    {
        player = GameObject.Find("player").transform;
    }
    void FixedUpdate()
    {
        if (player)
        {
            Vector3 point = camera.WorldToViewportPoint(player.position);
            Vector3 delta = player.position - camera.ViewportToWorldPoint(new Vector3(0.2f, 0.3f, point.z)); //(new Vector3(0.5, 0.5, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }
    }
}

