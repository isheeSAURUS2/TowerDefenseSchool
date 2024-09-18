using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    int health;
    int attack;
    [SerializeField] int speed;
    enum enemyType {standard, silver, gold}
    [SerializeField] int standardEnemyHealth;
    [SerializeField] int silverEnemyHealth;
    [SerializeField] int goldEnemyHealth;
    [SerializeField] int standardEnemyAttack;
    [SerializeField] int silverEnemyAttack;
    [SerializeField] int goldEnemyAttack;
    [SerializeField] enemyType type;
    [SerializeField] Rigidbody2D rb;
    float tickTimer;
    void Start()
    {
        if (type == enemyType.standard)
        {
            health = standardEnemyHealth;
            attack = standardEnemyAttack;
        }
        if(type == enemyType.silver)
        {
            health = silverEnemyHealth;
            attack = silverEnemyAttack;
        }
        if (type == enemyType.gold)
        {
            health = goldEnemyHealth;
            attack = goldEnemyAttack;
        }
    }

    private void FixedUpdate()
    {
        
        rb.velocity = Vector2.left * speed * Time.deltaTime;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Tower"))
        {
            tickTimer += Time.deltaTime;
            if (tickTimer >= 1)
            {
                Debug.Log("did damage");
                collision.gameObject.GetComponent<Tower>().health -= attack;
                tickTimer = 0;
            }
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(collision.gameObject.GetComponent<Bullet>().damage);
            Destroy(collision.gameObject);
        }
    }
    private void TakeDamage(int damageToTake)
    {
        //Debug.Log($"took: {damageToTake} Damage");
        health -= damageToTake;
    }
}
