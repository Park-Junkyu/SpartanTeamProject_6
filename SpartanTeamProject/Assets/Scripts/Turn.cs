using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Turn : MonoBehaviour
{
    [SerializeField] private GameObject[] Enemys;

    public int TurnCount = 0;
    bool result = false;
    private void Awake()
    {
        Enemys = GameObject.FindGameObjectsWithTag("Enemy");
    }

    public bool CheckTurn()
    {
        // ����� True�� �� Player��, False�� �� Enemy��
        if (TurnCount / Enemys.Length == 1)
        {
            result = true;
        }
        else
        {
            result = false;
        }
        TurnCount++;
        if (TurnCount > Enemys.Length)
        {
            TurnCount = 0;
        }

        return result;
    }

    public void TurnStart()
    {
        if (result)
        {
            // Player ���� ����
            GameManager.Instance.Player.gameObject.GetComponent<PlayerController>().enabled = true;
            // GetComponent<�÷��̾� ���� ��ũ��Ʈ> << ����
        }
        else
        {
            // Enemy ���۰���
            Enemys[TurnCount-1].gameObject.GetComponent<EnemyTest>().enabled = true;
            //for(int i = 0; i<Enemys.Length; i++)
            //{
            //    enemys[i].gameobject.getcomponent<enemytest>().enabled = true;
            // GetComponent<�� ���� ��ũ��Ʈ> << ����
            //}
        }
    }
    public void TurnEnd(GameObject obj)
    {
        //���ӿ�����Ʈ�� �޾Ƽ� ���� ��ũ��Ʈ enabled = false�� ����

    }

    public void TurnChange()
    {
        CheckTurn();
        TurnStart();
    }
}
