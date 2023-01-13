using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public Text titleText;
    public Text descText;

    [SerializeField] private bool checkJ;
    [SerializeField] private bool checkE;
    [SerializeField] private bool checkR;
    [SerializeField] private bool checkI;
    [SerializeField] private bool checkO;
    [SerializeField] private bool checkP;
    [SerializeField] private bool checkU;
    [SerializeField] public bool checkF;
    [SerializeField] private bool spamJumpPos;
    [SerializeField] private bool attackPos;
    [SerializeField] private bool aPos;
    [SerializeField] private bool spaceDownPos;
    [SerializeField] private bool spacePos;
    [SerializeField] public bool isTrap;
    [SerializeField] GameObject playerCanvas;

    private void Start()
    {
        
    }
    private void Update()
    {
        //GameObject.Find("playerCanvasManager").SetActive(true);
        playerCanvas = GameObject.Find("PlayerCanvas");
        playerCanvas.GetComponent<Canvas>().enabled = false;
        spamJumpPos = GameObject.Find("checkClimbTutorial").GetComponent<isCollider>().collided;
        attackPos = GameObject.Find("checkAttackTutorial").GetComponent<isCollider>().collided;
        aPos = GameObject.Find("checkA").GetComponent<isCollider>().collided;
        spaceDownPos = GameObject.Find("checkSpaceDown").GetComponent<isCollider>().collided;
        spacePos = GameObject.Find("checkSpace").GetComponent<isCollider>().collided;
        isTrap = GameObject.Find("checkOnTrapTutorial").GetComponent<isCollider>().collided;

        if (Input.GetKeyDown(KeyCode.X))
        {
            playerCanvas.GetComponent<Canvas>().enabled = true;
            DestroyEvent();
            //GameObject.Find("invisibleBlock").SetActive(false);
        }
        if (aPos)
        {
            descText.text = "Nhấn A hoặc ← để đi sang trái";
        }
        if (spaceDownPos)
        {
            descText.text = "Nhấn Space hoặc W hoặc ↑ để nhảy";
        }if (spacePos)
        {
            descText.text = "Nhấn giữ Space hoặc W hoặc ↑ để nhảy cao hơn";
        }
        if (spamJumpPos)
        {
            descText.text = "Nhấn liên tục Space hoặc W hoặc ↑ để trèo tường";
        }
        if (attackPos)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                checkJ = true;
            }
            playerCanvas.GetComponent<Canvas>().enabled = true;
            titleText.text = "Tấn Công";
            descText.text = "Nhấn J để tấn công!!!";
        }
        if (checkJ)
        {
            descText.text = "Nhấn R để gọi pet";
            if (Input.GetKeyDown(KeyCode.R))
            {
                checkR = true;
            }
        }
        if (checkR)
        {
            descText.text = "Nhấn E để triệu hồi vũ khí";
            if (Input.GetKeyDown(KeyCode.E))
            {
                checkE = true;
            }
        }
        if (checkE)
        {
            descText.text = "Khi vũ khí được triệu hồi, mở khóa 4 kĩ năng. Nhấn U, I, O, P  để sử dụng kĩ năng. Tuy nhiên không thể sử dụng J nữa.";
            if (Input.GetKeyDown(KeyCode.I))
            {
                checkI = true;
            }
            if (Input.GetKeyDown(KeyCode.O))
            {
                checkO = true;
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                checkP = true;
            }
            if (Input.GetKeyDown(KeyCode.U))
            {
                checkU = true;
            }
        }
        if (checkI && checkO && checkP && checkU)
        {
            descText.text = "Nhấn F để hùy triệu hồi vũ khí và có thể sử dụng lại J. Thời gian hồi chiêu gữi nguyên!";
            if (Input.GetKeyDown(KeyCode.F))
            {
                checkF = true;
            }
        }
        if (checkF)
        {
            titleText.text = "Hoàn thành";
            descText.text = "Di chuyên sang phải để thực chiến nào!!!";
            //GameObject.Find("invisibleBlock").SetActive(false);
            Destroy(GameObject.Find("targetTutorial"));
        }
        if (isTrap && checkF)
        {
            titleText.text = "Mục tiêu:";
            descText.text = "Giết 20 con cóc!!!";
            Invoke("DestroyEvent", 2f);          
        }
    }
    public void DestroyEvent()
    {
        Destroy(gameObject);
    }

}
