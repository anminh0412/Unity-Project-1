using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject deathPanel;
    [SerializeField] GameObject nextLevelPanel;
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject escPanel;
    public void ToggleDeathPanel()
    {
        deathPanel.SetActive(true);
    }
    public void ToggleNextLevelPanel()
    {
        nextLevelPanel.SetActive(true);
    }
    public void ToggleWinPanel()
    {
        winPanel.SetActive(true);
    }
    public void ToggleEscPanel()
    {
        escPanel.SetActive(true);
    }
    public void ToggleEscOffPanel()
    {
        escPanel.SetActive(false);
    }
}
