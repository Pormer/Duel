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

    public Action<Vector2Int> OnMoveLeftEvent;
    public Action<Vector2Int> OnMoveRightEvent;
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
    
    //바인딩 1번 : 발사, 2번 : 배리어, 3번 : 스킬 생각해서 짜기
    //바인딩 상: 1, 하 : 2, 좌 : 3, 우 : 4

    public void Initialize(Player player)
    {

    }

    public void OnLeftMovement(InputAction.CallbackContext context)
    {
        if (context.duration == 1) LeftMoveVec = Vector2Int.up;
        if (context.duration == 2) LeftMoveVec = Vector2Int.down;
        if (context.duration == 3) LeftMoveVec = Vector2Int.left;
        if (context.duration == 4) LeftMoveVec = Vector2Int.right;
        
        OnMoveLeftEvent?.Invoke(LeftMoveVec);
    }

    public void OnRIghtMovement(InputAction.CallbackContext context)
    {
        if (context.duration == 1) RightMoveVec = Vector2Int.up;
        if (context.duration == 2) RightMoveVec = Vector2Int.down;
        if (context.duration == 3) RightMoveVec = Vector2Int.left;
        if (context.duration == 4) RightMoveVec = Vector2Int.right;
        
        OnMoveRightEvent?.Invoke(RightMoveVec);
    }

    public void OnLeftPlayerEvent(InputAction.CallbackContext context)
    {
        if (context.duration == 1) OnLeftShootEvent?.Invoke();
        if (context.duration == 2) OnLeftBarrierPressEvent?.Invoke();
        if (context.duration == 3) OnLeftSkillEvent?.Invoke();
    }

    public void OnRIghtPlayerEvent(InputAction.CallbackContext context)
    {
        if (context.duration == 1) OnRightShootEvent?.Invoke();
        if (context.duration == 2) OnRightBarrierPressEvent?.Invoke();
        if (context.duration == 3) OnRightSkillEvent?.Invoke();
    }
}
