using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class CollisionListener : MonoBehaviour
{
    public UnityEvent onGrounded;
    void OnCollisionEnter2D(Collision2D col)
    {
        onGrounded.Invoke();

    }
}
