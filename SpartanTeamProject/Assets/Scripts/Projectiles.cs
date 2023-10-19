using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Porjectiles : MonoBehaviour
{
    [SerializeField] private WeaponSO data;

    private void Update()
    {
        transform.right = GetComponent<Rigidbody2D>().velocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Vector3Int cellPos = collision.gameObject.GetComponent<Tilemap>().WorldToCell(transform.position);
            collision.gameObject.GetComponent<Tilemap>().SetTile(new Vector3Int(cellPos.x, cellPos.y - 1), null);
            collision.gameObject.GetComponent<Tilemap>().SetTile(new Vector3Int(cellPos.x, cellPos.y), null);
            collision.gameObject.GetComponent<Tilemap>().SetTile(new Vector3Int(cellPos.x, cellPos.y + 1), null);

            Destroy(this.gameObject);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().TakenDamage(data.WeaponDamage);
            Destroy(this.gameObject);
        }
    }
}
