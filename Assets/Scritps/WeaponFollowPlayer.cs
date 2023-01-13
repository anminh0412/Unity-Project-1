using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFollowPlayer : MonoBehaviour
{
    public Transform player;

    private void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.5f, player.transform.position.z);
    }
}
