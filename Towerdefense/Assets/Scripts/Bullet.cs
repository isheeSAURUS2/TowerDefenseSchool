using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] public int damage;
    [SerializeField] float speed;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float lifetime;
    // Start is called before the first frame update
    public void SetDamage(int givenDamage)
    {
        damage = givenDamage;
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.right * speed * Time.deltaTime;
        lifetime -= Time.deltaTime;
        if (lifetime < 0)
        {
            Destroy(gameObject);
        }
    }
}
