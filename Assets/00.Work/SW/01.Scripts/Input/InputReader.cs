using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static KeyAction;

public class InputReader : MonoBehaviour, IPlayerInputActions
{
    KeyAction keyAction;

    public bool isLeftPlayer;
    Vector2 leftMoveVec;
    Vector2 rightMoveVec;
    public Vector2 MoveVec
    {
        get
        {
            if (isLeftPlayer)
            {
                return leftMoveVec;
            }
            else
            {
                return rightMoveVec;
            }
        }
        set
        {

        }
    }

    private void OnEnable()
    {
        keyAction = new KeyAction();
        keyAction.PlayerInput.SetCallbacks(this);
        keyAction.PlayerInput.Enable();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        if(context.duration == 1)
        {
            isLeftPlayer = true;

        }


    }
}
