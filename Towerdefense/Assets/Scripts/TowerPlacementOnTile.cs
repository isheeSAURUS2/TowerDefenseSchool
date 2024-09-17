using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacementOnTile : MonoBehaviour
{
    [SerializeField] GameObject MoneyManager;
    [SerializeField] private int Money;
    [SerializeField] int StandardTowerCost;
    [SerializeField] int SilverTowerCost;
    [SerializeField] int GoldTowerCost;
    [SerializeField] GameObject TowerStandard;
    [SerializeField] GameObject TowerSilver;
    [SerializeField] GameObject TowerGold;
    private GameObject TowerPlacementUI;
    
    private void Start()
    {
        TowerPlacementUI = GetComponent<TileScript>().TowerPlacementUI;
        MoneyManager = GameObject.FindGameObjectWithTag("MoneyManager");
        
    }
    private void Update()
    {
        Money = MoneyManager.GetComponent<MoneyManager>().Money;
    }
    public void SpawnStandardTower()
    {
        if (Money >= StandardTowerCost)
        {
            Instantiate(TowerStandard);
            
        }
        else if(Money < StandardTowerCost)
        {
            Debug.LogWarning("not enough doekoe");
        }
        
        DeactivateTowerPlacementUI();
    }
    public void SpawnSilverTower()
    {
        if (Money >= SilverTowerCost)
        {
            Instantiate(TowerSilver);

        }
        else if (Money < SilverTowerCost)
        {
            Debug.LogWarning("not enough doekoe");
        }
        
        DeactivateTowerPlacementUI();
    }
    public void SpawnGoldTower()
    {
        if (Money >= GoldTowerCost)
        {
            Instantiate(TowerGold);
        }
        else if (Money < GoldTowerCost)
        {
            Debug.LogWarning("not enough doekoe");
        }
        
        DeactivateTowerPlacementUI();
    }
    private void DeactivateTowerPlacementUI()
    {
        Transform[] uiArray = TowerPlacementUI.GetComponentsInChildren<Transform>(true);
        for (int i = 0; i < uiArray.Length; i++)
        {
            uiArray[i].gameObject.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
