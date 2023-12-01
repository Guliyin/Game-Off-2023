//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/Settings/PlayerInputActions.inputactions
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

public partial class @PlayerInputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""InGame"",
            ""id"": ""c2f55bae-830c-4262-aa97-4c781c01cb9f"",
            ""actions"": [
                {
                    ""name"": ""BulletTime"",
                    ""type"": ""Button"",
                    ""id"": ""33ab3bee-65c6-4ffe-b28c-fd0ad62aaa83"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Gravity Up"",
                    ""type"": ""Button"",
                    ""id"": ""1017dab9-8345-440f-b5ee-b51d820ab912"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Gravity Down"",
                    ""type"": ""Button"",
                    ""id"": ""c681496c-0f3e-4e74-934f-7abbf62ec0d9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Gripple"",
                    ""type"": ""Button"",
                    ""id"": ""6d29c8ac-80f3-497f-be5e-8bcd67aabda7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Restart"",
                    ""type"": ""Button"",
                    ""id"": ""61ead307-51b3-4578-9963-a9d2a12f3acd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""AimMouse"",
                    ""type"": ""Value"",
                    ""id"": ""1833de60-1fe4-4676-8d6e-47ceafa1ee6c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""AimPad"",
                    ""type"": ""Value"",
                    ""id"": ""fcaee09b-998b-4ca5-b171-0cef04c197ec"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""c1dbcfa0-2df7-4683-ba0e-3564bd46053e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a79aa6e4-bafe-4590-86c5-3bc0f28bd46c"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MNK"",
                    ""action"": ""BulletTime"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c755ff00-b02d-4010-83dd-2b024017d82e"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""BulletTime"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""08750059-4cf5-4ba1-9bbb-f618d553b214"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MNK"",
                    ""action"": ""Gravity Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dec54514-9ab2-4fec-9232-b892d886c258"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Gravity Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""08b75b88-518e-4119-9444-e8769d53d4fa"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MNK"",
                    ""action"": ""Gripple"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ad235067-a87d-4fa4-9fe3-c308bfc19fe4"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Gripple"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""94020575-b5e0-4a59-bd92-d91b4c9ed4e8"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MNK"",
                    ""action"": ""Gravity Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""decd304b-b4aa-4e11-afe7-1621bf0cd304"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Gravity Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6d689a30-41d1-4bca-b658-a7abf9e2db3c"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MNK"",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""760bf412-c23e-457f-bb36-cd07987945cf"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""79fb430e-0951-4fa2-aa4f-15b98fdef0cb"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MNK"",
                    ""action"": ""AimMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9b1de2cc-73ba-4ba8-a5df-7c3bdc08f050"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""AimPad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c649c4b6-5aab-4a0b-983f-2a6d5d751a9a"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MNK"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""20b9b43b-696a-4804-b7ef-8dd91dd010d4"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Menu"",
            ""id"": ""d09b4619-66c3-4c79-a890-254380ae7b02"",
            ""actions"": [
                {
                    ""name"": ""Continue"",
                    ""type"": ""Button"",
                    ""id"": ""25862d1e-0c99-438e-9775-a829c99959bb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c04dfd9a-91ab-48cf-97a2-b9260dbd57fb"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Continue"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""MNK"",
            ""bindingGroup"": ""MNK"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // InGame
        m_InGame = asset.FindActionMap("InGame", throwIfNotFound: true);
        m_InGame_BulletTime = m_InGame.FindAction("BulletTime", throwIfNotFound: true);
        m_InGame_GravityUp = m_InGame.FindAction("Gravity Up", throwIfNotFound: true);
        m_InGame_GravityDown = m_InGame.FindAction("Gravity Down", throwIfNotFound: true);
        m_InGame_Gripple = m_InGame.FindAction("Gripple", throwIfNotFound: true);
        m_InGame_Restart = m_InGame.FindAction("Restart", throwIfNotFound: true);
        m_InGame_AimMouse = m_InGame.FindAction("AimMouse", throwIfNotFound: true);
        m_InGame_AimPad = m_InGame.FindAction("AimPad", throwIfNotFound: true);
        m_InGame_Pause = m_InGame.FindAction("Pause", throwIfNotFound: true);
        // Menu
        m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
        m_Menu_Continue = m_Menu.FindAction("Continue", throwIfNotFound: true);
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

    // InGame
    private readonly InputActionMap m_InGame;
    private List<IInGameActions> m_InGameActionsCallbackInterfaces = new List<IInGameActions>();
    private readonly InputAction m_InGame_BulletTime;
    private readonly InputAction m_InGame_GravityUp;
    private readonly InputAction m_InGame_GravityDown;
    private readonly InputAction m_InGame_Gripple;
    private readonly InputAction m_InGame_Restart;
    private readonly InputAction m_InGame_AimMouse;
    private readonly InputAction m_InGame_AimPad;
    private readonly InputAction m_InGame_Pause;
    public struct InGameActions
    {
        private @PlayerInputActions m_Wrapper;
        public InGameActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @BulletTime => m_Wrapper.m_InGame_BulletTime;
        public InputAction @GravityUp => m_Wrapper.m_InGame_GravityUp;
        public InputAction @GravityDown => m_Wrapper.m_InGame_GravityDown;
        public InputAction @Gripple => m_Wrapper.m_InGame_Gripple;
        public InputAction @Restart => m_Wrapper.m_InGame_Restart;
        public InputAction @AimMouse => m_Wrapper.m_InGame_AimMouse;
        public InputAction @AimPad => m_Wrapper.m_InGame_AimPad;
        public InputAction @Pause => m_Wrapper.m_InGame_Pause;
        public InputActionMap Get() { return m_Wrapper.m_InGame; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InGameActions set) { return set.Get(); }
        public void AddCallbacks(IInGameActions instance)
        {
            if (instance == null || m_Wrapper.m_InGameActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_InGameActionsCallbackInterfaces.Add(instance);
            @BulletTime.started += instance.OnBulletTime;
            @BulletTime.performed += instance.OnBulletTime;
            @BulletTime.canceled += instance.OnBulletTime;
            @GravityUp.started += instance.OnGravityUp;
            @GravityUp.performed += instance.OnGravityUp;
            @GravityUp.canceled += instance.OnGravityUp;
            @GravityDown.started += instance.OnGravityDown;
            @GravityDown.performed += instance.OnGravityDown;
            @GravityDown.canceled += instance.OnGravityDown;
            @Gripple.started += instance.OnGripple;
            @Gripple.performed += instance.OnGripple;
            @Gripple.canceled += instance.OnGripple;
            @Restart.started += instance.OnRestart;
            @Restart.performed += instance.OnRestart;
            @Restart.canceled += instance.OnRestart;
            @AimMouse.started += instance.OnAimMouse;
            @AimMouse.performed += instance.OnAimMouse;
            @AimMouse.canceled += instance.OnAimMouse;
            @AimPad.started += instance.OnAimPad;
            @AimPad.performed += instance.OnAimPad;
            @AimPad.canceled += instance.OnAimPad;
            @Pause.started += instance.OnPause;
            @Pause.performed += instance.OnPause;
            @Pause.canceled += instance.OnPause;
        }

        private void UnregisterCallbacks(IInGameActions instance)
        {
            @BulletTime.started -= instance.OnBulletTime;
            @BulletTime.performed -= instance.OnBulletTime;
            @BulletTime.canceled -= instance.OnBulletTime;
            @GravityUp.started -= instance.OnGravityUp;
            @GravityUp.performed -= instance.OnGravityUp;
            @GravityUp.canceled -= instance.OnGravityUp;
            @GravityDown.started -= instance.OnGravityDown;
            @GravityDown.performed -= instance.OnGravityDown;
            @GravityDown.canceled -= instance.OnGravityDown;
            @Gripple.started -= instance.OnGripple;
            @Gripple.performed -= instance.OnGripple;
            @Gripple.canceled -= instance.OnGripple;
            @Restart.started -= instance.OnRestart;
            @Restart.performed -= instance.OnRestart;
            @Restart.canceled -= instance.OnRestart;
            @AimMouse.started -= instance.OnAimMouse;
            @AimMouse.performed -= instance.OnAimMouse;
            @AimMouse.canceled -= instance.OnAimMouse;
            @AimPad.started -= instance.OnAimPad;
            @AimPad.performed -= instance.OnAimPad;
            @AimPad.canceled -= instance.OnAimPad;
            @Pause.started -= instance.OnPause;
            @Pause.performed -= instance.OnPause;
            @Pause.canceled -= instance.OnPause;
        }

        public void RemoveCallbacks(IInGameActions instance)
        {
            if (m_Wrapper.m_InGameActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IInGameActions instance)
        {
            foreach (var item in m_Wrapper.m_InGameActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_InGameActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public InGameActions @InGame => new InGameActions(this);

    // Menu
    private readonly InputActionMap m_Menu;
    private List<IMenuActions> m_MenuActionsCallbackInterfaces = new List<IMenuActions>();
    private readonly InputAction m_Menu_Continue;
    public struct MenuActions
    {
        private @PlayerInputActions m_Wrapper;
        public MenuActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Continue => m_Wrapper.m_Menu_Continue;
        public InputActionMap Get() { return m_Wrapper.m_Menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
        public void AddCallbacks(IMenuActions instance)
        {
            if (instance == null || m_Wrapper.m_MenuActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MenuActionsCallbackInterfaces.Add(instance);
            @Continue.started += instance.OnContinue;
            @Continue.performed += instance.OnContinue;
            @Continue.canceled += instance.OnContinue;
        }

        private void UnregisterCallbacks(IMenuActions instance)
        {
            @Continue.started -= instance.OnContinue;
            @Continue.performed -= instance.OnContinue;
            @Continue.canceled -= instance.OnContinue;
        }

        public void RemoveCallbacks(IMenuActions instance)
        {
            if (m_Wrapper.m_MenuActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMenuActions instance)
        {
            foreach (var item in m_Wrapper.m_MenuActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MenuActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MenuActions @Menu => new MenuActions(this);
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_MNKSchemeIndex = -1;
    public InputControlScheme MNKScheme
    {
        get
        {
            if (m_MNKSchemeIndex == -1) m_MNKSchemeIndex = asset.FindControlSchemeIndex("MNK");
            return asset.controlSchemes[m_MNKSchemeIndex];
        }
    }
    public interface IInGameActions
    {
        void OnBulletTime(InputAction.CallbackContext context);
        void OnGravityUp(InputAction.CallbackContext context);
        void OnGravityDown(InputAction.CallbackContext context);
        void OnGripple(InputAction.CallbackContext context);
        void OnRestart(InputAction.CallbackContext context);
        void OnAimMouse(InputAction.CallbackContext context);
        void OnAimPad(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
    public interface IMenuActions
    {
        void OnContinue(InputAction.CallbackContext context);
    }
}
