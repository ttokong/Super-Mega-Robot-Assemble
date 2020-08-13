// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Player/PlayerControlsSetup/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""a1cb99ee-c0e8-4ab3-b4f1-f836fbd5bcb3"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""e16401e6-6d92-4ad5-a52c-acb31c580690"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""PassThrough"",
                    ""id"": ""14522139-ead5-487c-856a-b479a0753562"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ShootHold"",
                    ""type"": ""Value"",
                    ""id"": ""7361e798-fa95-411e-a7a6-2c618a28ce98"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Ultimate"",
                    ""type"": ""Button"",
                    ""id"": ""fbce3212-5cce-407f-8a24-3023cdd16a86"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""27f9ea7e-900f-4ade-a905-c75119a7aa21"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Super Mega Robot Assemble"",
                    ""type"": ""Button"",
                    ""id"": ""3ede0336-f513-4d4f-82ee-cb22685d360d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UINav"",
                    ""type"": ""Button"",
                    ""id"": ""d9d45f3e-de49-4bff-949a-08aad5674212"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UISelection"",
                    ""type"": ""Button"",
                    ""id"": ""94492b36-5dc8-405d-bf7c-7c35b57cd70a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4627fb85-72f3-4388-90a4-6351a7f84551"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Super Mega Robot Assemble"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7bfa4a34-9c9e-49ea-96e9-1eee99518ce6"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bffdb7d4-3cea-4cf1-ad2b-d6c3cfe6f793"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b8504b0a-cb11-48f7-b77a-d55d45227a73"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ShootHold"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Left Right"",
                    ""id"": ""2bd3930d-1a3f-4b78-a2df-91501194af23"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UINav"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""31899ac2-bdb2-45ba-895a-95f8072d4010"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""UINav"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""2147cd62-452e-4fee-a2fb-03976fda8460"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""UINav"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""9e0d2e5f-37e7-4dcc-a5cb-b6306809339c"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UISelection"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""e9d7fd21-4de8-41a2-93fa-7aa9098df1e6"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""UISelection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""c9790bd8-0191-454b-8ffa-49a3543a9e37"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""UISelection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
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
        }
    ]
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Move = m_Gameplay.FindAction("Move", throwIfNotFound: true);
        m_Gameplay_Aim = m_Gameplay.FindAction("Aim", throwIfNotFound: true);
        m_Gameplay_ShootHold = m_Gameplay.FindAction("ShootHold", throwIfNotFound: true);
        m_Gameplay_Ultimate = m_Gameplay.FindAction("Ultimate", throwIfNotFound: true);
        m_Gameplay_Pause = m_Gameplay.FindAction("Pause", throwIfNotFound: true);
        m_Gameplay_SuperMegaRobotAssemble = m_Gameplay.FindAction("Super Mega Robot Assemble", throwIfNotFound: true);
        m_Gameplay_UINav = m_Gameplay.FindAction("UINav", throwIfNotFound: true);
        m_Gameplay_UISelection = m_Gameplay.FindAction("UISelection", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Move;
    private readonly InputAction m_Gameplay_Aim;
    private readonly InputAction m_Gameplay_ShootHold;
    private readonly InputAction m_Gameplay_Ultimate;
    private readonly InputAction m_Gameplay_Pause;
    private readonly InputAction m_Gameplay_SuperMegaRobotAssemble;
    private readonly InputAction m_Gameplay_UINav;
    private readonly InputAction m_Gameplay_UISelection;
    public struct GameplayActions
    {
        private @PlayerControls m_Wrapper;
        public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Gameplay_Move;
        public InputAction @Aim => m_Wrapper.m_Gameplay_Aim;
        public InputAction @ShootHold => m_Wrapper.m_Gameplay_ShootHold;
        public InputAction @Ultimate => m_Wrapper.m_Gameplay_Ultimate;
        public InputAction @Pause => m_Wrapper.m_Gameplay_Pause;
        public InputAction @SuperMegaRobotAssemble => m_Wrapper.m_Gameplay_SuperMegaRobotAssemble;
        public InputAction @UINav => m_Wrapper.m_Gameplay_UINav;
        public InputAction @UISelection => m_Wrapper.m_Gameplay_UISelection;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Aim.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAim;
                @ShootHold.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShootHold;
                @ShootHold.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShootHold;
                @ShootHold.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShootHold;
                @Ultimate.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUltimate;
                @Ultimate.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUltimate;
                @Ultimate.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUltimate;
                @Pause.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                @SuperMegaRobotAssemble.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSuperMegaRobotAssemble;
                @SuperMegaRobotAssemble.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSuperMegaRobotAssemble;
                @SuperMegaRobotAssemble.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSuperMegaRobotAssemble;
                @UINav.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUINav;
                @UINav.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUINav;
                @UINav.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUINav;
                @UISelection.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUISelection;
                @UISelection.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUISelection;
                @UISelection.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUISelection;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @ShootHold.started += instance.OnShootHold;
                @ShootHold.performed += instance.OnShootHold;
                @ShootHold.canceled += instance.OnShootHold;
                @Ultimate.started += instance.OnUltimate;
                @Ultimate.performed += instance.OnUltimate;
                @Ultimate.canceled += instance.OnUltimate;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @SuperMegaRobotAssemble.started += instance.OnSuperMegaRobotAssemble;
                @SuperMegaRobotAssemble.performed += instance.OnSuperMegaRobotAssemble;
                @SuperMegaRobotAssemble.canceled += instance.OnSuperMegaRobotAssemble;
                @UINav.started += instance.OnUINav;
                @UINav.performed += instance.OnUINav;
                @UINav.canceled += instance.OnUINav;
                @UISelection.started += instance.OnUISelection;
                @UISelection.performed += instance.OnUISelection;
                @UISelection.canceled += instance.OnUISelection;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IGameplayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnShootHold(InputAction.CallbackContext context);
        void OnUltimate(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnSuperMegaRobotAssemble(InputAction.CallbackContext context);
        void OnUINav(InputAction.CallbackContext context);
        void OnUISelection(InputAction.CallbackContext context);
    }
}
