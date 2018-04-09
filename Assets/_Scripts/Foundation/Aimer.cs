using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aimer : MonoBehaviour {

    [SerializeField]
    private Transform arm;

    private Vector3 cachedMousePos;
    private Transform cachedTransform;
    private Camera cachedCamera;

    void Awake()
    {
        cachedTransform = this.transform;
        cachedCamera = Camera.main;
    }

    void Update()
    {
        UpdateArmAim();
    }

    private void UpdateArmAim()
    {
        var pos = cachedCamera.WorldToScreenPoint(cachedTransform.position);
        var dir = Input.mousePosition - pos;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        cachedTransform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
