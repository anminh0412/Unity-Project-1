using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHealth : MonoBehaviour
{
    public GameObject healthItem;
    public float elapsed = 0f;
    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= 10f)
        {
            elapsed = elapsed % 10f;
            SpawnHealthItem();
        }
    }
    void SpawnHealthItem()
    {
        if (!GameObject.Find("HealthItem"))
        {
            GameObject newHealthItem = Instantiate(this.healthItem);
            newHealthItem.name = healthItem.name;
            Vector3 temp = new Vector3(0f, 0f, 0f);
            newHealthItem.transform.position = transform.position + temp;
        } 
    }
}
