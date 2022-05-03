// GENERATED AUTOMATICALLY FROM 'Assets/Input/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Input
{
    public class @Controls : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @Controls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Racing"",
            ""id"": ""a71f568d-2c96-47a2-a4ab-0403db228625"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""029383d2-408a-4baf-b172-087d66fbc4cb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NorthTrick"",
                    ""type"": ""Button"",
                    ""id"": ""2b1633d0-7e7a-4c51-934b-195bc7d3feae"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""EastTrick"",
                    ""type"": ""Button"",
                    ""id"": ""db49c426-e5ae-4975-b55f-dd6a11f4911c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""WestTrick"",
                    ""type"": ""Button"",
                    ""id"": ""e6f10afa-eb59-4f60-b3b4-aa08cd9fce3a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SouthTrick"",
                    ""type"": ""Button"",
                    ""id"": ""f68de04c-f877-4a28-92b3-3edfb9069a34"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DebugJump"",
                    ""type"": ""Button"",
                    ""id"": ""386329cd-cc45-4814-b591-a6c3274c70c8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DebugFPS30"",
                    ""type"": ""Button"",
                    ""id"": ""da55d6f5-abb3-43a8-a47d-d6795aa49421"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DebugFPS60"",
                    ""type"": ""Button"",
                    ""id"": ""cf922c23-15f1-43b9-8e62-4513cd6a598b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""78c2e5aa-1429-46ba-a82b-83f8e1f290c1"",
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
                    ""id"": ""ea47d951-62bf-4dc0-bca8-1cb3b39d35a2"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""3dba681c-b74b-4c42-adb0-9782da21dad3"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""78f3ad69-e56d-4472-89ba-aa5e4c195cd1"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""3c849643-d0d8-408b-83b9-6f6c2e73f151"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""D-pad"",
                    ""id"": ""1911a918-8f82-433d-8f05-7f982cf40ccf"",
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
                    ""id"": ""8fd075ce-7dc7-4551-baa3-257f103217eb"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""727829ae-a774-4a45-aa6e-dc92de90d1b4"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ee946185-eccd-4ebe-ab4b-0359e33370c7"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""96354fed-cac5-4003-99d9-f1a980d58a95"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Joystick"",
                    ""id"": ""75793a1b-18d3-4907-a8d2-0fad90c73e42"",
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
                    ""id"": ""c3efb820-3a11-44b8-9816-fb8794e00596"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""93a1e157-e238-436b-9498-46c5b396d9f2"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""bcd28ea1-e380-442d-99db-a0b1e75b3055"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""eaed0dd5-5c7e-45fc-b309-f340dc4c0887"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""fd82937e-50eb-409a-9118-9d9174ccb1f2"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NorthTrick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a90d0f06-7415-408c-8204-09d9182a07ef"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NorthTrick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""72db2ee2-326f-4544-bef0-c231c129c813"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EastTrick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bbfa8df4-380d-45a5-a51a-113bc73e48fd"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EastTrick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e77f2d28-cc62-4eed-852b-79df4f480925"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DebugJump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a4abc1bf-bf32-429f-a3b2-c7ee59168865"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SouthTrick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0007996d-030d-4a7d-9619-57b21a6f08f5"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SouthTrick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""52bf4aa1-3591-4b91-9dfe-44a6af8fd2f3"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DebugFPS30"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f26f3cab-02f0-4ccb-94b2-8cba71ba6d63"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DebugFPS60"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""900d7c01-32ae-4f74-86df-ea87c57009c9"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WestTrick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9b984906-c029-4e2c-837a-3a4549754ce5"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WestTrick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Racing
            m_Racing = asset.FindActionMap("Racing", throwIfNotFound: true);
            m_Racing_Move = m_Racing.FindAction("Move", throwIfNotFound: true);
            m_Racing_NorthTrick = m_Racing.FindAction("NorthTrick", throwIfNotFound: true);
            m_Racing_EastTrick = m_Racing.FindAction("EastTrick", throwIfNotFound: true);
            m_Racing_WestTrick = m_Racing.FindAction("WestTrick", throwIfNotFound: true);
            m_Racing_SouthTrick = m_Racing.FindAction("SouthTrick", throwIfNotFound: true);
            m_Racing_DebugJump = m_Racing.FindAction("DebugJump", throwIfNotFound: true);
            m_Racing_DebugFPS30 = m_Racing.FindAction("DebugFPS30", throwIfNotFound: true);
            m_Racing_DebugFPS60 = m_Racing.FindAction("DebugFPS60", throwIfNotFound: true);
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

        // Racing
        private readonly InputActionMap m_Racing;
        private IRacingActions m_RacingActionsCallbackInterface;
        private readonly InputAction m_Racing_Move;
        private readonly InputAction m_Racing_NorthTrick;
        private readonly InputAction m_Racing_EastTrick;
        private readonly InputAction m_Racing_WestTrick;
        private readonly InputAction m_Racing_SouthTrick;
        private readonly InputAction m_Racing_DebugJump;
        private readonly InputAction m_Racing_DebugFPS30;
        private readonly InputAction m_Racing_DebugFPS60;
        public struct RacingActions
        {
            private @Controls m_Wrapper;
            public RacingActions(@Controls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_Racing_Move;
            public InputAction @NorthTrick => m_Wrapper.m_Racing_NorthTrick;
            public InputAction @EastTrick => m_Wrapper.m_Racing_EastTrick;
            public InputAction @WestTrick => m_Wrapper.m_Racing_WestTrick;
            public InputAction @SouthTrick => m_Wrapper.m_Racing_SouthTrick;
            public InputAction @DebugJump => m_Wrapper.m_Racing_DebugJump;
            public InputAction @DebugFPS30 => m_Wrapper.m_Racing_DebugFPS30;
            public InputAction @DebugFPS60 => m_Wrapper.m_Racing_DebugFPS60;
            public InputActionMap Get() { return m_Wrapper.m_Racing; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(RacingActions set) { return set.Get(); }
            public void SetCallbacks(IRacingActions instance)
            {
                if (m_Wrapper.m_RacingActionsCallbackInterface != null)
                {
                    @Move.started -= m_Wrapper.m_RacingActionsCallbackInterface.OnMove;
                    @Move.performed -= m_Wrapper.m_RacingActionsCallbackInterface.OnMove;
                    @Move.canceled -= m_Wrapper.m_RacingActionsCallbackInterface.OnMove;
                    @NorthTrick.started -= m_Wrapper.m_RacingActionsCallbackInterface.OnNorthTrick;
                    @NorthTrick.performed -= m_Wrapper.m_RacingActionsCallbackInterface.OnNorthTrick;
                    @NorthTrick.canceled -= m_Wrapper.m_RacingActionsCallbackInterface.OnNorthTrick;
                    @EastTrick.started -= m_Wrapper.m_RacingActionsCallbackInterface.OnEastTrick;
                    @EastTrick.performed -= m_Wrapper.m_RacingActionsCallbackInterface.OnEastTrick;
                    @EastTrick.canceled -= m_Wrapper.m_RacingActionsCallbackInterface.OnEastTrick;
                    @WestTrick.started -= m_Wrapper.m_RacingActionsCallbackInterface.OnWestTrick;
                    @WestTrick.performed -= m_Wrapper.m_RacingActionsCallbackInterface.OnWestTrick;
                    @WestTrick.canceled -= m_Wrapper.m_RacingActionsCallbackInterface.OnWestTrick;
                    @SouthTrick.started -= m_Wrapper.m_RacingActionsCallbackInterface.OnSouthTrick;
                    @SouthTrick.performed -= m_Wrapper.m_RacingActionsCallbackInterface.OnSouthTrick;
                    @SouthTrick.canceled -= m_Wrapper.m_RacingActionsCallbackInterface.OnSouthTrick;
                    @DebugJump.started -= m_Wrapper.m_RacingActionsCallbackInterface.OnDebugJump;
                    @DebugJump.performed -= m_Wrapper.m_RacingActionsCallbackInterface.OnDebugJump;
                    @DebugJump.canceled -= m_Wrapper.m_RacingActionsCallbackInterface.OnDebugJump;
                    @DebugFPS30.started -= m_Wrapper.m_RacingActionsCallbackInterface.OnDebugFPS30;
                    @DebugFPS30.performed -= m_Wrapper.m_RacingActionsCallbackInterface.OnDebugFPS30;
                    @DebugFPS30.canceled -= m_Wrapper.m_RacingActionsCallbackInterface.OnDebugFPS30;
                    @DebugFPS60.started -= m_Wrapper.m_RacingActionsCallbackInterface.OnDebugFPS60;
                    @DebugFPS60.performed -= m_Wrapper.m_RacingActionsCallbackInterface.OnDebugFPS60;
                    @DebugFPS60.canceled -= m_Wrapper.m_RacingActionsCallbackInterface.OnDebugFPS60;
                }
                m_Wrapper.m_RacingActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                    @NorthTrick.started += instance.OnNorthTrick;
                    @NorthTrick.performed += instance.OnNorthTrick;
                    @NorthTrick.canceled += instance.OnNorthTrick;
                    @EastTrick.started += instance.OnEastTrick;
                    @EastTrick.performed += instance.OnEastTrick;
                    @EastTrick.canceled += instance.OnEastTrick;
                    @WestTrick.started += instance.OnWestTrick;
                    @WestTrick.performed += instance.OnWestTrick;
                    @WestTrick.canceled += instance.OnWestTrick;
                    @SouthTrick.started += instance.OnSouthTrick;
                    @SouthTrick.performed += instance.OnSouthTrick;
                    @SouthTrick.canceled += instance.OnSouthTrick;
                    @DebugJump.started += instance.OnDebugJump;
                    @DebugJump.performed += instance.OnDebugJump;
                    @DebugJump.canceled += instance.OnDebugJump;
                    @DebugFPS30.started += instance.OnDebugFPS30;
                    @DebugFPS30.performed += instance.OnDebugFPS30;
                    @DebugFPS30.canceled += instance.OnDebugFPS30;
                    @DebugFPS60.started += instance.OnDebugFPS60;
                    @DebugFPS60.performed += instance.OnDebugFPS60;
                    @DebugFPS60.canceled += instance.OnDebugFPS60;
                }
            }
        }
        public RacingActions @Racing => new RacingActions(this);
        public interface IRacingActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnNorthTrick(InputAction.CallbackContext context);
            void OnEastTrick(InputAction.CallbackContext context);
            void OnWestTrick(InputAction.CallbackContext context);
            void OnSouthTrick(InputAction.CallbackContext context);
            void OnDebugJump(InputAction.CallbackContext context);
            void OnDebugFPS30(InputAction.CallbackContext context);
            void OnDebugFPS60(InputAction.CallbackContext context);
        }
    }
}
