using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

//Throwaway script
public class HealthBar : MonoBehaviour {
    [SerializeField] private Image fillBar;
    [SerializeField] private TextMeshProUGUI currentHealthText;
    [SerializeField] private TextMeshProUGUI maxHealthText;
    [SerializeField] private HealthRuntimeTable healthRuntimeTable;
    [SerializeField] private ObjectRuntimeTable objectRuntimeTable;

    private Health health;
    private RectTransform cachedRectTransform;
    private Transform cachedTargetTransform;
    private Camera cachedCamera;
    private Vector2 cachedVector;

    private const float yOffset = 170;

    void Awake()
    {
        cachedRectTransform = this.GetComponent<RectTransform>();
        cachedCamera = Camera.main;
    }

    public void Initialize(int instanceId)
    {
        health = healthRuntimeTable.KeyPair[instanceId];
        cachedTargetTransform = objectRuntimeTable.KeyPair[instanceId].transform;
        maxHealthText.text = health.health.value.ToString();
        health.onDeath.AddListener(OnDeath);
    }

    void OnDeath()
    {
        this.gameObject.SetActive(false);
        health.onDeath.RemoveListener(OnDeath);
    }

    void LateUpdate()
    {
        fillBar.fillAmount = (float)health.runtimeHealth / (float)health.health.value;
        currentHealthText.text = health.runtimeHealth.ToString();
        cachedVector = cachedCamera.WorldToScreenPoint(cachedTargetTransform.position);
        cachedVector.y += yOffset;
        cachedRectTransform.position = cachedVector;
    }
}
