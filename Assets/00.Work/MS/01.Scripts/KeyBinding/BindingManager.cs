using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RebindInputSystem : MonoBehaviour
{
    public InputActionAsset actions;

    [SerializeField]
    private List<MyRebindActionUI> _myRebindActionUIs = new List<MyRebindActionUI>();

    public void OnEnable()
    {
        var rebinds = PlayerPrefs.GetString("rebinds");
        if (!string.IsNullOrEmpty(rebinds))
            actions.LoadBindingOverridesFromJson(rebinds);

        foreach (MyRebindActionUI myRebindActionUI in _myRebindActionUIs)
            myRebindActionUI.ShowBindText();
    }

    public void OnDisable()
    {
        var rebinds = actions.SaveBindingOverridesAsJson();
        PlayerPrefs.SetString("rebinds", rebinds);
    }

    public void resetAllBindings()
    {
        foreach (InputActionMap map in actions.actionMaps)
            map.RemoveAllBindingOverrides();

        foreach (MyRebindActionUI myRebindActionUI in _myRebindActionUIs)
            myRebindActionUI.ShowBindText();

        PlayerPrefs.DeleteKey("rebinds");
    }
}