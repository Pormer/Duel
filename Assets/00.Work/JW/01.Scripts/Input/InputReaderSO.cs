using System;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class InputReaderSO : ScriptableObject, IPlayerComponents
{
    protected KeyAction _keyAction;

    public bool IsRight { get; protected set; } = false;
    public Vector2Int MoveVec { get; protected set; }
    
    public Action OnShootEvent;
    public Action OnSkillEvent;
    public Action OnBarrierPressed;
    public Action OnBarrierReleased;
    public Action<Vector2Int> OnMovementEvent;

    protected virtual void OnEnable()
    {
        _keyAction = new KeyAction();
    }

    public void Initialize(Player player)
    {
        
    }
    
    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed) OnShootEvent?.Invoke();
    }

    public void OnSkill(InputAction.CallbackContext context)
    {
        if (context.performed) OnSkillEvent?.Invoke();
    }

    public void OnBarrier(InputAction.CallbackContext context)
    {
        if (context.performed) OnBarrierPressed?.Invoke();
        else if (context.canceled) OnBarrierReleased?.Invoke();
    }

    public void OnMovementUp(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        MoveVec = Vector2Int.up;
        OnMovementEvent?.Invoke(MoveVec);
    }

    public void OnMovementDown(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        MoveVec = Vector2Int.down;
        OnMovementEvent?.Invoke(MoveVec);
    }

    public void OnMovementLeft(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        MoveVec = Vector2Int.left;
        OnMovementEvent?.Invoke(MoveVec);
    }

    public void OnMovementRight(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        MoveVec = Vector2Int.right;
        OnMovementEvent?.Invoke(MoveVec);
    }
}
