using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    enum towerType { standard, silver, gold };
    [SerializeField] GameObject bullet;
    public int health;
    public int damageToUse;
    public float fireRateToUse;
    public string animationToUse;

    [SerializeField] private towerType typeOfTower;
    [SerializeField] int standardTowerDamage;
    [SerializeField] int silverTowerDamage;
    [SerializeField] int goldTowerDamage;
    [SerializeField] float standardTowerFireRate;
    [SerializeField] float silverTowerFireRate;
    [SerializeField] float goldTowerFireRate;
    [SerializeField] int standardTowerHealth;
    [SerializeField] int silverTowerHealth;
    [SerializeField] int goldTowerHealth;
    GameObject onTile;
    LayerMask mask;
    Coroutine newRoutine;
    bool hasStartedShooting = false;

    // Start is called before the first frame update

    // Update is called once per frame
    private void Start()
    {
        mask = LayerMask.GetMask("Enemy");
        if (typeOfTower == towerType.standard)
        {
            animationToUse = "StandardShoot";
            fireRateToUse = standardTowerFireRate;
            damageToUse = standardTowerDamage;
            health = standardTowerHealth;
        }
        else if (typeOfTower == towerType.silver)
        {
            animationToUse = "SilverShoot";
            health = silverTowerHealth;
            fireRateToUse = goldTowerFireRate;
            damageToUse = goldTowerDamage;
        }
        else if (typeOfTower == towerType.gold)
        {
            animationToUse = "GoldShoot";
            health = goldTowerHealth;
            fireRateToUse = goldTowerFireRate;
            damageToUse = goldTowerDamage;
        }
    }
    public IEnumerator ShootBullet(int bulletDamage, float fireRate)
    {
        while (true)
        {
            yield return new WaitForSeconds(fireRate);
            GetComponent<Animator>().Play(animationToUse);
            GameObject newBullet = Instantiate(bullet, transform.position + new Vector3(0.5f, 0f, 0f), Quaternion.Euler(new Vector3(0, 0, 30)));
            newBullet.GetComponent<Bullet>().SetDamage(bulletDamage);
        }
    }
    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            onTile.GetComponent<TileScript>().hasTower = false;
        }
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 8f, mask);
        Debug.DrawRay(transform.position, Vector3.right * 8, Color.red);

        if (hit.collider != null)
        {
            if (hit.transform.CompareTag("Enemy") && !hasStartedShooting)
            {
                
                newRoutine = StartCoroutine(ShootBullet(damageToUse, fireRateToUse));
                hasStartedShooting = true;
            }
            
        }
        else if(hit.collider == null && hasStartedShooting)
        {
            
            StopCoroutine(newRoutine);
            hasStartedShooting = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tile"))
        {
            onTile = collision.gameObject;
            onTile.GetComponent<TileScript>().hasTower = true;
        }
    }


}
