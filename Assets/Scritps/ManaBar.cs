using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    private float maxMana;
    public float mana;
    private Image manaBar;
    void Start()
    {
        manaBar = GetComponent<Image>();
        maxMana = GameObject.Find("player").GetComponent<PlayerStatus>().maxMana;
        mana = maxMana;
    }

    // Update is called once per frame
    void Update()
    {
        manaBar.fillAmount = mana / maxMana;
        mana = GameObject.Find("player").GetComponent<ManaUsed>().currentMana;
    }
}
