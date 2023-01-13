using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    float playerPosX;
    List<GameObject> minions;
    public GameObject eagle;
    protected float spawnTimer = 0f;
    protected float spawnDelay = 2f;
    void Start()
    {
        this.minions = new List<GameObject>();
        this.eagle = GameObject.Find("eaglePrefab");
        this.eagle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        this.playerPosX = transform.position.x;
        int spawnLocation = 1;
        if (this.playerPosX >= spawnLocation) this.Spawn();
        else this.NotSpawn();
        this.CheckMinionDead();
    }
    void Spawn()
    {
        this.spawnTimer += Time.deltaTime;//delay time sinh quai
        if (this.spawnTimer < this.spawnDelay) return;
        this.spawnTimer = 0f;

        if (this.minions.Count >= 1) return;

        int index = this.minions.Count + 1;
        GameObject minion = Instantiate(this.eagle);
        minion.name = "eagle" + index;
        Vector3 temp = new Vector3(2f, 2f, 0);//tao bien nho voi kieu du lieu la vector3
        minion.transform.position = transform.position + temp;
        minion.gameObject.SetActive(true);
        this.minions.Add(minion);
        //minion.AddComponent<For>();--them script cho object duoc spawn ra
    }

    void CheckMinionDead()
    {
        GameObject minion;
        for(int i = 0; i < this.minions.Count; i++)
        {
            minion = this.minions[i];
            if (minion == null) this.minions.RemoveAt(i);
        }
    }
    void NotSpawn()
    {
        //Debug.Log("Not Spawn!");
    }
}
