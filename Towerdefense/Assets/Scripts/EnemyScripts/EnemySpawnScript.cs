using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{
    [SerializeField] Transform[] spawnerLocations;
    [SerializeField] GameObject enemyStandard;
    [SerializeField] GameObject enemySilver;
    [SerializeField] GameObject enemyGold;
    [SerializeField] List<GameObject> enemyTypes;
    [SerializeField] int numberOfEnemysMax = 1;
    [SerializeField] float timeBetweenEnemys = 10;
    [SerializeField] float elapsedTime;
    [SerializeField] MoneyManager moneyManager;
    
    // Update is called once per frame
    private void Start()
    {
        enemyTypes.Add(enemyStandard);
        StartCoroutine(SpawnEnemys());
        StartCoroutine(RampUpNumbers());
    }
    private void Update()
    {
        elapsedTime += Time.deltaTime;
        if(elapsedTime >= 50f)
        {
            numberOfEnemysMax++;
            timeBetweenEnemys -= 0.2f;
            elapsedTime = 0;
        }
    }
    private IEnumerator RampUpNumbers()
    {
        yield return new WaitForSeconds(120f);
        enemyTypes.Add(enemySilver);
        yield return new WaitForSeconds(120f);       
        enemyTypes.Add(enemyGold);

    }

    private IEnumerator SpawnEnemys()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenEnemys);
            for (int i = 0; i < Random.Range(1,numberOfEnemysMax); i++)
            {
                int newRandomSpawner = Random.Range(0, 5);
                GameObject newEnemy = Instantiate(RandomizeType(), spawnerLocations[newRandomSpawner].position, Quaternion.identity);
                newEnemy.GetComponent<SpriteRenderer>().sortingOrder = spawnerLocations[newRandomSpawner].gameObject.GetComponent<SortingLayervariable>().sortingLayerVariable;
                newEnemy.GetComponent<Enemy>().moneyManager = moneyManager;
                yield return new WaitForSeconds(0.5f);
            }
        }
    }

    private GameObject RandomizeType()
    {
        return enemyTypes[Random.Range(0, enemyTypes.Count)];
    }
}
