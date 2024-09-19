using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class TowerPlacementOnTile : MonoBehaviour
{
    [SerializeField] GameObject moneyManager;
    private MoneyManager moneyManagerScript;
    [SerializeField] private int money;
    [SerializeField] int standardTowerCost;
    [SerializeField] int silverTowerCost;
    [SerializeField] int goldTowerCost;
    [SerializeField] GameObject towerStandard;
    [SerializeField] GameObject towerSilver;
    [SerializeField] GameObject towerGold;
    [SerializeField] GameObject towerPlacementUI;
    [SerializeField]private GameObject currentlyPlacingTile;
    public List<TileScript> tileScripts;
    private void Start()
    {
        StartCoroutine(MakeTileList());
        moneyManagerScript = moneyManager.GetComponent<MoneyManager>();
        
    }
    private void Update()
    {
        money = moneyManager.GetComponent<MoneyManager>().Money;
    }
    public void SpawnStandardTower()
    {
        if (money >= standardTowerCost)
        {
            Instantiate(towerStandard, currentlyPlacingTile.transform.position, Quaternion.identity);
            moneyManagerScript.TakeMoney(standardTowerCost);
        }
        else if (money < standardTowerCost)
        {
            Debug.LogWarning("not enough doekoe");
        }

        DeactivateTowerPlacementUI();
    }
    public void SpawnSilverTower()
    {
        if (money >= silverTowerCost)
        {
            Instantiate(towerSilver, currentlyPlacingTile.transform.position, Quaternion.identity);
            moneyManagerScript.TakeMoney(silverTowerCost);
        }
        else if (money < silverTowerCost)
        {
            Debug.LogWarning("not enough doekoe");
        }

        DeactivateTowerPlacementUI();
    }
    public void SpawnGoldTower()
    {
        if (money >= goldTowerCost)
        {
            Instantiate(towerGold, currentlyPlacingTile.transform.position, Quaternion.identity);
            moneyManagerScript.TakeMoney(goldTowerCost);
        }
        else if (money < goldTowerCost)
        {
            Debug.LogWarning("not enough doekoe");
        }

        DeactivateTowerPlacementUI();
    }
    public void DeactivateTowerPlacementUI()
    {
        Transform[] uiArray = towerPlacementUI.GetComponentsInChildren<Transform>(true);
        for (int i = 0; i < uiArray.Length; i++)
        {
            uiArray[i].gameObject.SetActive(false);
            Time.timeScale = 1f;
        }
        currentlyPlacingTile = null;
        for (int i = 0; i < tileScripts.Count; i++)
        {
            tileScripts[i].isInUI = false;
            tileScripts[i].highlighter.SetActive(false);
            tileScripts[i].canClickThisGridSquare = false;
        }

    }
    public void PressedTile(GameObject Tile)
    {
        currentlyPlacingTile = Tile;
        for (int i = 0; i < tileScripts.Count; i++)
        {
            tileScripts[i].isInUI = true;
        }
    }
    private IEnumerator MakeTileList()
    {
        yield return new WaitForSeconds(0.01f);
        TileScript[] tilesDetected = GameObject.FindObjectsOfType<TileScript>();
        for (int i = 0; i < tilesDetected.Length; i++)
        {
            tileScripts.Add(tilesDetected[i]);
        }
    }
}
