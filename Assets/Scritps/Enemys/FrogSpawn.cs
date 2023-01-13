using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogSpawn : MonoBehaviour
{
    public GameObject frogPrefab;
    public GameObject bossFrogPrefab;
    public Collider2D trapCollider;
    public Collider2D playerCollider;
    public int maxEnemy;
    public bool collided = false;
    protected float timer = 0;
    protected float delay = 0.5f;
    public float xPosSpawn;
    public float yPosSpawn;
    List<GameObject> frogs;
    private void Awake()
    {
        this.frogPrefab.SetActive(false);
        this.bossFrogPrefab.SetActive(false);
        this.frogs = new List<GameObject>();
    }
    private void Update()
    {
        playerCollider = GameObject.Find("player").GetComponent<Collider2D>();
        if (trapCollider.IsTouching(playerCollider))
        {
            collided = true;
        }
        if (collided)
        {
           this.Spawn();
        }
    }
    void Spawn()
    {
        this.timer += Time.deltaTime;//delay time sinh quai
        if (this.timer < this.delay) return;
        this.timer = 0;
        if(frogs.Count <= maxEnemy)
        {
            if (frogs.Count % 50 == 10)
            {
                GameObject bossFrog = Instantiate(this.bossFrogPrefab);
                bossFrog.name = "bossFrogIsCuming";
                Vector3 temp1 = new Vector3(4f, 2f, 0);
                bossFrog.transform.position = transform.position + temp1;
                bossFrog.SetActive(true);
                this.frogs.Add(bossFrog);
            }
            GameObject frog = Instantiate(this.frogPrefab);
            frog.name = "frogIsCuming";
            Vector3 temp2 = new Vector3(xPosSpawn, yPosSpawn, 0);
            frog.transform.position = transform.position + temp2;
            frog.SetActive(true);
            this.frogs.Add(frog);
        }
        
    }

}
