using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Timers;

public class Bomb : MonoBehaviour
{
    [SerializeField] private IntVariable damage;
    [SerializeField] private FloatVariable detonationRange;
    [SerializeField] private FloatVariable detonationTime;
    [SerializeField] private HealthRuntimeTable healthRuntimeTable;
    [SerializeField] private ParticleSystem explosionParticle;

    private Collider2D[] cachedOverlapCollider = new Collider2D[6];
    private Transform cachedTransform;

    void Awake()
    {
        cachedTransform = transform;
        StartDetonation();
    }

    public void StartDetonation()
    {
        Array.Clear(cachedOverlapCollider, 0, cachedOverlapCollider.Length);
        TimersManager.SetTimer(detonationTime, detonationTime.value, Explode);
    }

    public void Explode()
    {
        explosionParticle.Play();
        TimersManager.SetTimer(this, 0.3f, Cleanup);
        int results = Physics2D.OverlapCircleNonAlloc(cachedTransform.position, detonationRange.value, cachedOverlapCollider, 1 << 8);
        if(results >= 0)
        {
            for (int i = 0; i < cachedOverlapCollider.Length; i ++)
            {
                if(cachedOverlapCollider[i] == null)
                {
                    return;
                }
                healthRuntimeTable.DamageHealth(cachedOverlapCollider[i].gameObject.GetInstanceID(), damage.value);
            }
        }

    }

    private void Cleanup()
    {
        this.gameObject.SetActive(false);
    }

}
