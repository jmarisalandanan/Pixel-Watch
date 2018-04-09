using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GeneralTable", menuName = "Config/HealthTable")]
public class HealthRuntimeTable : RuntimeTable<int,Health> {

    public void DamageHealth(int instanceID, int damage)
    {
        KeyPair[instanceID].OnDamage(damage);
    }
}
