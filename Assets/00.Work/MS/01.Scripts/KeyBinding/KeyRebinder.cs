using System;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class KeyRebinder : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputActions;
    private readonly string _saveFileName = "rebinds.json"; //파일 이름

    private string SavePath => Path.Combine(Application.persistentDataPath, _saveFileName);

    private void Awake()
    {
        LoadRebindings();
    }

    public void StartRebinding(KeyMapType actionMapType, KeyActionType actionType, Button btn)
    {
        //Map 가져오기
        InputActionMap actionMap = inputActions.FindActionMap(actionMapType.ToString());
        if (actionMap == null)
        {
            Debug.LogError($"Action Map '{actionMapType.ToString()}' not found!");
            return;
        }

        actionMap.Disable();

        //Map에서 Action 가져오기
        InputAction action = actionMap.FindAction(actionType.ToString());
        if (action == null)
        {
            Debug.LogError($"Action '{actionType.ToString()}' not found in Action Map '{actionMapType.ToString()}'!");
            return;
        }

        var usedBindings = inputActions.actionMaps
            .SelectMany(a => a.bindings)
            .Where(b => !string.IsNullOrEmpty(b.effectivePath))
            .Select(b => b.effectivePath)
            .ToHashSet();

        action.Disable();
        action.PerformInteractiveRebinding()
            .OnMatchWaitForAnother(0.1f)
            .OnPotentialMatch(ctx =>
            {
                string controlPath = ctx.selectedControl.path;

                if (IsBindingDuplicate(inputActions, controlPath))
                {
                    Debug.Log($"Duplicate key detected: {controlPath}");
                    ctx.Cancel(); // 리바인딩 취소
                }
                else
                {
                    Debug.Log($"Valid input: {controlPath}");
                }
            })
            .WithCancelingThrough("<Keyboard>/escape")
            .WithControlsExcluding("<Mouse>/leftButton")
            .WithControlsExcluding("<Mouse>/rightButton")
            .WithControlsExcluding("<Mouse>/press")
            .OnCancel(operation => { operation.Dispose(); })
            .OnComplete(operation =>
            {
                operation.Dispose(); // 리소스 정리

                print("Complete");
                btn.text = action.bindings[0].ToDisplayString();
                //저장
                SaveRebindings();
                action.Enable();
            })
            .Start();
    }

    public string LoadKeyName(KeyMapType actionMapType, KeyActionType actionType)
    {
        InputActionMap actionMap = inputActions.FindActionMap(actionMapType.ToString());
        if (actionMap == null)
        {
            Debug.LogError($"Action Map '{actionMapType.ToString()}' not found!");
            return "";
        }

        actionMap.Disable();

        //Map에서 Action 가져오기
        InputAction action = actionMap.FindAction(actionType.ToString());
        if (action == null)
        {
            Debug.LogError($"Action '{actionType.ToString()}' not found in Action Map '{actionMapType.ToString()}'!");
            return "";
        }

        actionMap.Enable();
        return action.bindings[0].ToDisplayString();
    }

    public void SaveRebindings()
    {
        //JSON으로 저장
        string rebinds = inputActions.SaveBindingOverridesAsJson();
        File.WriteAllText(SavePath, rebinds);
        Debug.Log($"Rebindings saved to {SavePath}");
    }

    public void LoadRebindings()
    {
        // JSON 파일이 존재하면 데이터를 로드
        if (File.Exists(SavePath))
        {
            string rebinds = File.ReadAllText(SavePath);
            inputActions.LoadBindingOverridesFromJson(rebinds);
            Debug.Log("Rebindings load");
        }
        else
        {
            Debug.Log("No rebindings file found. Using default bindings.");
        }
    }

    public void ResetRebindings()
    {
        //초기화
        inputActions.RemoveAllBindingOverrides();
        SaveRebindings(); //저장
        Debug.Log("Rebindings reset to default.");
    }
    
    bool IsBindingDuplicate(InputActionAsset asset, string path)
    {
        if (asset == null)
        {
            Debug.LogError("InputActionAsset is null.");
            return false;
        }

        foreach (var actionMap in asset.actionMaps)
        {
            foreach (var action in actionMap.actions)
            {
                foreach (var binding in action.bindings)
                {
                    if (binding.path == path)
                    {
                        return true; // Path is already used
                    }
                }
            }
        }
        return false; // No duplicates found
    }
}

public enum KeyMapType
{
    LeftInput,
    RightInput
}

public enum KeyActionType
{
    Shoot,
    Skill,
    Barrier,
    MovementUp,
    MovementDown,
    MovementLeft,
    MovementRight,
}