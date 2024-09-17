using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class TileScript : MonoBehaviour
{
    [SerializeField] private Color offsetColor, baseColor;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] public GameObject highlighter;
    public GameObject towerPlacementUI;
    [SerializeField] public bool canClickThisGridSquare = false;
    [SerializeField] private GameObject towerPlacementManager;
    private TowerPlacementOnTile towerPlacementManagerScript;
    [HideInInspector]public bool isInUI;
    [SerializeField] private GameObject thisGameObject;
    public bool hasTower;


    private void Start()
    {
        towerPlacementManagerScript = towerPlacementManager.GetComponent<TowerPlacementOnTile>();
        isInUI = false;
        thisGameObject = gameObject;
    }

    public void Init(bool IsOffset)
    {
        if (IsOffset == true)
        {
            spriteRenderer.color = offsetColor;
        }
        else if (IsOffset == false) 
        {
            spriteRenderer.color = baseColor;
        }else if (transform.position == Vector3.zero)
        {
            spriteRenderer.color = offsetColor;
        }
    }
    private void OnMouseEnter()
    {
        if (!isInUI && !hasTower)
        {
            highlighter.SetActive(true);
            canClickThisGridSquare = true;
        }
    }
    private void OnMouseExit()
    {
        if (!isInUI && !hasTower)
        {
            highlighter.SetActive(false);
            canClickThisGridSquare = false;
        }
    }
    private void Update()
    {
        if(canClickThisGridSquare && Input.GetMouseButtonDown(0)&&!isInUI&&!hasTower)
        {
            Transform[] uiArray = towerPlacementUI.GetComponentsInChildren<Transform>(true);
            for (int i = 0; i < uiArray.Length; i++)
            {
                uiArray[i].gameObject.SetActive(true);
            }
            towerPlacementManagerScript.PressedTile(thisGameObject);
            
            //Time.timeScale = 0f;
        }
    }
}

