//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.11.2
//     from Assets/00.Work/SW/06.Input/KeyAction.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @KeyAction: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @KeyAction()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""KeyAction"",
    ""maps"": [
        {
            ""name"": ""LeftInput"",
            ""id"": ""829c998b-dbb6-4b34-a656-6b6d29e886f0"",
            ""actions"": [
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""1b8ea5cc-08aa-4382-8aee-c0dd8212e755"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Skill"",
                    ""type"": ""Button"",
                    ""id"": ""faf8c6f5-47e7-4ef0-93ba-1ff3f77e5a37"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Barrier"",
                    ""type"": ""Button"",
                    ""id"": ""35ce1608-6c44-451a-9de9-b32102df0667"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MovementUp"",
                    ""type"": ""Button"",
                    ""id"": ""45c66c38-001c-4a0c-83cc-061d1a2f88c4"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MovementDown"",
                    ""type"": ""Button"",
                    ""id"": ""3d12cb8c-3323-4c2c-8ad9-b8861bc4b231"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MovementLeft"",
                    ""type"": ""Button"",
                    ""id"": ""51a02ede-0d13-43cc-af44-8491a1cc3efc"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MovementRight"",
                    ""type"": ""Button"",
                    ""id"": ""00b71c4f-b44f-4c38-a4ac-c16811ae9232"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""596e29f9-779c-472b-9ca8-4be68419045d"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5a8ecfb8-e2f5-4314-b1f8-73b247aee2e1"",
                    ""path"": ""<Keyboard>/b"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skill"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""79a354f8-002f-48b2-a46c-72f67e77f958"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Barrier"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a7ef4573-4f7b-42a5-9cfe-934f4c350ed8"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c48b2fe8-0b6c-4f64-82ad-da11f262d1b6"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1f0225e5-2585-49b8-b83e-88ac4313eecf"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1d63d1af-cf75-4c8b-b39c-33c22e78461c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""RightInput"",
            ""id"": ""f638eb7a-4cee-460c-a8f3-a857c8b8fdcf"",
            ""actions"": [
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""183aadcb-cf07-477d-bf28-9e2641798d38"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Skill"",
                    ""type"": ""Button"",
                    ""id"": ""5aee796a-ddf6-455c-9885-5c45d285de12"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Barrier"",
                    ""type"": ""Button"",
                    ""id"": ""c8392333-1e0c-4abe-94cf-1d7d4a7fe416"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MovementUp"",
                    ""type"": ""Button"",
                    ""id"": ""4137e653-1ffe-4a70-99a3-b94037f306ab"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MovementDown"",
                    ""type"": ""Button"",
                    ""id"": ""0ccc1f69-ae50-4a97-9109-c596d1b260b8"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MovementLeft"",
                    ""type"": ""Button"",
                    ""id"": ""e276c723-e356-4f72-a316-ac8039f159c9"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MovementRight"",
                    ""type"": ""Button"",
                    ""id"": ""0f9f53d8-93bd-47d1-8071-bb7438d6b2bb"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0e1e4374-eab8-4f19-b001-1ed8c1d62091"",
                    ""path"": ""<Keyboard>/semicolon"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""92d2a8f9-fecf-4306-8806-644f5d919a33"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skill"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""20a8ba2c-8700-4da8-b097-f5f598872d34"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Barrier"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""18a2b31f-aa3c-4a3d-9d2d-2ac90195aa68"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f1071ead-73ab-45e5-996e-25ce9331e8e3"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e28a10a3-8798-41cd-9983-ba7bc934d3aa"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8ce2d91a-4353-423c-967b-76a27a28d00d"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""ec2a478a-86bd-41a9-9791-f3364cbcf69b"",
            ""actions"": [
                {
                    ""name"": ""Setting"",
                    ""type"": ""Button"",
                    ""id"": ""6064279c-a3fe-4d39-8850-fbac3a311373"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""440bc4f3-c6e0-4ba7-b6a4-8d68350b269a"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Setting"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Mouse"",
            ""bindingGroup"": ""Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // LeftInput
        m_LeftInput = asset.FindActionMap("LeftInput", throwIfNotFound: true);
        m_LeftInput_Shoot = m_LeftInput.FindAction("Shoot", throwIfNotFound: true);
        m_LeftInput_Skill = m_LeftInput.FindAction("Skill", throwIfNotFound: true);
        m_LeftInput_Barrier = m_LeftInput.FindAction("Barrier", throwIfNotFound: true);
        m_LeftInput_MovementUp = m_LeftInput.FindAction("MovementUp", throwIfNotFound: true);
        m_LeftInput_MovementDown = m_LeftInput.FindAction("MovementDown", throwIfNotFound: true);
        m_LeftInput_MovementLeft = m_LeftInput.FindAction("MovementLeft", throwIfNotFound: true);
        m_LeftInput_MovementRight = m_LeftInput.FindAction("MovementRight", throwIfNotFound: true);
        // RightInput
        m_RightInput = asset.FindActionMap("RightInput", throwIfNotFound: true);
        m_RightInput_Shoot = m_RightInput.FindAction("Shoot", throwIfNotFound: true);
        m_RightInput_Skill = m_RightInput.FindAction("Skill", throwIfNotFound: true);
        m_RightInput_Barrier = m_RightInput.FindAction("Barrier", throwIfNotFound: true);
        m_RightInput_MovementUp = m_RightInput.FindAction("MovementUp", throwIfNotFound: true);
        m_RightInput_MovementDown = m_RightInput.FindAction("MovementDown", throwIfNotFound: true);
        m_RightInput_MovementLeft = m_RightInput.FindAction("MovementLeft", throwIfNotFound: true);
        m_RightInput_MovementRight = m_RightInput.FindAction("MovementRight", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Setting = m_UI.FindAction("Setting", throwIfNotFound: true);
    }

    ~@KeyAction()
    {
        UnityEngine.Debug.Assert(!m_LeftInput.enabled, "This will cause a leak and performance issues, KeyAction.LeftInput.Disable() has not been called.");
        UnityEngine.Debug.Assert(!m_RightInput.enabled, "This will cause a leak and performance issues, KeyAction.RightInput.Disable() has not been called.");
        UnityEngine.Debug.Assert(!m_UI.enabled, "This will cause a leak and performance issues, KeyAction.UI.Disable() has not been called.");
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // LeftInput
    private readonly InputActionMap m_LeftInput;
    private List<ILeftInputActions> m_LeftInputActionsCallbackInterfaces = new List<ILeftInputActions>();
    private readonly InputAction m_LeftInput_Shoot;
    private readonly InputAction m_LeftInput_Skill;
    private readonly InputAction m_LeftInput_Barrier;
    private readonly InputAction m_LeftInput_MovementUp;
    private readonly InputAction m_LeftInput_MovementDown;
    private readonly InputAction m_LeftInput_MovementLeft;
    private readonly InputAction m_LeftInput_MovementRight;
    public struct LeftInputActions
    {
        private @KeyAction m_Wrapper;
        public LeftInputActions(@KeyAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @Shoot => m_Wrapper.m_LeftInput_Shoot;
        public InputAction @Skill => m_Wrapper.m_LeftInput_Skill;
        public InputAction @Barrier => m_Wrapper.m_LeftInput_Barrier;
        public InputAction @MovementUp => m_Wrapper.m_LeftInput_MovementUp;
        public InputAction @MovementDown => m_Wrapper.m_LeftInput_MovementDown;
        public InputAction @MovementLeft => m_Wrapper.m_LeftInput_MovementLeft;
        public InputAction @MovementRight => m_Wrapper.m_LeftInput_MovementRight;
        public InputActionMap Get() { return m_Wrapper.m_LeftInput; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(LeftInputActions set) { return set.Get(); }
        public void AddCallbacks(ILeftInputActions instance)
        {
            if (instance == null || m_Wrapper.m_LeftInputActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_LeftInputActionsCallbackInterfaces.Add(instance);
            @Shoot.started += instance.OnShoot;
            @Shoot.performed += instance.OnShoot;
            @Shoot.canceled += instance.OnShoot;
            @Skill.started += instance.OnSkill;
            @Skill.performed += instance.OnSkill;
            @Skill.canceled += instance.OnSkill;
            @Barrier.started += instance.OnBarrier;
            @Barrier.performed += instance.OnBarrier;
            @Barrier.canceled += instance.OnBarrier;
            @MovementUp.started += instance.OnMovementUp;
            @MovementUp.performed += instance.OnMovementUp;
            @MovementUp.canceled += instance.OnMovementUp;
            @MovementDown.started += instance.OnMovementDown;
            @MovementDown.performed += instance.OnMovementDown;
            @MovementDown.canceled += instance.OnMovementDown;
            @MovementLeft.started += instance.OnMovementLeft;
            @MovementLeft.performed += instance.OnMovementLeft;
            @MovementLeft.canceled += instance.OnMovementLeft;
            @MovementRight.started += instance.OnMovementRight;
            @MovementRight.performed += instance.OnMovementRight;
            @MovementRight.canceled += instance.OnMovementRight;
        }

        private void UnregisterCallbacks(ILeftInputActions instance)
        {
            @Shoot.started -= instance.OnShoot;
            @Shoot.performed -= instance.OnShoot;
            @Shoot.canceled -= instance.OnShoot;
            @Skill.started -= instance.OnSkill;
            @Skill.performed -= instance.OnSkill;
            @Skill.canceled -= instance.OnSkill;
            @Barrier.started -= instance.OnBarrier;
            @Barrier.performed -= instance.OnBarrier;
            @Barrier.canceled -= instance.OnBarrier;
            @MovementUp.started -= instance.OnMovementUp;
            @MovementUp.performed -= instance.OnMovementUp;
            @MovementUp.canceled -= instance.OnMovementUp;
            @MovementDown.started -= instance.OnMovementDown;
            @MovementDown.performed -= instance.OnMovementDown;
            @MovementDown.canceled -= instance.OnMovementDown;
            @MovementLeft.started -= instance.OnMovementLeft;
            @MovementLeft.performed -= instance.OnMovementLeft;
            @MovementLeft.canceled -= instance.OnMovementLeft;
            @MovementRight.started -= instance.OnMovementRight;
            @MovementRight.performed -= instance.OnMovementRight;
            @MovementRight.canceled -= instance.OnMovementRight;
        }

        public void RemoveCallbacks(ILeftInputActions instance)
        {
            if (m_Wrapper.m_LeftInputActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ILeftInputActions instance)
        {
            foreach (var item in m_Wrapper.m_LeftInputActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_LeftInputActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public LeftInputActions @LeftInput => new LeftInputActions(this);

    // RightInput
    private readonly InputActionMap m_RightInput;
    private List<IRightInputActions> m_RightInputActionsCallbackInterfaces = new List<IRightInputActions>();
    private readonly InputAction m_RightInput_Shoot;
    private readonly InputAction m_RightInput_Skill;
    private readonly InputAction m_RightInput_Barrier;
    private readonly InputAction m_RightInput_MovementUp;
    private readonly InputAction m_RightInput_MovementDown;
    private readonly InputAction m_RightInput_MovementLeft;
    private readonly InputAction m_RightInput_MovementRight;
    public struct RightInputActions
    {
        private @KeyAction m_Wrapper;
        public RightInputActions(@KeyAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @Shoot => m_Wrapper.m_RightInput_Shoot;
        public InputAction @Skill => m_Wrapper.m_RightInput_Skill;
        public InputAction @Barrier => m_Wrapper.m_RightInput_Barrier;
        public InputAction @MovementUp => m_Wrapper.m_RightInput_MovementUp;
        public InputAction @MovementDown => m_Wrapper.m_RightInput_MovementDown;
        public InputAction @MovementLeft => m_Wrapper.m_RightInput_MovementLeft;
        public InputAction @MovementRight => m_Wrapper.m_RightInput_MovementRight;
        public InputActionMap Get() { return m_Wrapper.m_RightInput; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(RightInputActions set) { return set.Get(); }
        public void AddCallbacks(IRightInputActions instance)
        {
            if (instance == null || m_Wrapper.m_RightInputActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_RightInputActionsCallbackInterfaces.Add(instance);
            @Shoot.started += instance.OnShoot;
            @Shoot.performed += instance.OnShoot;
            @Shoot.canceled += instance.OnShoot;
            @Skill.started += instance.OnSkill;
            @Skill.performed += instance.OnSkill;
            @Skill.canceled += instance.OnSkill;
            @Barrier.started += instance.OnBarrier;
            @Barrier.performed += instance.OnBarrier;
            @Barrier.canceled += instance.OnBarrier;
            @MovementUp.started += instance.OnMovementUp;
            @MovementUp.performed += instance.OnMovementUp;
            @MovementUp.canceled += instance.OnMovementUp;
            @MovementDown.started += instance.OnMovementDown;
            @MovementDown.performed += instance.OnMovementDown;
            @MovementDown.canceled += instance.OnMovementDown;
            @MovementLeft.started += instance.OnMovementLeft;
            @MovementLeft.performed += instance.OnMovementLeft;
            @MovementLeft.canceled += instance.OnMovementLeft;
            @MovementRight.started += instance.OnMovementRight;
            @MovementRight.performed += instance.OnMovementRight;
            @MovementRight.canceled += instance.OnMovementRight;
        }

        private void UnregisterCallbacks(IRightInputActions instance)
        {
            @Shoot.started -= instance.OnShoot;
            @Shoot.performed -= instance.OnShoot;
            @Shoot.canceled -= instance.OnShoot;
            @Skill.started -= instance.OnSkill;
            @Skill.performed -= instance.OnSkill;
            @Skill.canceled -= instance.OnSkill;
            @Barrier.started -= instance.OnBarrier;
            @Barrier.performed -= instance.OnBarrier;
            @Barrier.canceled -= instance.OnBarrier;
            @MovementUp.started -= instance.OnMovementUp;
            @MovementUp.performed -= instance.OnMovementUp;
            @MovementUp.canceled -= instance.OnMovementUp;
            @MovementDown.started -= instance.OnMovementDown;
            @MovementDown.performed -= instance.OnMovementDown;
            @MovementDown.canceled -= instance.OnMovementDown;
            @MovementLeft.started -= instance.OnMovementLeft;
            @MovementLeft.performed -= instance.OnMovementLeft;
            @MovementLeft.canceled -= instance.OnMovementLeft;
            @MovementRight.started -= instance.OnMovementRight;
            @MovementRight.performed -= instance.OnMovementRight;
            @MovementRight.canceled -= instance.OnMovementRight;
        }

        public void RemoveCallbacks(IRightInputActions instance)
        {
            if (m_Wrapper.m_RightInputActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IRightInputActions instance)
        {
            foreach (var item in m_Wrapper.m_RightInputActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_RightInputActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public RightInputActions @RightInput => new RightInputActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private List<IUIActions> m_UIActionsCallbackInterfaces = new List<IUIActions>();
    private readonly InputAction m_UI_Setting;
    public struct UIActions
    {
        private @KeyAction m_Wrapper;
        public UIActions(@KeyAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @Setting => m_Wrapper.m_UI_Setting;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void AddCallbacks(IUIActions instance)
        {
            if (instance == null || m_Wrapper.m_UIActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_UIActionsCallbackInterfaces.Add(instance);
            @Setting.started += instance.OnSetting;
            @Setting.performed += instance.OnSetting;
            @Setting.canceled += instance.OnSetting;
        }

        private void UnregisterCallbacks(IUIActions instance)
        {
            @Setting.started -= instance.OnSetting;
            @Setting.performed -= instance.OnSetting;
            @Setting.canceled -= instance.OnSetting;
        }

        public void RemoveCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IUIActions instance)
        {
            foreach (var item in m_Wrapper.m_UIActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_UIActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public UIActions @UI => new UIActions(this);
    private int m_MouseSchemeIndex = -1;
    public InputControlScheme MouseScheme
    {
        get
        {
            if (m_MouseSchemeIndex == -1) m_MouseSchemeIndex = asset.FindControlSchemeIndex("Mouse");
            return asset.controlSchemes[m_MouseSchemeIndex];
        }
    }
    public interface ILeftInputActions
    {
        void OnShoot(InputAction.CallbackContext context);
        void OnSkill(InputAction.CallbackContext context);
        void OnBarrier(InputAction.CallbackContext context);
        void OnMovementUp(InputAction.CallbackContext context);
        void OnMovementDown(InputAction.CallbackContext context);
        void OnMovementLeft(InputAction.CallbackContext context);
        void OnMovementRight(InputAction.CallbackContext context);
    }
    public interface IRightInputActions
    {
        void OnShoot(InputAction.CallbackContext context);
        void OnSkill(InputAction.CallbackContext context);
        void OnBarrier(InputAction.CallbackContext context);
        void OnMovementUp(InputAction.CallbackContext context);
        void OnMovementDown(InputAction.CallbackContext context);
        void OnMovementLeft(InputAction.CallbackContext context);
        void OnMovementRight(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnSetting(InputAction.CallbackContext context);
    }
}
