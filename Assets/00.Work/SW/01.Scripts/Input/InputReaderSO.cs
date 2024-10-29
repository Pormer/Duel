using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static KeyAction;

[CreateAssetMenu(menuName = "SO/InputReader")]
public class InputReaderSO : ScriptableObject, IPlayerInputsActions, IPlayerComponents
{
    KeyAction keyAction;

    public event Action<Vector2Int> OnMoveLeftEvent;
    public event Action<Vector2Int> OnMoveRightEvent;
    public event Action OnLeftShootEvent;
    public event Action OnLeftSkillEvent;
    public event Action OnLeftBarrierPressEvent, OnLeftBarrierReleseEvent;
    
    public event Action OnRightShootEvent;
    public event Action OnRightSkillEvent;
    public event Action OnRightBarrierPressEvent, OnRightBarrierReleseEvent;

    public Vector2Int LeftMoveVec { get; private set; }
    public Vector2Int RightMoveVec { get; private set; }
    private void OnEnable()
    {
        keyAction = new KeyAction();
        keyAction.PlayerInputs.SetCallbacks(this);
        keyAction.PlayerInputs.Enable();
    }

    private void OnDisable()
    {
        keyAction.PlayerInputs.Disable();
    }

    //나중에 키바인딩 시 값에 따라 달라지게 적용하기 현재는 임시
    //바인딩 1번 : 발사, 2번 : 배리어, 3번 : 스킬 생각해서 짜기
    //바인딩 상: 1, 하 : 2, 좌 : 3, 우 : 4

    public void Initialize(Player player)
    {

    }

    public void OnLeftMovement(InputAction.CallbackContext context)
    {
        if (context.control.displayName == "W") LeftMoveVec = Vector2Int.up;
        if (context.control.displayName == "S") LeftMoveVec = Vector2Int.down;
        if (context.control.displayName == "A") LeftMoveVec = Vector2Int.left;
        if (context.control.displayName == "D") LeftMoveVec = Vector2Int.right;
        
        OnMoveLeftEvent?.Invoke(LeftMoveVec);
    }

    public void OnRIghtMovement(InputAction.CallbackContext context)
    {
        if (context.control.displayName == "Up") RightMoveVec = Vector2Int.up;
        if (context.control.displayName == "Down") RightMoveVec = Vector2Int.down;
        if (context.control.displayName == "Left") RightMoveVec = Vector2Int.left;
        if (context.control.displayName == "Right") RightMoveVec = Vector2Int.right;
        
        OnMoveRightEvent?.Invoke(RightMoveVec);
    }

    public void OnLeftPlayerEvent(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (context.control.displayName == "X") OnLeftShootEvent?.Invoke();
            if (context.control.displayName == "C") OnLeftBarrierPressEvent?.Invoke();
            if (context.control.displayName == "F") OnLeftSkillEvent?.Invoke();
        }

        if(context.canceled)
        {
            if (context.control.displayName == "C") OnLeftBarrierReleseEvent?.Invoke();
        }
    }

    public void OnRIghtPlayerEvent(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            if (context.control.displayName == "N") OnRightShootEvent?.Invoke();
            if (context.control.displayName == "M") OnRightBarrierPressEvent?.Invoke();
            if (context.control.displayName == "B") OnRightSkillEvent?.Invoke();
        }

        if(context.canceled)
        {
            if (context.control.displayName == "M") OnRightBarrierReleseEvent?.Invoke();
        }
    }
}
