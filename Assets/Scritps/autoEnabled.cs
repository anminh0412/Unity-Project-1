using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoEnabled : MonoBehaviour
{
    [SerializeField] public bool isTrap = false;
    public GameObject dcmthangKhuong;
    private void Update()
    {
        isTrap = GameObject.Find("checkOnTrapTutorial").GetComponent<isCollider>().collided;
        if (isTrap)
        {
            dcmthangKhuong.SetActive(true);
        }
    }
}
