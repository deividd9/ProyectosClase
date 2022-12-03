// GENERATED AUTOMATICALLY FROM 'Assets/InputSystem/InputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""Anubis"",
            ""id"": ""e0a54cfc-5d1e-4a72-b7e4-cef0549f6982"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""2b455d5b-7800-4888-99a1-ed7d124fb59f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9ac86413-f7b0-4b5f-840c-d2a5d8463caf"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""94c225ac-fd8c-4d46-97dc-f4511fd6b56b"",
                    ""path"": ""<Keyboard>/space"",
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
    ""controlSchemes"": []
}");
        // Anubis
        m_Anubis = asset.FindActionMap("Anubis", throwIfNotFound: true);
        m_Anubis_Jump = m_Anubis.FindAction("Jump", throwIfNotFound: true);
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

    // Anubis
    private readonly InputActionMap m_Anubis;
    private IAnubisActions m_AnubisActionsCallbackInterface;
    private readonly InputAction m_Anubis_Jump;
    public struct AnubisActions
    {
        private @InputActions m_Wrapper;
        public AnubisActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_Anubis_Jump;
        public InputActionMap Get() { return m_Wrapper.m_Anubis; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AnubisActions set) { return set.Get(); }
        public void SetCallbacks(IAnubisActions instance)
        {
            if (m_Wrapper.m_AnubisActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_AnubisActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_AnubisActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_AnubisActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_AnubisActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }
        }
    }
    public AnubisActions @Anubis => new AnubisActions(this);
    public interface IAnubisActions
    {
        void OnJump(InputAction.CallbackContext context);
    }
}
