using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Timers;

public class Ultimate : MonoBehaviour {

    [SerializeField] private IntVariable ultimateCharge;
    [SerializeField] private IntVariable ultimateNaturalChargeRate;
    [SerializeField] private IntVariable ultimateExternalChargeRate;

    [SerializeField] private GameEvent onUltimateUpdate;
    [SerializeField] private GameEvent onUltimateReady;

    private bool isCharging = false;

    void Awake()
    {
        Initialize();
        ResetUltimate();
    }

    public void ResetUltimate()
    {
        ultimateCharge.localValue = 0;
    }

    public void Initialize()
    {
        TimersManager.SetLoopableTimer(this, 1, OnTimerTick);
        isCharging = true;
    }

    public void ExternalCharge()
    {
        if (!isCharging)
            return;
        AddCharge(ultimateExternalChargeRate.value);
    }

    private void OnTimerTick()
    {
        if (!isCharging)
            return;
        AddCharge(ultimateNaturalChargeRate.value);
    }

    private void AddCharge(int value)
    {
        ultimateCharge.localValue += value;
        onUltimateUpdate.Raise();
        if (ultimateCharge.localValue >= ultimateCharge.value)
        {
            isCharging = false;
            onUltimateReady.Raise();
        }
    }


}
