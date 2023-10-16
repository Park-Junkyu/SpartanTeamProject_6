using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WeaponSelect : MonoBehaviour
{
    public GameObject[] weaponButtons;      // ���� �迭
    public int maxWeaponSelect = 5;         // ���� ������ �ִ� ���� ��
    public List<GameObject> selectedWeapons = new List<GameObject>(); // ���õ� ���� ����Ʈ
    public Button gameStartButton;          // ���� ���� ��ư


    private void Start()
    {
        // ó������ ���� ���� ��ư ��Ȱ��ȭ
        gameStartButton.interactable = false;
    }


    public void WeaponSelection(GameObject weaponButton)
    {


        if (selectedWeapons.Contains(weaponButton))
        {
            // �̹� ���õ� ���� Ŭ���� ���� ����
            selectedWeapons.Remove(weaponButton);
        }
        else if (selectedWeapons.Count < maxWeaponSelect)
        {
            // ���� ������ �ִ� ���� ���� ���� ���� �ʾ����� ���� ����
            selectedWeapons.Add(weaponButton);
        }

        // ���õ� ���� ���� ���� ���� ���� ��ư Ȱ��ȭ
        gameStartButton.interactable = selectedWeapons.Count == maxWeaponSelect;


        // ������ ������ �� ����
        HighlightSelectedWeapons();


    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }


    private void HighlightSelectedWeapons()
    {
        foreach (GameObject weaponButton in weaponButtons)
        {

            bool isSelected = selectedWeapons.Contains(weaponButton);
            weaponButton.GetComponent<Image>().color = isSelected ? Color.green : Color.white;
        }

    }


}
