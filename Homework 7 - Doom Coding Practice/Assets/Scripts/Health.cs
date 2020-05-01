using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action OnTakeDamage;
    
    [SerializeField]
    private int health = 100;

    [SerializeField]
    private int armor = 100;

    public int HP => health;
    public int Armor => armor;



    void TakeDamage()
    {
        int overallHealth = health + armor;

        if (overallHealth > 0)
            overallHealth -= 10;

        armor = (overallHealth / 100) * (overallHealth % 100);
        health = overallHealth - armor;

        OnTakeDamage?.Invoke();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyObject"))
            TakeDamage();
    }

}
