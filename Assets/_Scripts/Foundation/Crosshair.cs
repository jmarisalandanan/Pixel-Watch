using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    private Transform cachedTransform;
    private Camera cachedCamera;
    private Vector3 cachedVector;

    void Awake()
    {
        cachedCamera = Camera.main;
        cachedTransform = this.transform;
    }
    void Update()
    {
        UpdateCrosshairTransform();
    }

    private void UpdateCrosshairTransform()
    {
        cachedVector = Input.mousePosition;
        cachedVector.z = 10;
        
        cachedTransform.position = cachedCamera.ScreenToWorldPoint(cachedVector);
    }
}
