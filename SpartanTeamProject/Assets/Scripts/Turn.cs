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
        }
    }
    public void TurnEnd()
    {
        //���ӿ�����Ʈ�� �޾Ƽ� ���� ��ũ��Ʈ enabled = false�� ����
        if (result)
        {
            GameManager.Instance.Player.gameObject.GetComponent<PlayerController>().enabled = false;
        }
        else
        {
            Enemys[TurnCount - 1].gameObject.GetComponent<EnemyTest>().enabled = false;
        }
    }

    public void TurnChange()
    {
        CheckTurn();
        TurnStart();
    }

    IEnumerator TimeCheck()
    {
        yield return new WaitForSeconds(float.Parse(GameManager.Instance.timer.text));
    }
}
