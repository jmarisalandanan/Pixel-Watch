using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Timers;

[RequireComponent(typeof(Rigidbody2D))]
public class TracerDash : MonoBehaviour {

    [SerializeField] private FloatVariable dashDistance;
    [SerializeField] private IntVariable dashCount;
    [SerializeField] private FloatVariable dashRefillRate;

    [SerializeField] private GameEvent onDashStart;
    [SerializeField] private GameEvent onDashFinish;
    [SerializeField] private GameEvent hudUpdate;

    private Rigidbody2D thisRigidbody;
    private bool isRefilling = false;

    void Awake()
    {
        thisRigidbody = this.GetComponent<Rigidbody2D>();
        dashCount.localValue = dashCount.value;
    }

    void Update()
    {
        CheckDashSupply();
    }

    public void DoDash()
    {
        DetermineDashDirection();
        float finalDashDistValue = dashDistance.value * DetermineDashDirection();
        if (dashCount.localValue >= 0)
        {
            Dash(finalDashDistValue);
            dashCount.localValue--;
            hudUpdate.Raise();
            TimersManager.ClearTimer(AddDashCharge);
            isRefilling = false;
        }
    }

    private float DetermineDashDirection()
    {
        if (thisRigidbody.velocity.x < 0)
        {
            return -1;
        }
        else if(thisRigidbody.velocity.x == 0)
        {
            return thisRigidbody.transform.right.x;
        }

        return 1;
    }

    private void Dash(float direction)
    {
        onDashStart.Raise();
        Vector2 newPosition = thisRigidbody.position;
        newPosition.x += direction;
        thisRigidbody.position = newPosition;
        onDashFinish.Raise();
    }

    private void CheckDashSupply()
    {
        if (isRefilling || dashCount.localValue >= dashCount.value)
            return;

        isRefilling = true;
        TimersManager.SetTimer(this, dashRefillRate.value,AddDashCharge);
    }

    private void AddDashCharge()
    {
        dashCount.localValue++;
        isRefilling = false;
        hudUpdate.Raise();
    }
}
