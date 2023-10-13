using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public Image slotImage; 

    public bool IsEmpty { get; private set; }

    private void Start()
    {
        // ���� �ʱ�ȭ
        IsEmpty = true;
        slotImage.enabled = false;
    }

    public void AddItem(Sprite itemSprite)
    {
        IsEmpty = false;
        slotImage.sprite = itemSprite;
        slotImage.enabled = true;
    }

    public void RemoveItem()
    {
        IsEmpty = true;
        slotImage.enabled = false;
    }

    public void OnSlotClick()
    {
        if (!IsEmpty)
        {
            
            UseItem();
            RemoveItem(); 
        }
    }

    private void UseItem()
    {
        // ������ ��� ����
    }
}
