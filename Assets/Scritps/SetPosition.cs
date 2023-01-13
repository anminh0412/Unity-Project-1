using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPosition : MonoBehaviour
{
    void Start()
    {
        gameObject.transform.position = GameObject.Find("boss").transform.position;
    }
}
