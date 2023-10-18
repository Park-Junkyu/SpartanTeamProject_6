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
    public Transform weaponSlotPanel;
    public GameObject[] NoUse;
    public GameObject WeaponUI;
    private void Start()
    {
        // ó������ ���� ���� ��ư ��Ȱ��ȭ
        gameStartButton.interactable = false;
        gameStartButton.onClick.AddListener(StartGame);
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

        UpdateWeaponSlots();
        // ������ ������ �� ����
        HighlightSelectedWeapons();


    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
        DontDestroyOnLoad(WeaponUI);
        foreach(var t in NoUse)
        {
            t.SetActive(false);
        }
    }


    private void HighlightSelectedWeapons()
    {
        foreach (GameObject weaponButton in weaponButtons)
        {

            bool isSelected = selectedWeapons.Contains(weaponButton);
            weaponButton.GetComponent<Image>().color = isSelected ? Color.green : Color.white;
        }

    }

    public void UpdateWeaponSlots()
    {
       
        int currentSlotCount = weaponSlotPanel.childCount;

        
        foreach (Transform slot in weaponSlotPanel)
        {
            Destroy(slot.gameObject);
        }

        
        int maxSlotCount = 5;

        
        for (int i = 0; i < Mathf.Min(maxSlotCount, selectedWeapons.Count); i++)
        {
            GameObject selectedWeapon = selectedWeapons[i];
            GameObject slot = new GameObject("WeaponSlot"); 
            slot.transform.SetParent(weaponSlotPanel); 

           
            Image selectedWeaponImage = selectedWeapon.GetComponent<Image>();

           
            Image slotImage = slot.AddComponent <Image>();
            slotImage.sprite = selectedWeaponImage.sprite; // �θ� ���� ������Ʈ�� �̹����� ���� �̹����� ����

            if (i == 0)
            {
                // ù ��° ���� (���� ����)�� ���� ���� 1�� ����
                slotImage.color = new Color(1, 1, 1, 1);
            }
            else
            {
                // ������ ���� (�������� ���� ����)�� ���� ���� 0.4�� ����
                slotImage.color = new Color(1, 1, 1, 0.4f);
            }

            // ���Կ� ��ư ������Ʈ �߰�
            Button slotButton = slot.AddComponent<Button>();
           
            int slotIndex = i; // ������ �ε��� ����
            slotButton.onClick.AddListener(() => SlotClicked(slotIndex));
        }
    }


    private void SlotClicked(int slotIndex)
    {
        // ���� �ε����� ���� �ٸ� ������ ����
        for (int i = 0; i < selectedWeapons.Count; i++)
        {
            Image slotImage = weaponSlotPanel.GetChild(i).GetComponent<Image>();
            if (i == slotIndex)
            {
                // Ŭ���� ���� (���� ����)�� ���� ���� 1�� ����
                slotImage.color = new Color(1, 1, 1, 1);
            }
            else
            {
                // �ٸ� ���� (���õ��� ���� ����)�� ���� ���� 0.4�� ����
                slotImage.color = new Color(1, 1, 1, 0.4f);
            }
        }

    }
}
