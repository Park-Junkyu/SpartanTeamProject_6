using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FAQ : MonoBehaviour
{
    public Button Btnn;
    public GameObject Option;
 
    bool pause = false;
    public void ToggleOption()
    {
        if (Option.activeSelf == false)
        {
            Option.SetActive(true); // ��ũ��Ʈ�� Ȱ��ȭ
        }
        else
        {
            Option.SetActive(false); // ��ũ��Ʈ�� ��Ȱ��ȭ
        }
    }


    void Update()
    {
        
    }
}
