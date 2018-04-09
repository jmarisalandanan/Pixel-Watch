using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public IntVariable health;
    public int runtimeHealth;

    public UnityEvent onDeath;

    void Awake()
    {
        runtimeHealth = health.value;
    }

    public void OnDamage(int value)
    {
       runtimeHealth -= value;
       if(runtimeHealth <= 0)
        {
            onDeath.Invoke();
        }
    }
}
