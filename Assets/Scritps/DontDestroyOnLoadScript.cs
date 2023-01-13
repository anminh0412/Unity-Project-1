using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoadScript : MonoBehaviour
{
    private GameObject containerObject;
    void Update()
    {
        containerObject = GameObject.Find("ContainerObject");
        DontDestroyOnLoad(this.containerObject);
    }
}
