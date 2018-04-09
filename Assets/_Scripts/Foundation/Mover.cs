using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    [SerializeField] private FloatVariable xSpeed;
    [SerializeField] private FloatVariable ySpeed;

    private Rigidbody2D thisRigidbody;
    private Vector2 currentMovement;

    void Awake()
    {
        thisRigidbody = this.GetComponent<Rigidbody2D>();
    }

    public void MoveHorizontal(float inputValue)
    {
        currentMovement.x = xSpeed.value * inputValue;
        currentMovement.y = thisRigidbody.velocity.y;
        thisRigidbody.velocity = currentMovement;
    }

}
