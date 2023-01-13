using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonExcalibur : MonoBehaviour
{
    public GameObject sword;
    protected float time = 30f;
    protected float countdownTime = 30f;
    protected float existTime = 40f;
    public bool exist = false;
    void Start()
    {
        sword.SetActive(false);
    }
    
    void Update()
    {
        this.SummonSword();
    }
    void SummonSword()
    {
        this.time += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.E) && this.time > this.countdownTime)
        {
            Debug.Log("Trieu hoi kiem thanh go brr brr!!!");
            sword.SetActive(true);
            this.time = 0f;
            exist = true;            
        }
        if (exist)
        {
            this.existTime -= Time.deltaTime;
            if (this.existTime < 0)
            {
                sword.SetActive(false);
                exist = false;
                this.existTime = 40f;
            }      
        }
    }
    
}
