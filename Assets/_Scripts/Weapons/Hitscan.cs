using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using Timers;
 
public class Hitscan : MonoBehaviour {

    [SerializeField] private Transform targetOrigin;
    [SerializeField] private Vector3Variable xSpread;

    [SerializeField]
    private IntGameEvent onEnemyHit;

    public void Scan()
    {
        Quaternion spread = ProjectileHelper.GetRandomConeRotation(xSpread.value, Vector2.zero);
        Debug.DrawRay(targetOrigin.position, (spread * targetOrigin.right) * 50, Color.red, 0.3f);
        RaycastHit2D hit = Physics2D.Raycast(targetOrigin.position, (spread * targetOrigin.right), 50, 1 << 8);
        if(hit.collider != null)
        {
            onEnemyHit.Raise(hit.collider.gameObject.GetInstanceID());
        }

    }

}
