using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using Timers;
using TMPro;

//Throwaway code
public class GenericSkillDisplay : MonoBehaviour {
    [SerializeField] private FloatVariable skillCooldown;
    [SerializeField] private TextMeshProUGUI cooldownText;
    [SerializeField] private Image skillImage;

    private bool isCooldown = false;

    void Awake()
    {
        cooldownText.gameObject.SetActive(false);
        skillImage.color = Color.blue;
    }

    public void Cooldown()
    {
        cooldownText.gameObject.SetActive(true);
        skillImage.color = Color.grey;
        TimersManager.SetTimer(this, skillCooldown.value,OnCooldownFinish);
        isCooldown = true;
    }

    void OnCooldownFinish()
    {
        //Add UI effect here
        isCooldown = false;
        skillImage.color = Color.blue;
        cooldownText.gameObject.SetActive(false);
    }

    void Update()
    {
        if(isCooldown)
        {
            UpdateCooldownText();
        }
    }

    private void UpdateCooldownText()
    {
        cooldownText.text = Mathf.CeilToInt(TimersManager.GetTimerByName(OnCooldownFinish).RemainingTime()).ToString();
    }

}
