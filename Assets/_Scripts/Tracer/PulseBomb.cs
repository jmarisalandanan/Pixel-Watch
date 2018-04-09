using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseBomb : MonoBehaviour {

    private bool ultimateReady = false;

    public void SetUltimateReady()
    {
        ultimateReady = true;
    }

    public void UseUltimate()
    {
        if (ultimateReady)
        {
            Debug.Log("Ultimate!");
        }
    }

}
