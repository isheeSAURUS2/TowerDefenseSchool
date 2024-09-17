using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class TileScript : MonoBehaviour
{
    [SerializeField] private Color OffsetColor, BaseColor;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject Highlighter;
    public GameObject TowerPlacementUI;
    [SerializeField]private bool CanClickThisGridSquare = false;

    private void Start()
    {
        TowerPlacementUI = GameObject.FindGameObjectWithTag("TowerPlacementUI");
    }

    public void Init(bool IsOffset)
    {
        if (IsOffset == true)
        {
            spriteRenderer.color = OffsetColor;
        }
        else if (IsOffset == false) 
        {
            spriteRenderer.color = BaseColor;
        }else if (transform.position == Vector3.zero)
        {
            spriteRenderer.color = OffsetColor;
        }
    }
    private void OnMouseEnter()
    {
        Highlighter.SetActive(true);
        CanClickThisGridSquare = true;
    }
    private void OnMouseExit()
    {
        Highlighter.SetActive(false); 
        CanClickThisGridSquare = false;
    }
    private void Update()
    {
        if(CanClickThisGridSquare && Input.GetMouseButtonDown(0))
        {
            Transform[] uiArray = TowerPlacementUI.GetComponentsInChildren<Transform>(true);
            for (int i = 0; i < uiArray.Length; i++)
            {
                uiArray[i].gameObject.SetActive(true);
            }
            //Time.timeScale = 0f;
        }
    }
}

