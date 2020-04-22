// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/InputSystem/InputMaster.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputMaster : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMaster()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMaster"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""9d426832-a74e-4fec-b466-c3d9ae7f0f28"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""cfc62854-ebac-4765-b962-bd0f5066c340"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""StickDeadzone"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interaction (Item)"",
                    ""type"": ""Button"",
                    ""id"": ""f9963dc1-a875-4df9-b614-23e48f963ccf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interaction (Vehicle)"",
                    ""type"": ""Button"",
                    ""id"": ""cc04e9a9-331d-427b-99cf-0fdb5d6d6a6a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""Camera"",
                    ""type"": ""PassThrough"",
                    ""id"": ""c72a7599-9dc1-469b-974e-29a9bf39bdd9"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""825c7b4e-5a19-4c0e-875b-d98931ad89cc"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interaction (Item)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fffe6cd6-352c-4052-8fee-a1ac23975742"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interaction (Item)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f2f19c8d-f6e2-49da-aec4-5485da58941d"",
                    ""path"": ""<DualShockGamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interaction (Item)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""39780249-9692-4bdc-b8fa-f9e0a39a8506"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interaction (Vehicle)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""225a115d-b719-4c95-8523-ec1d1d32933a"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interaction (Vehicle)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e8285813-6770-4987-9242-f3434409d75d"",
                    ""path"": ""<DualShockGamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interaction (Vehicle)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard (WASD)"",
                    ""id"": ""bbafe1c1-bee5-43d7-b616-5a01195839fd"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""faed62ce-2d51-42ec-9e0f-05075719f3fd"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""292c42d6-3b3e-477d-b0b0-8c43fe9a6fc1"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""16325bbf-d2bb-4b3e-8f43-23be51c66b35"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""9a336782-39ed-41b9-8bd7-11b2af40ce05"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""4ff9d1a2-e29d-4d24-9350-9f2ad6bf50b6"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard (QE)"",
                    ""id"": ""336ec9cc-bdae-43e6-bb57-7d2fd4bf73d7"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""42e1dd02-febc-40d2-bdb9-98f4eababd52"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""55e2f351-32b0-42c6-ba8f-b4beb3a31eee"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""ef4407aa-e16c-46c2-a9f7-29b03456a081"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""84aad486-62b0-429d-949f-5050fe3a8c1a"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""2d780b9b-1add-4dc2-989a-a947274c4a44"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Dollycart"",
            ""id"": ""3e13fa2c-539b-4644-8af1-c5a53d254c8d"",
            ""actions"": [
                {
                    ""name"": ""Movement (Digital)"",
                    ""type"": ""PassThrough"",
                    ""id"": ""c4774d7e-e9a9-4904-9361-74d617029dce"",
                    ""expectedControlType"": ""Dpad"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Movement (Analog)"",
                    ""type"": ""PassThrough"",
                    ""id"": ""3588c15c-5d49-4cff-8c2a-9af4ece4c5ad"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard (WASD)"",
                    ""id"": ""ab1d63d8-16a6-44b6-b6c3-2b5af5bdff58"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement (Digital)"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""61f90ee8-4205-4d0a-ba57-a7584ee9af69"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement (Digital)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""eb3911e4-62f2-4c6c-a31e-8d37b75d7274"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement (Digital)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""22c381da-d048-44e0-9a9f-85516741c140"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement (Digital)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2dee4450-3a64-447c-a8ff-1a922222e36e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement (Digital)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""4297ad0c-41a3-45b7-ad80-e2b6d2dc5d00"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement (Analog)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_InteractionItem = m_Player.FindAction("Interaction (Item)", throwIfNotFound: true);
        m_Player_InteractionVehicle = m_Player.FindAction("Interaction (Vehicle)", throwIfNotFound: true);
        m_Player_Camera = m_Player.FindAction("Camera", throwIfNotFound: true);
        // Dollycart
        m_Dollycart = asset.FindActionMap("Dollycart", throwIfNotFound: true);
        m_Dollycart_MovementDigital = m_Dollycart.FindAction("Movement (Digital)", throwIfNotFound: true);
        m_Dollycart_MovementAnalog = m_Dollycart.FindAction("Movement (Analog)", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_InteractionItem;
    private readonly InputAction m_Player_InteractionVehicle;
    private readonly InputAction m_Player_Camera;
    public struct PlayerActions
    {
        private @InputMaster m_Wrapper;
        public PlayerActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @InteractionItem => m_Wrapper.m_Player_InteractionItem;
        public InputAction @InteractionVehicle => m_Wrapper.m_Player_InteractionVehicle;
        public InputAction @Camera => m_Wrapper.m_Player_Camera;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @InteractionItem.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteractionItem;
                @InteractionItem.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteractionItem;
                @InteractionItem.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteractionItem;
                @InteractionVehicle.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteractionVehicle;
                @InteractionVehicle.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteractionVehicle;
                @InteractionVehicle.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteractionVehicle;
                @Camera.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCamera;
                @Camera.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCamera;
                @Camera.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCamera;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @InteractionItem.started += instance.OnInteractionItem;
                @InteractionItem.performed += instance.OnInteractionItem;
                @InteractionItem.canceled += instance.OnInteractionItem;
                @InteractionVehicle.started += instance.OnInteractionVehicle;
                @InteractionVehicle.performed += instance.OnInteractionVehicle;
                @InteractionVehicle.canceled += instance.OnInteractionVehicle;
                @Camera.started += instance.OnCamera;
                @Camera.performed += instance.OnCamera;
                @Camera.canceled += instance.OnCamera;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Dollycart
    private readonly InputActionMap m_Dollycart;
    private IDollycartActions m_DollycartActionsCallbackInterface;
    private readonly InputAction m_Dollycart_MovementDigital;
    private readonly InputAction m_Dollycart_MovementAnalog;
    public struct DollycartActions
    {
        private @InputMaster m_Wrapper;
        public DollycartActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @MovementDigital => m_Wrapper.m_Dollycart_MovementDigital;
        public InputAction @MovementAnalog => m_Wrapper.m_Dollycart_MovementAnalog;
        public InputActionMap Get() { return m_Wrapper.m_Dollycart; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DollycartActions set) { return set.Get(); }
        public void SetCallbacks(IDollycartActions instance)
        {
            if (m_Wrapper.m_DollycartActionsCallbackInterface != null)
            {
                @MovementDigital.started -= m_Wrapper.m_DollycartActionsCallbackInterface.OnMovementDigital;
                @MovementDigital.performed -= m_Wrapper.m_DollycartActionsCallbackInterface.OnMovementDigital;
                @MovementDigital.canceled -= m_Wrapper.m_DollycartActionsCallbackInterface.OnMovementDigital;
                @MovementAnalog.started -= m_Wrapper.m_DollycartActionsCallbackInterface.OnMovementAnalog;
                @MovementAnalog.performed -= m_Wrapper.m_DollycartActionsCallbackInterface.OnMovementAnalog;
                @MovementAnalog.canceled -= m_Wrapper.m_DollycartActionsCallbackInterface.OnMovementAnalog;
            }
            m_Wrapper.m_DollycartActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MovementDigital.started += instance.OnMovementDigital;
                @MovementDigital.performed += instance.OnMovementDigital;
                @MovementDigital.canceled += instance.OnMovementDigital;
                @MovementAnalog.started += instance.OnMovementAnalog;
                @MovementAnalog.performed += instance.OnMovementAnalog;
                @MovementAnalog.canceled += instance.OnMovementAnalog;
            }
        }
    }
    public DollycartActions @Dollycart => new DollycartActions(this);
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnInteractionItem(InputAction.CallbackContext context);
        void OnInteractionVehicle(InputAction.CallbackContext context);
        void OnCamera(InputAction.CallbackContext context);
    }
    public interface IDollycartActions
    {
        void OnMovementDigital(InputAction.CallbackContext context);
        void OnMovementAnalog(InputAction.CallbackContext context);
    }
}
