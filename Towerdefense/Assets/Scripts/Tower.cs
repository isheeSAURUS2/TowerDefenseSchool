using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    enum towerType { standard, silver, gold };
    [SerializeField] GameObject bullet;
    public int health;
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
    [SerializeField] GameObject onTile;

    // Start is called before the first frame update

    // Update is called once per frame
    private void Start()
    {
        if (typeOfTower == towerType.standard)
        {
            StartCoroutine(ShootBullet(standardTowerDamage, standardTowerFireRate));
            health = standardTowerHealth;
        }
        else if (typeOfTower == towerType.silver)
        {
            StartCoroutine(ShootBullet(silverTowerDamage, silverTowerFireRate));
            health = silverTowerHealth;
        }
        else if (typeOfTower == towerType.gold)
        {
            StartCoroutine(ShootBullet(goldTowerDamage, goldTowerFireRate));
            health = goldTowerHealth;
        }
    }
    public IEnumerator ShootBullet(int bulletDamage, float fireRate)
    {
        while (true)
        {
            yield return new WaitForSeconds(fireRate);
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
