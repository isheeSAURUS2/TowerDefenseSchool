using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitflash : MonoBehaviour
{
    private Material hitflashMat;
    [SerializeField] float flashTime;
    private float currentFlashLength;
    private float flashAmount;
    private void Start()
    {
        hitflashMat = GetComponent<SpriteRenderer>().material;
    }
    private IEnumerator HitFlash()
    {
        while (currentFlashLength < flashTime)
        {
            currentFlashLength += Time.deltaTime;
            flashAmount = Mathf.Lerp(1f, 0f, currentFlashLength / flashTime);
            hitflashMat.SetFloat("_FlashIntensity", flashAmount);
            yield return null;
        }

    }
    public void StartHitFlash()
    {
        currentFlashLength = 0;
        StartCoroutine(HitFlash());
    }
}
