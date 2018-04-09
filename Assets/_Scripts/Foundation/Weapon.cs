using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using Timers;

public class Weapon : MonoBehaviour {

    [SerializeField]
    private IntVariable damage;
    [SerializeField]
    private IntVariable ammoPerClip;
    [SerializeField]
    private FloatVariable reloadSpeed;
    [SerializeField]
    private FloatVariable rateOfFire;

    [SerializeField]
    private GameEvent onFireWeapon;
    [SerializeField]
    private GameEvent onUpdateHud;
    [SerializeField]
    private HealthRuntimeTable healthMap;
   
    private float nextFireTime = 1;
    private bool isReloading;

    void Awake()
    {
        ammoPerClip.localValue = ammoPerClip.value;
        onUpdateHud.Raise();
    }

    void Start()
    {
        onUpdateHud.Raise();
    }

    public void Fire()
    {
        if (Time.time > nextFireTime && ammoPerClip.localValue > 0)
        {
            onFireWeapon.Raise();
            nextFireTime = Time.time + rateOfFire.value;
            ammoPerClip.localValue--;
            onUpdateHud.Raise();
        }

        if (ammoPerClip.localValue <= 0 && !isReloading)
        {
            Reload();
        }
    }

    public void OnHitEnemy(int instanceID)
    {
        healthMap.DamageHealth(instanceID, damage.value);
    }

    public void Reload()
    {
        isReloading = true;
        TimersManager.SetTimer(this, reloadSpeed.value, ReloadFinished);
    }

    private void ReloadFinished()
    {
        isReloading = false;
        ammoPerClip.localValue = ammoPerClip.value;
        onUpdateHud.Raise();
    }
}
