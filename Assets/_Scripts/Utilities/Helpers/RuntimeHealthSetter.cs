using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuntimeHealthSetter : MonoBehaviour {

    [SerializeField] private HealthRuntimeTable runtimeTable;
    private Health cachedHealth;

    void Awake()
    {
        cachedHealth = this.GetComponent<Health>();
    }

    void OnEnable()
    {
        runtimeTable.Add(this.gameObject.GetInstanceID(), cachedHealth);
    }

    void OnDisable()
    {
        runtimeTable.Remove(this.gameObject.GetInstanceID());
    }

}
