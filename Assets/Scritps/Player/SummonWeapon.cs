using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SummonWeapon : MonoBehaviour
{
    public GameObject weaponPrefab;
    public GameObject player;
    public GameObject playerAura;
    protected float time;
    public float countdownTime;
    public float setExirtTime;
    protected float existTime;
    public bool exist = false;
    //public string weapon;
    private float currentMana;
    public float manaConsumption;

    public Text cdText;
    private string timeString;
    private bool startCountdown = false;
    public Image image;
    void Start()
    {
        this.time = 0f;
        this.existTime = this.setExirtTime;  
        GetComponent<WeaponSkills>().enabled = false;
        //weaponPrefab = GameObject.Find(weapon);
        //weaponPrefab.SetActive(false);
        player = GameObject.Find("player");
        GameObject.FindGameObjectWithTag("Weapon").SetActive(false);
    }

    void Update()
    {
       
        currentMana = GetComponent<ManaUsed>().currentMana;
        this.player.GetComponent<WeaponSkills>().enabled=false;
        this.time -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.E) && this.time <= 0f && !exist && manaConsumption <= currentMana)
        {
            GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySound("skillE");
            GetComponent<ManaUsed>().UseMana(manaConsumption);
            this.player.AddComponent<WeaponSkills>();
            SummonPrefabWeapon();
            this.time = this.countdownTime;
            exist = true;
            startCountdown = true;
            //playerAura.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.E) && this.time <= 0f && !exist && manaConsumption > currentMana) 
        { 
            GetComponent<ManaUsed>().ManaLessNotificationOn();
        }
        else if (Input.GetKeyDown(KeyCode.F) && exist)
        {
            //startCountdown = false;
            Destroy(GameObject.Find("Weapon"));
            exist = false;
            this.existTime = this.setExirtTime;
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
                GameObject.Find("Weapon").GetComponent<DestroyEvent>().enabled = true;
                Destroy(this.player.GetComponent<WeaponSkills>());
                //weaponPrefab.SetActive(false);
                exist = false;
                this.existTime = this.setExirtTime;
                //playerAura.SetActive(false);
            }
        }
    }
    void SummonPrefabWeapon()
    {
        GameObject weapon = Instantiate(this.weaponPrefab);
        weapon.transform.SetParent(player.transform);
        weapon.name = "Weapon";
        weapon.SetActive(true);
    }
}
