using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseBomb : MonoBehaviour {

    [SerializeField] private GameEvent onPulseBombLaunched;
    private bool ultimateReady = false;

    public void SetUltimateReady()
    {
        ultimateReady = true;
    }

    public void UseUltimate()
    {
        if (ultimateReady)
        {
            onPulseBombLaunched.Raise();
        }
    }

}
