using Unity.VisualScripting;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public GameObject itemPrefab;
    public ItemData itemData;
    public float dropInterval = 5.0f;
    private Vector3 spawnPoint;

    private void Start()
    {
        // ������ �� ������ ������ ��ġ�� �����ϰ� ����
        SetRandomSpawnPoint();
        InvokeRepeating("DropItem", 0.0f, dropInterval);
    }

    private void SetRandomSpawnPoint()
    {
        float randomX = Random.Range(-8.0f, 8.0f);
        float randomY = Random.Range(6.0f, 12.0f);
        spawnPoint = new Vector3(randomX, randomY, 0);
    }

    private void DropItem()
    {
        Instantiate(itemPrefab, spawnPoint, Quaternion.identity);
        
        SetRandomSpawnPoint(); 
    }
       

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            ApplyItemEffect(collision.gameObject);
            Destroy(gameObject);
        }
    }

    private void ApplyItemEffect(GameObject player)
    {
        
    }
}
