using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static KeyAction;

[CreateAssetMenu(menuName = "SO/Input")]
public class InputReaderSO : ScriptableObject, IRightInputActions, ILeftInputActions, IPlayerComponents
{
    protected KeyAction keyAction;
    
    [field: SerializeField] public bool IsRight { get; private set; }
    
    public event Action<Vector2Int> OnMoveEvent;
    public event Action OnSkillEvent;
    public event Action OnShootEvent;
    public event Action OnBarrierPressEvent;
    public event Action OnBarrierReleseEvent;
    public Vector2Int MoveVec { get; protected set; }

    private string[] rightMoveKeys;
    private string[] leftMoveKeys;
    private string[] rightEventKeys;
    private string[] leftEventKeys;
    
    
    private void OnEnable()
    {
        keyAction = new KeyAction();

        if (IsRight)
        {
            keyAction.RightInput.SetCallbacks(this);
            keyAction.RightInput.Enable();
            
            rightMoveKeys = new string[keyAction.RightInput.Movement.bindings.Count];
            rightEventKeys = new string[keyAction.RightInput.PlayerEvent.bindings.Count];
            
            for (int i = 0; i < rightMoveKeys.Length; i++)
            {
                rightMoveKeys[i] = keyAction.RightInput.Movement.bindings[i].path.Replace("<Keyboard>/", "");
            }
            
            for (int i = 0; i < rightEventKeys.Length; i++)
            {
                rightEventKeys[i] = keyAction.RightInput.PlayerEvent.bindings[i].path.Replace("<Keyboard>/", "");
            }
        }
        else
        {
            keyAction.LeftInput.SetCallbacks(this);
            keyAction.LeftInput.Enable();
            
            leftMoveKeys = new string[keyAction.LeftInput.Movement.bindings.Count];
            leftEventKeys = new string[keyAction.LeftInput.PlayerEvent.bindings.Count];
            
            for (int i = 0; i < leftMoveKeys.Length; i++)
            {
                leftMoveKeys[i] = keyAction.LeftInput.Movement.bindings[i].path.Replace("<Keyboard>/", "");
            }
            
            for (int i = 0; i < leftEventKeys.Length; i++)
            {
                leftEventKeys[i] = keyAction.LeftInput.PlayerEvent.bindings[i].path.Replace("<Keyboard>/", "");
            }
        }
    }

    private void OnDisable()
    {
        keyAction.RightInput.Disable();
        keyAction.LeftInput.Disable();
    }

    //나중에 키바인딩 시 값에 따라 달라지게 적용하기 현재는 임시
    //바인딩 1번 : 발사, 2번 : 배리어, 3번 : 스킬 생각해서 짜기
    //바인딩 상: 1, 하 : 2, 좌 : 3, 우 : 4

    public void Initialize(Player player)
    {
        
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        if(!context.performed) return;
        
        if (IsRight)
        {
            if (rightMoveKeys[0] == context.control.name) MoveVec = Vector2Int.up;
            else if (rightMoveKeys[1] == context.control.name) MoveVec = Vector2Int.down;
            else if (rightMoveKeys[2] == context.control.name) MoveVec = Vector2Int.left;
            else if (rightMoveKeys[3] == context.control.name) MoveVec = Vector2Int.right;
            else MoveVec = Vector2Int.zero;
            
            OnMoveEvent?.Invoke(MoveVec);
        }
        else
        {
            if (leftMoveKeys[0] == context.control.name) MoveVec = Vector2Int.up;
            else if (leftMoveKeys[1] == context.control.name) MoveVec = Vector2Int.down;
            else if (leftMoveKeys[2] == context.control.name) MoveVec = Vector2Int.left;
            else if (leftMoveKeys[3] == context.control.name) MoveVec = Vector2Int.right;
            else MoveVec = Vector2Int.zero;
            
            OnMoveEvent?.Invoke(MoveVec);
        }
    }

    public void OnPlayerEvent(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (IsRight)
            {
                if (rightEventKeys[0] == context.control.name) OnShootEvent?.Invoke();
                if (rightEventKeys[1] == context.control.name) OnBarrierPressEvent?.Invoke();
                if (rightEventKeys[2] == context.control.name) OnSkillEvent?.Invoke();
            }
            else
            {
                if (leftEventKeys[0] == context.control.name) OnShootEvent?.Invoke();
                if (leftEventKeys[1] == context.control.name) OnBarrierPressEvent?.Invoke();
                if (leftEventKeys[2] == context.control.name) OnSkillEvent?.Invoke();
            }
        }

        if(context.canceled)
        {
            if (IsRight)
            {
                if (context.control.displayName == "C") OnBarrierReleseEvent?.Invoke();
            }
            else
            {
                if (context.control.displayName == "M") OnBarrierReleseEvent?.Invoke();
            }
        }
    }
}
