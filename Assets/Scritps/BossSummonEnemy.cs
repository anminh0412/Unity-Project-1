using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSummonEnemy : MonoBehaviour
{
    public GameObject enemy;
    public float posY;
    public string sound;
    void Start()
    {
        GameObject.Find("BossSoundManager").GetComponent<BossSoundManager>().PlaySound(sound);
        Invoke("Spawn", 1.2f);
        Invoke("Destroy", 1.4f);
    }

    void Spawn()
    {
        GameObject enemy = Instantiate(this.enemy);
        Vector3 temp = new Vector3(0f, posY, 0f);
        enemy.transform.position = transform.position + temp;
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }
}
