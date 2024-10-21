using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private Slider hpBar;
    [SerializeField] private sceneManager sceneManagerObject;
    public int health;
    [SerializeField] private int maxHealth;
    private void Start()
    {
        health = maxHealth;
        hpBar.maxValue = maxHealth;
    }
    void Update()
    {
        hpBar.value = health;
        if(health <= 0)
        {
            sceneManagerObject.GoToMainMenuScene();
        }
    }

    public void TakeDamage() { health--; }
}
