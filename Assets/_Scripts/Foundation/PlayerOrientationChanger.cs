using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOrientationChanger : MonoBehaviour {

    [SerializeField] private Vector3Variable rightFace;

    [SerializeField] private Vector3Variable leftFace;

    Transform cachedTransform;
    Camera cachedCamera;

    Vector2 mousePosition;
    Vector2 playerScreenPoint;

    void Awake()
    {
        cachedTransform = this.transform;
        cachedCamera = Camera.main;
    }

    void Update()
    {
        CheckOrientation();
    }

    private void CheckOrientation()
    {
        playerScreenPoint = cachedCamera.WorldToScreenPoint(cachedTransform.position);
        mousePosition = Input.mousePosition;

        if(mousePosition.x < playerScreenPoint.x)
        {
            cachedTransform.localEulerAngles = leftFace.value;
        }
        else
        {
            cachedTransform.localEulerAngles = rightFace.value;
        }
    }
}
