using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Jumper : MonoBehaviour
{
    [SerializeField] private FloatVariable jumpHeight;
    [SerializeField] private FloatVariable jumpLimit;

    private bool isAirborne;
    private int jumpCount;
    private Rigidbody2D thisRigidbody;
    private Vector2 cachedJumpStats;

    void Awake()
    {
        thisRigidbody = this.GetComponent<Rigidbody2D>();
        jumpCount = 0;
        cachedJumpStats.y = jumpHeight.value;
    }

    public void Jump()
    {
        if (jumpCount < jumpLimit.value)
        {
            thisRigidbody.velocity = Vector2.zero;
            thisRigidbody.AddForce(cachedJumpStats, ForceMode2D.Impulse);
            jumpCount++;
        }
    }

    public void Land()
    {
        jumpCount = 0;
    }
}
