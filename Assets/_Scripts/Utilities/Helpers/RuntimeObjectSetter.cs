using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuntimeObjectSetter : MonoBehaviour {

    [SerializeField]
    private ObjectRuntimeTable runtimeTable;

    void OnEnable()
    {
        runtimeTable.Add(this.gameObject.GetInstanceID(), this.gameObject);   
    }

    void OnDisable()
    {
        runtimeTable.Remove(this.gameObject.GetInstanceID());
    }
}
