using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using TMPro;

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
    [SerializeField] private GameObject currentlyPlacingTile;
    [SerializeField] TMP_Text notEnoughMoneyText;
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
            StartCoroutine(DisplayNotEnoughMoneyText());
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
            StartCoroutine(DisplayNotEnoughMoneyText()); 
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
            StartCoroutine(DisplayNotEnoughMoneyText());
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

    private IEnumerator DisplayNotEnoughMoneyText ()
    {
        notEnoughMoneyText.color = new Color(notEnoughMoneyText.color.r, notEnoughMoneyText.color.g, notEnoughMoneyText.color.b, 1f);
        float fadeTime = 2f;
        float currentTime = 0f;
        while (currentTime < fadeTime)
        {
            float alpha = Mathf.Lerp(1f, 0f, currentTime / fadeTime);
            notEnoughMoneyText.color = new Color(notEnoughMoneyText.color.r, notEnoughMoneyText.color.g, notEnoughMoneyText.color.b, alpha);
            currentTime += Time.deltaTime;
            yield return null;
        }
        yield break;
    }
}
