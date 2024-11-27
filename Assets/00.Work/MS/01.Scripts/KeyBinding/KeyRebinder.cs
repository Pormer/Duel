using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class KeyRebinder
{
    public InputActionAsset inputActions; // Input Actions Asset 참조
    public string saveFileName = "rebinds.json"; // JSON 저장 파일 이름

    private string SavePath => Path.Combine(Application.persistentDataPath, saveFileName);

    private void Awake()
    {
        // 게임 시작 시 리바인딩 데이터를 로드
        LoadRebindings();
    }

    public string StartRebinding(KeyMapType actionMapType, KeyActionType actionType)
    {
        //Map 가져오기
        InputActionMap actionMap = inputActions.FindActionMap(actionMapType.ToString());
        if (actionMap == null)
        {
            Debug.LogError($"Action Map '{actionMapType.ToString()}' not found!");
            return"";
        }

        //Map에서 Action 가져오기
        InputAction action = actionMap.FindAction(actionType.ToString());
        if (action == null)
        {
            Debug.LogError($"Action '{actionType.ToString()}' not found in Action Map '{actionMapType.ToString()}'!");
            return "";
        }
        
        // 현재 사용 중인 모든 바인딩 가져오기
        var usedBindings = inputActions.actionMaps
            .SelectMany(a => a.bindings)
            .Where(b => !string.IsNullOrEmpty(b.effectivePath))
            .Select(b => b.effectivePath)
            .ToHashSet();

        // 특정 액션의 바인딩 리바인딩
        action.PerformInteractiveRebinding()
            .WithCancelingThrough("<Keyboard>/escape")
            .WithControlsExcluding("<Mouse>/leftButton")
            .WithControlsExcluding("<Mouse>/rightButton")
            .OnPotentialMatch(operation =>
                {
                    var selectedControl = operation.selectedControl.path;
                    if (usedBindings.Contains(selectedControl))
                    {
                        operation.Cancel(); // 중복일 경우 리바인딩 취소
                    }
                })
            .OnCancel(operation =>
            {
                operation.Dispose();
            })
            .OnComplete(operation =>
            {
                operation.Dispose(); // 리소스 정리

                //저장
                SaveRebindings();
            })
            .Start();
        return action.bindings[0].name;
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