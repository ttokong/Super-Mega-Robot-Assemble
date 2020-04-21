// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerControlsSetup/PlayerControls.inputactions'

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
                    ""expectedControlType"": ""Button"",
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
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""ce31f1b7-ef24-48dc-8350-40285b5e3015"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""9ead2332-008f-404b-86f1-cba561521c57"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Punch"",
                    ""type"": ""Button"",
                    ""id"": ""fe43920b-8673-4a87-a45c-106638d38e50"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Punch1"",
                    ""type"": ""Button"",
                    ""id"": ""f0ef61bb-9667-4cbc-9388-9fcc50eeda96"",
                    ""expectedControlType"": ""Button"",
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
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f3a2399d-8800-4f5b-8ad4-85e8b7635b4d"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Punch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b95428d3-dc13-4fc9-bc7b-3407174a09ec"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Punch1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8bab02ed-a697-4b03-845f-4c8eb3fcbe9c"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ultimate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""519fe101-02e9-4533-9b98-b2c2876f08d2"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""716002cf-393e-4040-84c8-e5548cde7722"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Super Mega Robot Assemble"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""85473e14-972a-4ab3-9b1a-fca4d1a834c2"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""7c550cdf-426b-4dc3-b9fb-e4746ea4eac2"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2a8d569b-f2b0-4202-aa44-4de03d9279b6"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""989fe2b8-9eef-4f98-b0ac-91c0c0e50d60"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""4ec8bb05-d250-40c6-b541-5c42aaf9f1ab"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
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
                    ""name"": ""IJKL"",
                    ""id"": ""238406c1-6d61-4305-8401-86311b3e8a6e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""fb31801a-8e9e-45ee-a731-eda87c9dbb91"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""1bf9e915-7818-451c-ae5c-0155bd8b3316"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""968526b8-5b3a-4eca-b1cf-a18e03e3e017"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""68d7d2bd-b49a-408d-a13f-3cbc556c6889"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
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
                    ""id"": ""dcf56217-2e29-4665-a294-49b96df6f638"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9dbefe24-8037-4231-8c9d-c77a4caf7a16"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""708542ae-cf00-4b8e-989a-063c3534a3c6"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
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
        m_Gameplay_Shoot = m_Gameplay.FindAction("Shoot", throwIfNotFound: true);
        m_Gameplay_Jump = m_Gameplay.FindAction("Jump", throwIfNotFound: true);
        m_Gameplay_Punch = m_Gameplay.FindAction("Punch", throwIfNotFound: true);
        m_Gameplay_Punch1 = m_Gameplay.FindAction("Punch1", throwIfNotFound: true);
        m_Gameplay_Ultimate = m_Gameplay.FindAction("Ultimate", throwIfNotFound: true);
        m_Gameplay_Pause = m_Gameplay.FindAction("Pause", throwIfNotFound: true);
        m_Gameplay_SuperMegaRobotAssemble = m_Gameplay.FindAction("Super Mega Robot Assemble", throwIfNotFound: true);
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
    private readonly InputAction m_Gameplay_Shoot;
    private readonly InputAction m_Gameplay_Jump;
    private readonly InputAction m_Gameplay_Punch;
    private readonly InputAction m_Gameplay_Punch1;
    private readonly InputAction m_Gameplay_Ultimate;
    private readonly InputAction m_Gameplay_Pause;
    private readonly InputAction m_Gameplay_SuperMegaRobotAssemble;
    public struct GameplayActions
    {
        private @PlayerControls m_Wrapper;
        public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Gameplay_Move;
        public InputAction @Aim => m_Wrapper.m_Gameplay_Aim;
        public InputAction @Shoot => m_Wrapper.m_Gameplay_Shoot;
        public InputAction @Jump => m_Wrapper.m_Gameplay_Jump;
        public InputAction @Punch => m_Wrapper.m_Gameplay_Punch;
        public InputAction @Punch1 => m_Wrapper.m_Gameplay_Punch1;
        public InputAction @Ultimate => m_Wrapper.m_Gameplay_Ultimate;
        public InputAction @Pause => m_Wrapper.m_Gameplay_Pause;
        public InputAction @SuperMegaRobotAssemble => m_Wrapper.m_Gameplay_SuperMegaRobotAssemble;
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
                @Shoot.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShoot;
                @Jump.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Punch.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPunch;
                @Punch.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPunch;
                @Punch.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPunch;
                @Punch1.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPunch1;
                @Punch1.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPunch1;
                @Punch1.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPunch1;
                @Ultimate.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUltimate;
                @Ultimate.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUltimate;
                @Ultimate.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUltimate;
                @Pause.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                @SuperMegaRobotAssemble.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSuperMegaRobotAssemble;
                @SuperMegaRobotAssemble.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSuperMegaRobotAssemble;
                @SuperMegaRobotAssemble.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSuperMegaRobotAssemble;
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
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Punch.started += instance.OnPunch;
                @Punch.performed += instance.OnPunch;
                @Punch.canceled += instance.OnPunch;
                @Punch1.started += instance.OnPunch1;
                @Punch1.performed += instance.OnPunch1;
                @Punch1.canceled += instance.OnPunch1;
                @Ultimate.started += instance.OnUltimate;
                @Ultimate.performed += instance.OnUltimate;
                @Ultimate.canceled += instance.OnUltimate;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @SuperMegaRobotAssemble.started += instance.OnSuperMegaRobotAssemble;
                @SuperMegaRobotAssemble.performed += instance.OnSuperMegaRobotAssemble;
                @SuperMegaRobotAssemble.canceled += instance.OnSuperMegaRobotAssemble;
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
        void OnShoot(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnPunch(InputAction.CallbackContext context);
        void OnPunch1(InputAction.CallbackContext context);
        void OnUltimate(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnSuperMegaRobotAssemble(InputAction.CallbackContext context);
    }
}
