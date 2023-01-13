using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkill3SpawnFire : MonoBehaviour
{
    public GameObject fireA;
    public GameObject fireB;
    public GameObject fireC;
    public int whatFire;

    float elapsed = 0f;

    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= 2f)
        {
            whatFire = Random.Range(1, 4);
            elapsed = elapsed % 2f;
            if(whatFire == 1)
            {
                SpawnFire(fireA);
            } 
            else if (whatFire == 2)
            {
                SpawnFire(fireB);
            }
            else 
            {
                for (int amount = 0; amount < 3; amount++)
                    SpawnFire(fireC); 
            }
            
        }
    }
    void SpawnFire(GameObject fire)
    {
        GameObject newFire = Instantiate(fire);
        Vector3 temp = new Vector3(-0.2f, 0f, 0f);
        newFire.transform.position = transform.position + temp;
        newFire.SetActive(true);
    }
}
