using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeadEvent : MonoBehaviour
{
    void Start()
    {
        GetComponent<DamageSender>().enabled = false;
        Invoke("Destroy", 0.8f);
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySound("bossDie");
    }
    void Destroy()
    {
        GameObject.Find("player").GetComponent<PointManager>().CheckPoint(1);
        Destroy(gameObject);
    }
}
