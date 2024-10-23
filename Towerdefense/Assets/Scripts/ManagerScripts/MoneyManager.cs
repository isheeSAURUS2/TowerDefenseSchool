using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class MoneyManager : MonoBehaviour
{
    public int Money;
    public int MoneyMultiplier;
    [SerializeField] private TMP_Text MoneyCounterText;
    void Update()
    {
        MoneyCounterText.text = $"Money:{Money}";
    }
    private void Start()
    {
        StartCoroutine("MoneyGeneration");
    }
    private IEnumerator MoneyGeneration()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            Money += 2 * MoneyMultiplier;
        }
    }
    public void TakeMoney(int moneyToTake)
    {
        Money -= moneyToTake;
    }
    public void Cheat()
    {
        Money += 30000000;
    }
}
