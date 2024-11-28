using System;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class KeyRebinder : MonoBehaviour
{
    private keyBindUI _keyBind;
    [SerializeField] private InputActionAsset inputActions;
    private readonly string _saveFileName = "rebinds.json"; //파일 이름

    [SerializeField] private InputReaderSO _inputL;
    [SerializeField] private InputReaderSO _inputR;

    private string SavePath => Path.Combine(Application.persistentDataPath, _saveFileName);

    private void Awake()
    {
        LoadRebindings();
        if (FindAnyObjectByType<keyBindUI>() != null) _keyBind = FindAnyObjectByType<keyBindUI>();
    }

    public void StartRebinding(KeyMapType actionMapType, KeyActionType actionType, Button btn)
    {
        //Map 가져오기
        _keyBind.IsBing(true);
        InputActionMap actionMap = inputActions.FindActionMap(actionMapType.ToString());
        if (actionMap == null)
        {
            Debug.LogError($"Action Map '{actionMapType.ToString()}' not found!");
            _keyBind.IsBing(false);
            return;
        }

        actionMap.Disable();

        //Map에서 Action 가져오기
        InputAction action = actionMap.FindAction(actionType.ToString());
        if (action == null)
        {
            Debug.LogError($"Action '{actionType.ToString()}' not found in Action Map '{actionMapType.ToString()}'!");
            _keyBind.IsBing(false); 
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
                string controlPath = ctx.selectedControl.displayName;

                if (IsBindingDuplicate(inputActions, controlPath))
                {
                    Debug.Log($"Duplicate key detected: {controlPath}");
                    ctx.Cancel(); // 리바인딩 취소
                    _keyBind.IsBing(false);
                }
                else
                {
                    Debug.Log($"Valid input: {controlPath}");
                    _keyBind.IsBing(false);
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
                btn.text = TextControl(action.bindings[0].ToDisplayString());
                //저장
                SaveRebindings();
                action.Enable();
                _keyBind.IsBing(false);
            })
            .Start();
        
    }

    private string TextControl(string text)
    {
        if (text == "Up Arrow") return "↑";
        else if (text == "Down Arrow") return "↓";
        else if (text == "Right Arrow") return "→";
        else if (text == "Left Arrow") return "←";

        return text;
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
            inputActions.Disable();
            inputActions.LoadBindingOverridesFromJson(rebinds);
            
            _inputL.KeyReBinding(rebinds);
            _inputR.KeyReBinding(rebinds);
            
            // 입력 시스템 재활성화
            inputActions.Enable();
            InputSystem.Update();
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
        foreach (var actionMap in asset.actionMaps)
        {
            foreach (var action in actionMap.actions)
            {
                foreach (var binding in action.bindings)
                {
                    if (binding.ToDisplayString() == path)
                    {
                        print(binding.ToDisplayString());
                        return true;
                    }
                }
            }
        }
        return false;
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