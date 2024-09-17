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
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tower"))
        {
            collision.gameObject.GetComponent<Tower>().StartOrStopTakingDamage(true, attack);
        }
    }
}
