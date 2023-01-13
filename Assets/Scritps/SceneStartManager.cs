using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStartManager : MonoBehaviour
{
    public GameObject containerObject;
    private void Start()
    {
        GameObject.Find("ContainerObject").transform.position = new Vector3(-4f, 3f, 0f);
        if (GameObject.Find("ContainerObject"))
        {
            Destroy(GameObject.Find("Weapon"));
        }
    }
    void Update()
    {
        if (!GameObject.Find("ContainerObject"))
        {
            GameObject newCon = Instantiate(this.containerObject);
            newCon.name = "ContainerObject";
            newCon.transform.position = gameObject.transform.position;
        }
    }
}
