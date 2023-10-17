using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    public static GameManager Instance
    {
        get
        {
            return instance == null ? null : instance;
        }
    }

    public GameObject Player;
    public Text timer;
    float time;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void Update()
    {
        time = float.Parse(timer.text);
        time -= Time.deltaTime;
        timer.text = time.ToString("N2");
        //if() // �Ǵ� �÷��̾� ü���� 0�����̸� ����
        //{
        //    GameOver();
        //}
    }
    public void GameOver()
    {
        Time.timeScale = 0f;
        Invoke(nameof(ReloadScene), 3f);
    }

    public void GameClear()
    {
        // UI�� ���� ����, ���θ޴��� ȭ�� �ҷ�����
    }

    public void ReloadScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("IntroScene");
    }
}
