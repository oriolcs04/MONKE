using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] EnemyData _enemyData;
    public int damage;
    public int health;

    public static Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        damage = _enemyData.damage; 
        health = _enemyData.health;
    }

    private void Update()
    {
        if (health == 0) { 
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            health--;
            Destroy(collision.gameObject);
        }
    }
}
