using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.Threading.Tasks;
using System.Linq;
using UnityEngine.UIElements;

public class MyRebindActionUI : MonoBehaviour
{
    [SerializeField]
    private InputActionReference currentAction = null;
    [SerializeField]
    private InputActionReference otherAction = null;
    [SerializeField]
    private TMP_Text bindingDisplayNameText = null;
    [SerializeField]
    private GameObject selectedMarkObject;
    [SerializeField]
    private InputBinding.DisplayStringOptions displayStringOptions;

    private InputActionRebindingExtensions.RebindingOperation rebindingOperation;
    private string path = null;

    public void StartRebinding()
    {
        currentAction.action.Disable();
        selectedMarkObject.SetActive(true);

        if (currentAction.action.bindings[0].hasOverrides)
            path = currentAction.action.bindings[0].overridePath;
        else
            path = currentAction.action.bindings[0].path;

        rebindingOperation = currentAction.action.PerformInteractiveRebinding()
            .WithControlsExcluding("<Mouse>/rightButton")
            .WithCancelingThrough("<Mouse>/leftButton")
            .OnCancel(operation => RebindCancel())
            .OnComplete(operation => RebindComplete())
            .Start();
    }

    private void RebindCancel()
    {
        rebindingOperation.Dispose();
        currentAction.action.Enable();
        selectedMarkObject.SetActive(false);
    }

    private void RebindComplete()
    {
        selectedMarkObject.SetActive(false);
        rebindingOperation.Dispose();
        currentAction.action.Enable();

        if (CheckDuplicateBindings(currentAction.action))
        {
            if (path != null)
                currentAction.action.ApplyBindingOverride(path);
            return;
        }

        ShowBindText();
    }

    public void ShowBindText()
    {
        var displayString = string.Empty;
        var deviceLayoutName = default(string);
        var controlPath = default(string);

        displayString = currentAction.action.GetBindingDisplayString(0, out deviceLayoutName, out controlPath, displayStringOptions);

        if(controlPath == "<Keyboard>/escape")
        {

        }

        bindingDisplayNameText.text = displayString;
    }

    private bool CheckDuplicateBindings(InputAction action)
    {
        InputBinding newBinding = action.bindings[0];

        var otherBinding = otherAction.action.actionMap.bindings.First(x => x.action == newBinding.action);
        if ( otherBinding.effectivePath == newBinding.effectivePath)
        {
            Debug.Log("Duplicate binding found : " + newBinding.effectivePath);
            return true;
        }
        foreach (InputBinding binding in action.actionMap.bindings)
        {
            if (binding.action == newBinding.action)
                continue;
             otherBinding = otherAction.action.actionMap.bindings.First(x => x.action == binding.action);
            if (binding.effectivePath == newBinding.effectivePath || otherBinding.effectivePath == newBinding.effectivePath)
            {
                Debug.Log("Duplicate binding found : " + newBinding.effectivePath);
                return true;
            }
        }
        return false;
    }
}