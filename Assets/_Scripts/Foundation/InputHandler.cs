using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputHandler : MonoBehaviour
{
    public FloatEvent OnHorizontalAxisChange;
    public UnityEvent OnJumpInput;
    public UnityEvent OnLeftClicked;
    public UnityEvent OnRightClicked;
    public UnityEvent OnEPressed;
    public UnityEvent OnShiftPressed;
    public UnityEvent OnReload;
    public UnityEvent OnUltimatePressed;

    private bool move;
    private bool jump;
    private bool lClick;
    private bool rClick;
    private bool eCommand;
    private bool shiftCommand;
    private bool ultimate;
    private bool reload;
    private const string H_AxisName = "Horizontal";

    void Update()
    {
        if(!jump)
        {
            jump = Input.GetKeyDown(KeyCode.Space);
        }
        if(!lClick)
        {
            lClick = Input.GetMouseButton(0);
        }
        if(!rClick)
        {
            rClick = Input.GetMouseButtonDown(1);
        }
        if(!eCommand)
        {
            eCommand = Input.GetKeyDown(KeyCode.E);
        }
        if(!shiftCommand)
        {
            shiftCommand = Input.GetKeyDown(KeyCode.LeftShift);
        }
        if(!reload)
        {
            reload = Input.GetKeyDown(KeyCode.R);
        }
        if(!ultimate)
        {
            ultimate = Input.GetKeyDown(KeyCode.Q);
        }
    }

    void FixedUpdate()
    {
        float hAxis = Input.GetAxis(H_AxisName);
        if(hAxis != 0)
        {
            OnHorizontalAxisChange.Invoke(hAxis);
        }
        if(jump)
        {
            OnJumpInput.Invoke();
            jump = false;
        }
        if (rClick)
        {
            OnRightClicked.Invoke();
            rClick = false;
        }
        if (lClick)
        {
            OnLeftClicked.Invoke();
            lClick = false;
        }
        if (eCommand)
        {
            OnEPressed.Invoke();
            eCommand = false;
        }
        if(shiftCommand)
        {
            OnShiftPressed.Invoke();
            shiftCommand = false;
        }
        if (reload)
        {
            OnReload.Invoke();
            reload = false;
        }
        if(ultimate)
        {
            OnUltimatePressed.Invoke();
            ultimate = false;
        }
    }
}
