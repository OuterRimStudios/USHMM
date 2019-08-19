// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Controls/Controls.inputactions'

using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class Controls : IInputActionCollection
{
    private InputActionAsset asset;
    public Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Input"",
            ""id"": ""8f28cd2d-6e21-4ed8-8d6b-1e3dac4ba167"",
            ""actions"": [
                {
                    ""name"": ""Right Grip"",
                    ""type"": ""Value"",
                    ""id"": ""7ce041e6-8c4e-493a-a3a9-8268699daa59"",
                    ""expectedControlType"": ""Double"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left Grip"",
                    ""type"": ""Value"",
                    ""id"": ""98d3f139-a883-469d-b535-68dfb572b342"",
                    ""expectedControlType"": ""Double"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left Position"",
                    ""type"": ""Value"",
                    ""id"": ""dd6d06a6-4193-48be-8bc2-045874fa67e7"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left Rotation"",
                    ""type"": ""Value"",
                    ""id"": ""e1b5215f-81e2-438a-9de4-4d1dc3577099"",
                    ""expectedControlType"": ""Quaternion"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right Position"",
                    ""type"": ""Value"",
                    ""id"": ""907bab19-b249-49b2-811a-bfa796cdded1"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right Rotation"",
                    ""type"": ""Value"",
                    ""id"": ""a20abd5a-6681-4b46-b152-9f8b4cfede9f"",
                    ""expectedControlType"": ""Quaternion"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a6bf921a-c6ad-4133-b9c4-f63c9a450b37"",
                    ""path"": ""<KnucklesController>{RightHand}/grip"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Knuckles"",
                    ""action"": ""Right Grip"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""647267ca-d2bc-4843-b5f0-be2e2a5fb7e2"",
                    ""path"": ""<KnucklesController>{LeftHand}/grip"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Knuckles"",
                    ""action"": ""Left Grip"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ad80f1b3-dfa9-4a0e-a624-7ff898d11cfa"",
                    ""path"": ""<KnucklesController>{LeftHand}/devicePosition"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left Position"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2724f7c8-24cb-489e-82d9-2dc0bcb6d2bb"",
                    ""path"": ""<KnucklesController>{RightHand}/devicePosition"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right Position"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a2cf9f93-29a8-4c18-8063-0633195a23b6"",
                    ""path"": ""<KnucklesController>{LeftHand}/deviceRotation"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e89da580-1cef-4801-98c6-7f5b933f02f4"",
                    ""path"": ""<KnucklesController>{RightHand}/deviceRotation"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Knuckles"",
            ""basedOn"": """",
            ""bindingGroup"": ""Knuckles"",
            ""devices"": [
                {
                    ""devicePath"": ""<KnucklesController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Input
        m_Input = asset.GetActionMap("Input");
        m_Input_RightGrip = m_Input.GetAction("Right Grip");
        m_Input_LeftGrip = m_Input.GetAction("Left Grip");
        m_Input_LeftPosition = m_Input.GetAction("Left Position");
        m_Input_LeftRotation = m_Input.GetAction("Left Rotation");
        m_Input_RightPosition = m_Input.GetAction("Right Position");
        m_Input_RightRotation = m_Input.GetAction("Right Rotation");
    }

    ~Controls()
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

    // Input
    private readonly InputActionMap m_Input;
    private IInputActions m_InputActionsCallbackInterface;
    private readonly InputAction m_Input_RightGrip;
    private readonly InputAction m_Input_LeftGrip;
    private readonly InputAction m_Input_LeftPosition;
    private readonly InputAction m_Input_LeftRotation;
    private readonly InputAction m_Input_RightPosition;
    private readonly InputAction m_Input_RightRotation;
    public struct InputActions
    {
        private Controls m_Wrapper;
        public InputActions(Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @RightGrip => m_Wrapper.m_Input_RightGrip;
        public InputAction @LeftGrip => m_Wrapper.m_Input_LeftGrip;
        public InputAction @LeftPosition => m_Wrapper.m_Input_LeftPosition;
        public InputAction @LeftRotation => m_Wrapper.m_Input_LeftRotation;
        public InputAction @RightPosition => m_Wrapper.m_Input_RightPosition;
        public InputAction @RightRotation => m_Wrapper.m_Input_RightRotation;
        public InputActionMap Get() { return m_Wrapper.m_Input; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InputActions set) { return set.Get(); }
        public void SetCallbacks(IInputActions instance)
        {
            if (m_Wrapper.m_InputActionsCallbackInterface != null)
            {
                RightGrip.started -= m_Wrapper.m_InputActionsCallbackInterface.OnRightGrip;
                RightGrip.performed -= m_Wrapper.m_InputActionsCallbackInterface.OnRightGrip;
                RightGrip.canceled -= m_Wrapper.m_InputActionsCallbackInterface.OnRightGrip;
                LeftGrip.started -= m_Wrapper.m_InputActionsCallbackInterface.OnLeftGrip;
                LeftGrip.performed -= m_Wrapper.m_InputActionsCallbackInterface.OnLeftGrip;
                LeftGrip.canceled -= m_Wrapper.m_InputActionsCallbackInterface.OnLeftGrip;
                LeftPosition.started -= m_Wrapper.m_InputActionsCallbackInterface.OnLeftPosition;
                LeftPosition.performed -= m_Wrapper.m_InputActionsCallbackInterface.OnLeftPosition;
                LeftPosition.canceled -= m_Wrapper.m_InputActionsCallbackInterface.OnLeftPosition;
                LeftRotation.started -= m_Wrapper.m_InputActionsCallbackInterface.OnLeftRotation;
                LeftRotation.performed -= m_Wrapper.m_InputActionsCallbackInterface.OnLeftRotation;
                LeftRotation.canceled -= m_Wrapper.m_InputActionsCallbackInterface.OnLeftRotation;
                RightPosition.started -= m_Wrapper.m_InputActionsCallbackInterface.OnRightPosition;
                RightPosition.performed -= m_Wrapper.m_InputActionsCallbackInterface.OnRightPosition;
                RightPosition.canceled -= m_Wrapper.m_InputActionsCallbackInterface.OnRightPosition;
                RightRotation.started -= m_Wrapper.m_InputActionsCallbackInterface.OnRightRotation;
                RightRotation.performed -= m_Wrapper.m_InputActionsCallbackInterface.OnRightRotation;
                RightRotation.canceled -= m_Wrapper.m_InputActionsCallbackInterface.OnRightRotation;
            }
            m_Wrapper.m_InputActionsCallbackInterface = instance;
            if (instance != null)
            {
                RightGrip.started += instance.OnRightGrip;
                RightGrip.performed += instance.OnRightGrip;
                RightGrip.canceled += instance.OnRightGrip;
                LeftGrip.started += instance.OnLeftGrip;
                LeftGrip.performed += instance.OnLeftGrip;
                LeftGrip.canceled += instance.OnLeftGrip;
                LeftPosition.started += instance.OnLeftPosition;
                LeftPosition.performed += instance.OnLeftPosition;
                LeftPosition.canceled += instance.OnLeftPosition;
                LeftRotation.started += instance.OnLeftRotation;
                LeftRotation.performed += instance.OnLeftRotation;
                LeftRotation.canceled += instance.OnLeftRotation;
                RightPosition.started += instance.OnRightPosition;
                RightPosition.performed += instance.OnRightPosition;
                RightPosition.canceled += instance.OnRightPosition;
                RightRotation.started += instance.OnRightRotation;
                RightRotation.performed += instance.OnRightRotation;
                RightRotation.canceled += instance.OnRightRotation;
            }
        }
    }
    public InputActions @Input => new InputActions(this);
    private int m_KnucklesSchemeIndex = -1;
    public InputControlScheme KnucklesScheme
    {
        get
        {
            if (m_KnucklesSchemeIndex == -1) m_KnucklesSchemeIndex = asset.GetControlSchemeIndex("Knuckles");
            return asset.controlSchemes[m_KnucklesSchemeIndex];
        }
    }
    public interface IInputActions
    {
        void OnRightGrip(InputAction.CallbackContext context);
        void OnLeftGrip(InputAction.CallbackContext context);
        void OnLeftPosition(InputAction.CallbackContext context);
        void OnLeftRotation(InputAction.CallbackContext context);
        void OnRightPosition(InputAction.CallbackContext context);
        void OnRightRotation(InputAction.CallbackContext context);
    }
}
