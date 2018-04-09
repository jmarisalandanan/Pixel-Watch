using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class UltimateDisplay : MonoBehaviour {

    [SerializeField] private Image fillImage;
    [SerializeField] private TextMeshProUGUI chargeText;
    [SerializeField] private IntVariable chargeValue;

    public void OnChargeUpdated()
    {
        chargeText.text = chargeValue.localValue.ToString();
        fillImage.fillAmount = (float)chargeValue.localValue / (float)chargeValue.value;
    }
}
