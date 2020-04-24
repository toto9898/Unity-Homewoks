using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_HealthManager : MonoBehaviour
{
    Transform[] healthBars;
    Health health;

    float barOffset = 0.055f;

    // Start is called before the first frame update
    void Start()
    {
        healthBars = GetComponentsInChildren<Transform>();
        health = GetComponentInParent<Health>();

        for (int i = 0; i < healthBars.Length; i++)
            healthBars[i].position += new Vector3(barOffset * i, 0, 0);

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
}
