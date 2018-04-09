using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Timers;

[RequireComponent(typeof(Rigidbody2D))]
public class TracerRecall : MonoBehaviour {
    [SerializeField] private FloatVariable recallDuration;
    [SerializeField] private FloatVariable recallCooldown;
    [SerializeField] private GameEvent onRecallStart;
    [SerializeField] private GameEvent onRecallFinished;

    private Transform cachedTransform;
    private Rigidbody2D cachedRigidbody;
    private bool onCooldown = false;

    private const int SAVE_CAP = 60;

    //position only will add more stats upon health and damage implementation
    private List<Vector2> recallHistory = new List<Vector2>();
    private bool didRecall = false;
    private Vector2 cachedRecallState = new Vector2();

    void Awake()
    {
        cachedTransform = this.transform;
        cachedRigidbody = this.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if(didRecall)
        {
            didRecall = false;
            cachedRigidbody.position = cachedRecallState;
            onRecallFinished.Raise();
        }
    }

	void LateUpdate ()
    {
        recallHistory.Add(cachedTransform.position);
        if(recallHistory.Count > SAVE_CAP)
        {
            recallHistory.RemoveAt(0);
        }
	}

    public void Recall()
    {
        if (onCooldown)
            return;
        onCooldown = true;
        cachedRecallState = recallHistory[0];
        onRecallStart.Raise();
        TimersManager.SetTimer(this, recallDuration.value, FinishRecall);
    }

    private void FinishRecall()
    {
        didRecall = true;
        TimersManager.SetTimer(this, recallCooldown.value, ReEnableRecall);
    }

    private void ReEnableRecall()
    {
        onCooldown = false;
    }


}
