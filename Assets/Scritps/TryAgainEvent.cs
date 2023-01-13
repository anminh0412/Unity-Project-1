using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryAgainEvent : MonoBehaviour
{
    private GameObject containerObject;
    private void Update()
    {
        containerObject = GameObject.Find("ContainerObject");
    }
    public void TryAgain()
    {
        Destroy(containerObject);
    }
}
