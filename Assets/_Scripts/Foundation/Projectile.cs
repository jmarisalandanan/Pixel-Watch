using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    [SerializeField] private Transform targetOrigin;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private FloatVariable projectileSpeed;

    public void LaunchProjectile()
    {
        //Should be pooling, but irrelevant for this study
        GameObject go = GameObject.Instantiate(projectilePrefab);
        go.GetComponent<Bomb>().StartDetonation();
        Rigidbody2D thisRigidbody = go.GetComponent<Rigidbody2D>();
        thisRigidbody.position = targetOrigin.position;
        thisRigidbody.AddForce(targetOrigin.right * projectileSpeed.value, ForceMode2D.Impulse);
    }

}
