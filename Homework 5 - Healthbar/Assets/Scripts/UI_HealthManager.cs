using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HealthManager : MonoBehaviour
{
    RectTransform[] healthBars;
    Health health;

    // Start is called before the first frame update
    void Start()
    {
        HorizontalLayoutGroup group = GetComponentInChildren<HorizontalLayoutGroup>();
        healthBars = group.GetComponentsInChildren<RectTransform>();

        health = GetComponentInParent<Health>();
    
        health.OnTakeDamage += Health_OnTakeDamage;
    }

    private void Health_OnTakeDamage()
    {
        for (int i = healthBars.Length - 1; i >= 0; --i)
        {
            if (healthBars[i].gameObject.activeInHierarchy)
            {
                healthBars[i].gameObject.SetActive(false);
                break;
            }
        }
    }

    private void OnDestroy()
    {
        health.OnTakeDamage -= Health_OnTakeDamage;
    }
}
