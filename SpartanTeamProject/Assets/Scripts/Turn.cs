using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Turn : MonoBehaviour
{
    [SerializeField] private GameObject[] Enemys;

    public int TurnCount = 0;
    private void Awake()
    {
        GameObject Player = GameManager.Instance.Player;
        Enemys = GameObject.FindGameObjectsWithTag("Enemy");
    }

    public bool CheckTurn()
    {
        bool result = false;
        // ����� True�� �� Player��, False�� �� Enemy��
        if (TurnCount / Enemys.Length == 1)
        {
            TurnCount++;
            result = true;
        }
        else
        {
            TurnCount++;
            result = false;
        }
        if(TurnCount == Enemys.Length)
        {
            TurnCount = 0;
        }
        return result;
    }

    public void TurnStart()
    {
        if (CheckTurn())
        {
            // Player ���� ����
            //Player.gameObject.GetComponent<Playertest>().enabled = true;
            // GetComponent<�÷��̾� ���� ��ũ��Ʈ> << ����
        }
        else
        {
            // Enemy ���۰���
            //for(int i = 0; i<Enemys.Length; i++)
            //{
            //    Enemys[i].gameObject.GetComponent<Enemytest>().enabled = true;
            // GetComponent<�� ���� ��ũ��Ʈ> << ����
            //}
        }
    }
}
