using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static KeyAction;

[CreateAssetMenu(menuName = "SO/InputReader")]
public class InputReaderSO : ScriptableObject, IPlayerInputActions
{
    KeyAction keyAction;

    public event Action OnLeftShootEvent;
    public event Action OnLeftSkillEvent;
    public event Action OnLeftBarrierPressEvent, OnLeftBarrierReleseEvent;

    public event Action OnRightShootEvent;
    public event Action OnRightSkillEvent;
    public event Action OnRightBarrierPressEvent, OnRightBarrierReleseEvent;

    public bool IsLeftBarrierState {  get; private set; }
    public bool IsRightBarrierState {  get; private set; }

    public Vector2 LeftMoveVec { get; private set; }
    public Vector2 RightMoveVec { get; private set; }
    private void OnEnable()
    {
        keyAction = new KeyAction();
        keyAction.PlayerInput.SetCallbacks(this);
        keyAction.PlayerInput.Enable();
    }

    public void OnLeftPlayerMove(InputAction.CallbackContext context)
    {
        if (context.performed)
            LeftMoveVec = context.ReadValue<Vector2>();
    }


    public void OnLeftPlayerShoot(InputAction.CallbackContext context)
    {
        OnLeftShootEvent?.Invoke();
    }

    public void OnLeftPlayerBarrier(InputAction.CallbackContext context)
    {
        if (context.performed) OnLeftBarrierPressEvent?.Invoke();
        if (context.canceled) OnLeftBarrierReleseEvent?.Invoke();
    }

    public void OnLeftPlayerSkill(InputAction.CallbackContext context)
    {
        OnLeftSkillEvent?.Invoke();
    }

    public void OnRightPlayerMove(InputAction.CallbackContext context)
    {
        if (context.performed)
            RightMoveVec = context.ReadValue<Vector2>();
    }

    public void OnRightPlayerShoot(InputAction.CallbackContext context)
    {
        OnRightShootEvent?.Invoke();
    }

    public void OnRightPlayerBarrier(InputAction.CallbackContext context)
    {
        if (context.performed) OnRightBarrierPressEvent?.Invoke();
        if (context.canceled) OnRightBarrierReleseEvent?.Invoke();
    }

    public void OnRightPlayerSkill(InputAction.CallbackContext context)
    {
        OnRightSkillEvent?.Invoke();
    }
}
