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
    [SerializeField] int timeBetweenEnemys = 10;
    [SerializeField] float elapsedTime;
    
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
    }
    private IEnumerator RampUpNumbers()
    {
        yield return new WaitForSeconds(60f);
        numberOfEnemysMax++;
        numberOfEnemysMax++;
        yield return new WaitForSeconds(60f);
        numberOfEnemysMax++;
        timeBetweenEnemys--;
        enemyTypes.Add(enemySilver);
        yield return new WaitForSeconds(60f);
        numberOfEnemysMax++;
        timeBetweenEnemys--;
        yield return new WaitForSeconds(60f);
        numberOfEnemysMax++;
        timeBetweenEnemys--;
        enemyTypes.Add(enemyGold);

    }

    private IEnumerator SpawnEnemys()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenEnemys);
            for (int i = 0; i < Random.Range(1,numberOfEnemysMax); i++)
            {
                Instantiate(RandomizeType(), spawnerLocations[Random.Range(0, 5)].position, Quaternion.identity);
                yield return new WaitForSeconds(0.5f);
            }
        }
    }

    private GameObject RandomizeType()
    {
        return enemyTypes[Random.Range(0, enemyTypes.Count)];
    }
}
