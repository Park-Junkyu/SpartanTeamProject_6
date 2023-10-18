using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] private Button openWeaponSlot;
    [SerializeField] private Button openItemSlot;
    [SerializeField] private GameObject weaponPanel;
    [SerializeField] private GameObject itemPanel;

    [SerializeField] private List<Button> weaponSlots;
    [SerializeField] private List<Button> itemSlots;

    [SerializeField] private TextMeshProUGUI weaponTitle;
    [SerializeField] private TextMeshProUGUI itemTitle;


    private int currentWeaponSlot = 0;
    private int currentItemSlot = 0;
    private int maxSlots = 5;
    private int selectedWeaponIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        openWeaponSlot.onClick.AddListener(OpenSlot_Weapon);
        openItemSlot.onClick.AddListener(OpenSlot_Item);
        weaponPanel.SetActive(false);
        itemPanel.SetActive(false);
        weaponTitle.gameObject.SetActive(true);
        itemTitle.gameObject.SetActive(false);



        for (int i = 0; i < maxSlots; i++)
        {
            weaponSlots[i].gameObject.SetActive(true);
            itemSlots[i].gameObject.SetActive(true);

            Color itemSlotColor = itemSlots[i].image.color;
            itemSlotColor.a = 0.1f;
            itemSlots[i].image.color = itemSlotColor;
        }

        // �ʱ� ����: 0�� ���� ���İ��� 1��, ������ ���� ���İ��� 0.5�� ����
        for (int i = 0; i < maxSlots; i++)
        {
            float alpha = (i == 0) ? 1.0f : 0.5f; // 0�� ���� ���İ��� 1��, ������ ���� ���İ��� 0.5�� ����
            SetSlotAlpha(i, alpha);
            int weaponIndex = i; // ���� ���� ������ �ε����� ����
            weaponSlots[i].onClick.AddListener(() => SelectWeapon(weaponIndex));
        }

    }

    private void OpenSlot_Item()
    {
        itemPanel.SetActive(true);
        weaponPanel.SetActive(false);
        itemTitle.gameObject.SetActive(true);
        weaponTitle.gameObject.SetActive(false);
    }

    private void OpenSlot_Weapon()
    {
        weaponPanel.SetActive(true);
        itemPanel.SetActive(false);
        weaponTitle.gameObject.SetActive(true);
        itemTitle.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weaponPanel.SetActive(true);
            itemPanel.SetActive(false);
            weaponTitle.gameObject.SetActive(true);
            itemTitle.gameObject.SetActive(false);
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weaponPanel.SetActive(false);
            itemPanel.SetActive(true);
            weaponTitle.gameObject.SetActive(false);
            itemTitle.gameObject.SetActive(true);
        }

        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ActivateSlots();
        }

        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            AcquireItem();
        }
    }
    // ������ ���� Ȱ��ȭ
    public void ActivateSlots()
    {
        if (currentItemSlot < maxSlots)
        {

            Color itemSlotColor = itemSlots[currentItemSlot].image.color;
            itemSlotColor.a = 1.0f;
            itemSlots[currentItemSlot].image.color = itemSlotColor;

            currentItemSlot++;
        }
    }



    //������ ��� �� ���� ��Ȱ��ȭ
    public void UseItem()
    {

        if (currentItemSlot > 0)
        {

            // ���� �ֱ� ������ ������ ��Ȱ��ȭ�ϰ� ���� ������ ���� �ε����� ����
            itemSlots[currentItemSlot - 1].gameObject.SetActive(false);
            currentItemSlot--;
        }
    }

    public void AcquireItem()
    {
        if (currentItemSlot < maxSlots)
        {
            itemSlots[currentItemSlot].gameObject.SetActive(true);
            currentItemSlot++;
        }
    }

    private void SetSlotAlpha(int slotIndex, float alpha)
    {
        Color slotColor = weaponSlots[slotIndex].image.color;
        slotColor.a = alpha;
        weaponSlots[slotIndex].image.color = slotColor;
    }

    private void SelectWeapon(int weaponIndex)
    {
        // ���� ���� ������ ���� ���İ��� 0.5�� ����
        SetSlotAlpha(selectedWeaponIndex, 0.5f);

        // ������ ������ ���� ���İ��� 1�� ����
        SetSlotAlpha(weaponIndex, 1.0f);

        // ������ ���⸦ ����
        EquipWeapon(weaponIndex);

        // ������ ������ �ε����� ������Ʈ
        selectedWeaponIndex = weaponIndex;
    }

    private void EquipWeapon(int weaponIndex)
    {

    }
}
