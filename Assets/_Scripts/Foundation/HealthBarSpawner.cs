using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarSpawner : MonoBehaviour {

    [SerializeField] private GameObject spawnPrefab;
    [SerializeField] private HealthRuntimeTable runtimeHealthTable;

    //Didn't implement pooling due to performance not being relevant for this study
    //In production, Initialize only needs to be called once all health bars would be reused

    void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        foreach(KeyValuePair<int,Health> activeEnemies in runtimeHealthTable.KeyPair)
        {
            SpawnPrefab(activeEnemies.Key);
        }
    }

    public void SpawnPrefab(int instanceId)
    {
        GameObject go = GameObject.Instantiate(spawnPrefab, this.transform);
        go.GetComponent<HealthBar>().Initialize(instanceId);
    }


}
