using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SummonMinion : MonoBehaviour
{
    List<GameObject> minions;
    public GameObject eagle;
    private float currentMana;
    public float manaConsumption;
    protected float time;
    public float countdownTime;
    public float setExistTime;
    protected float existTime;
    public bool exist = false;
    private string timeString;
    private bool startCountdown = false;
    public Text cdText;
    public Image image;

    void Start()
    {
        this.minions = new List<GameObject>();
        this.time = 0f;
        this.existTime = this.setExistTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentMana = GetComponent<ManaUsed>().currentMana;
        this.time -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.R) && manaConsumption <= currentMana && this.time <= 0f && !exist) 
        {
            this.Spawn();
            GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySound("skillR");
            GetComponent<ManaUsed>().UseMana(manaConsumption);
            this.time = this.countdownTime;
            exist = true;
            startCountdown = true;
        }
        else if (Input.GetKeyDown(KeyCode.R) && manaConsumption > currentMana && this.time <= 0f && !exist) 
        { 
            GetComponent<ManaUsed>().ManaLessNotificationOn();
        }
        if (startCountdown)
        {
            timeString = time.ToString("0");
            cdText.text = timeString;
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0.4f);
        } 
        if (this.time <= 0)
        {
            cdText.text = "";
            startCountdown = false;
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
        }
            if (exist)
        {           
            this.existTime -= Time.deltaTime;
            if (this.existTime <= 0)
            {
                GameObject.Find("eagle").GetComponent<SelfDestroy>().enabled = true;
                exist = false;
                this.existTime = this.setExistTime;
            }
        }
        CheckMinionDead();
    }
    void Spawn()
    {
        if (this.minions.Count >= 1) return;
        Debug.Log("bo may toi ne!!!");

        GameObject minion = Instantiate(this.eagle);
        minion.name = "eagle";
        Vector3 temp = new Vector3(2f, 2f, 0);
        minion.transform.position = transform.position + temp;
        minion.gameObject.SetActive(true);
        this.minions.Add(minion);
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
}
