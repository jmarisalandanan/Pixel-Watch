using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class AmmoDisplay : MonoBehaviour {

    [SerializeField] private IntVariable ammo;
    [SerializeField] private TextMeshProUGUI currentAmmo;
    [SerializeField] private TextMeshProUGUI maxAmmo;

    void Start()
    {
        maxAmmo.text = "/ " + ammo.value.ToString();
    }

    public void UpdateAmmoCount()
    {
        currentAmmo.text = ammo.localValue.ToString();
    }
}
