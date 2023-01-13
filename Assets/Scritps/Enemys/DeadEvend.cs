using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEvend : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<EnemyFollowPlayer>().enabled = false;
        GetComponent<DamageSender>().enabled = false;
        Invoke("Destroy", 0.8f);
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySound("enemyDie");
    }
    void Destroy()
    {
        GameObject.Find("player").GetComponent<PointManager>().CheckPoint(1);
        Destroy(gameObject);
    }
}
