using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaUsed : MonoBehaviour
{
    private float maxMana;
    public float currentMana;
    private float manaRecovery;
    public Text notificationText;
    public Text manaText;
    private string stringManaText;

    private void Start()
    {
        maxMana = GetComponent<PlayerStatus>().maxMana;
        manaRecovery = GetComponent<PlayerStatus>().manaRecovery;
        currentMana = maxMana;
    }
    private void Update()
    {
        stringManaText = currentMana.ToString("0");
        manaText.text = stringManaText;
        if(currentMana < maxMana)
        {
            currentMana = currentMana + manaRecovery * Time.deltaTime;
        }
    }
    public virtual void UseMana(float damege)
    {
        currentMana -= damege;
    }
    public void ManaLessNotificationOn()
    {
        StartCoroutine(sendNotìication("You don't have enough mana!!!", 2));
    }
    IEnumerator sendNotìication(string text, int time)
    {
        notificationText.text = text;
        yield return new WaitForSeconds(time);
        notificationText.text = "";
    }
}
