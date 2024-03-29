using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class BindsMenu : MonoBehaviour
{
    [Header("Keybaord")]
    [SerializeField] TextMeshProUGUI k_SteerLeftCurrentBind;
    [SerializeField] TextMeshProUGUI k_SteerRightCurrentBind;
    [SerializeField] TextMeshProUGUI k_AccelerateCurrentBind;
    [SerializeField] TextMeshProUGUI k_BrakeCurrentBind;
    [SerializeField] TextMeshProUGUI k_BoostCurrentBind;
    [SerializeField] TextMeshProUGUI k_DriftCurrentBind;
    [SerializeField] TextMeshProUGUI k_PauseCurrentBind;
    [SerializeField] TextMeshProUGUI k_ResetCurrentBind;

    [Header("Controller")]
    [SerializeField] TextMeshProUGUI c_SteerCurrentBind;
    [SerializeField] TextMeshProUGUI c_AccelerateCurrentBind;
    [SerializeField] TextMeshProUGUI c_BrakeCurrentBind;
    [SerializeField] TextMeshProUGUI c_BoostCurrentBind;
    [SerializeField] TextMeshProUGUI c_DriftCurrentBind;
    [SerializeField] TextMeshProUGUI c_PauseCurrentBind;
    [SerializeField] TextMeshProUGUI c_ResetCurrentBind;

    // Input
    [SerializeField] InputActionAsset asset;
    [SerializeField] InputActionReference SteerAction;
    [SerializeField] InputActionReference AccelerateAction;
    [SerializeField] InputActionReference BrakeAction;
    [SerializeField] InputActionReference BoostAction;
    [SerializeField] InputActionReference DriftAction;
    [SerializeField] InputActionReference PauseAction;
    [SerializeField] InputActionReference ResetAction;

    InputActionRebindingExtensions.RebindingOperation rebindingOperation;

    private void Start()
    {
        LoadSavedKeybinds();

        // Keyboard Steer Left
        k_SteerLeftCurrentBind.text = asset.FindAction("Steer").GetBindingDisplayString(2);
        // Keyboard Steer Right
        k_SteerRightCurrentBind.text = asset.FindAction("Steer").GetBindingDisplayString(3);
        // Keyboard Accelerate
        k_AccelerateCurrentBind.text = asset.FindAction("Accelerate").GetBindingDisplayString(1);
        // Keyboard Brake
        k_BrakeCurrentBind.text = asset.FindAction("Brake").GetBindingDisplayString(1);
        // Keyboard Boost
        k_BoostCurrentBind.text = asset.FindAction("Boost").GetBindingDisplayString(1);
        // Keyboard Drift
        k_DriftCurrentBind.text = asset.FindAction("Drift").GetBindingDisplayString(1);
        // Keyboard Pause
        k_PauseCurrentBind.text = asset.FindAction("Pause").GetBindingDisplayString(1);
        // Keyboard Reset
        k_ResetCurrentBind.text = asset.FindAction("Reset").GetBindingDisplayString(1);


        // Controller Steer
        c_SteerCurrentBind.text = asset.FindAction("Steer").GetBindingDisplayString(0);
        // Controller Accelerate
        c_AccelerateCurrentBind.text = asset.FindAction("Accelerate").GetBindingDisplayString(0);
        // Controller Brake
        c_BrakeCurrentBind.text = asset.FindAction("Brake").GetBindingDisplayString(0);
        // Controller Boost
        c_BoostCurrentBind.text = asset.FindAction("Boost").GetBindingDisplayString(0);
        // Controller Drift
        c_DriftCurrentBind.text = asset.FindAction("Drift").GetBindingDisplayString(0);
        // Controller Pause
        c_PauseCurrentBind.text = asset.FindAction("Pause").GetBindingDisplayString(0);
        // Controller Reset
        c_ResetCurrentBind.text = asset.FindAction("Reset").GetBindingDisplayString(0);
    }

    private void LoadSavedKeybinds()
    {
        // Keyboard Steer Left
        LoadAndApplyKeybind(SteerAction.action, 2, "SteerLeftKey", "Keyboard/A");
        // Keybord Steer Right
        LoadAndApplyKeybind(SteerAction.action, 3, "SteerRightKey", "Keyboard/D");
        // Keyboard Accelerate
        LoadAndApplyKeybind(AccelerateAction.action, 1, "AccelerateKey", "Keyboard/W");
        // Keyboard Brake
        LoadAndApplyKeybind(BrakeAction.action, 1, "BrakeKey", "Keyboard/S");
        // Keyboard Boost
        LoadAndApplyKeybind(BoostAction.action, 1, "BoostKey", "Keyboard/Space");
        // Keyboard Drift
        LoadAndApplyKeybind(DriftAction.action, 1, "DriftKey", "Keyboard/Shift");
        // Keyboard Pause
        LoadAndApplyKeybind(PauseAction.action, 1, "PauseKey", "Keyboard/Escape");
        // Keyboard Reset
        LoadAndApplyKeybind(ResetAction.action, 1, "ResetKey", "Keyboard/Tab");

        // Controller Steer
        LoadAndApplyKeybind(SteerAction.action, 0, "SteerButton", "<Gamepad>/leftStick");
        // Controller Accelerate
        LoadAndApplyKeybind(AccelerateAction.action, 0, "AccelerateButton", "<Gamepad>/righttrigger");
        // Controller Brake
        LoadAndApplyKeybind(BrakeAction.action, 0, "BrakeButton", "<Gamepad>/lefttrigger");
        // Controller Boost
        LoadAndApplyKeybind(BoostAction.action, 0, "BoostButton", "<Gamepad>/rightshoulder");
        // Controller Drift
        LoadAndApplyKeybind(DriftAction.action, 0, "DriftButton", "<Gamepad>/leftshoulder");
        // Controller Pause
        LoadAndApplyKeybind(PauseAction.action, 0, "PauseButton", "<Gamepad>/start");
        // Controller Reset
        LoadAndApplyKeybind(ResetAction.action, 0, "ResetButton", "<Gamepad>/select");
    }

    private void LoadAndApplyKeybind(InputAction action, int controlIndex, string keyPref, string defaultKey)
    {
        string savedKeybind = PlayerPrefs.GetString(keyPref, defaultKey);
        action.ApplyBindingOverride(controlIndex, savedKeybind);
    }

    private void SaveKeybinds()
    {
        // Keyboard Steer Left
        SaveKeybind(SteerAction.action, 2, "SteerLeftKey");
        // Keybord Steer Right
        SaveKeybind(SteerAction.action, 3, "SteerRightKey");
        // Keyboard Accelerate
        SaveKeybind(AccelerateAction.action, 1, "AccelerateKey");
        // Keyboard Brake
        SaveKeybind(BrakeAction.action, 1, "BrakeKey");
        // Keyboard Boost
        SaveKeybind(BoostAction.action, 1, "BoostKey");
        // Keyboard Drift
        SaveKeybind(DriftAction.action, 1, "DriftKey");
        // Keyboard Pause
        SaveKeybind(PauseAction.action, 1, "PauseKey");
        // Keyboard Reset
        SaveKeybind(ResetAction.action, 1, "ResetKey");

        // Controller Steer
        SaveKeybind(SteerAction.action, 0, "SteerButton");
        // Controller Accelerate
        SaveKeybind(AccelerateAction.action, 0, "AccelerateButton");
        // Controller Brake
        SaveKeybind(BrakeAction.action, 0, "BrakeButton");
        // Controller Boost
        SaveKeybind(BoostAction.action, 0, "BoostButton");
        // Controller Drift
        SaveKeybind(DriftAction.action, 0, "DriftButton");
        // Controller Pause
        SaveKeybind(PauseAction.action, 0, "PauseButton");
        // Controller Reset
        SaveKeybind(ResetAction.action, 0, "ResetButton");
    }

    private void SaveKeybind(InputAction action, int controlIndex, string keyPref)
    {
        string currentKeybind = action.bindings[controlIndex].effectivePath;
        PlayerPrefs.SetString(keyPref, currentKeybind);
        PlayerPrefs.Save();
    }

    #region Keyboard & Mouse

    public void K_SteerLeftRebind()
    {
        // Store the currently Selected UI Button
        GameObject lastSelectedButton = EventSystem.current.currentSelectedGameObject;

        // DeSelect the currently Selected UI Button
        EventSystem.current.SetSelectedGameObject(null);

        // Disable before Re-Bind
        SteerAction.action.Disable();

        // Update Button Text to say "Press Any Button"
        k_SteerLeftCurrentBind.text = "Press Any Button";


        rebindingOperation = SteerAction.action.PerformInteractiveRebinding()
            .WithTargetBinding(2)
            .WithControlsExcluding("<Gamepad>")
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(operation =>
            {
                k_SteerLeftCurrentBind.color = Color.blue;
                k_SteerLeftCurrentBind.text = InputControlPath.ToHumanReadableString(SteerAction.action.bindings[2].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);

                SaveKeybinds();

                rebindingOperation.Dispose();
                SteerAction.action.Enable();

                // Reselect the last Selected UI Button
                EventSystem.current.SetSelectedGameObject(lastSelectedButton);
            })
            .Start();
    }

    public void K_Reset_SteerLeft()
    {
        // Store the currently Selected UI Button
        GameObject lastSelectedButton = EventSystem.current.currentSelectedGameObject;

        // DeSelect the currently Selected UI Button
        EventSystem.current.SetSelectedGameObject(null);

        // Disable before Re-Bind
        SteerAction.action.Disable();

        // Clear any existing binding overrides for the specific control index
        SteerAction.action.RemoveBindingOverride(2);

        // Apply the default binding for the specific control index
        SteerAction.action.ApplyBindingOverride(2, "Keyboard/A");

        // Reset Color
        k_SteerLeftCurrentBind.color = Color.white;

        // Update the text with the new default binding information
        k_SteerLeftCurrentBind.text = InputControlPath.ToHumanReadableString(SteerAction.action.bindings[2].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);

        // Enable
        SteerAction.action.Enable();

        // Reselect the last Selected UI Button
        EventSystem.current.SetSelectedGameObject(lastSelectedButton);
    }

    public void K_SteerRightRebind()
    {
        // Store the currently Selected UI Button
        GameObject lastSelectedButton = EventSystem.current.currentSelectedGameObject;

        // DeSelect the currently Selected UI Button
        EventSystem.current.SetSelectedGameObject(null);

        // Disable before Re-Bind
        SteerAction.action.Disable();

        // Update Text to say "Press Any Button"
        k_SteerRightCurrentBind.text = "Press Any Button";

        rebindingOperation = SteerAction.action.PerformInteractiveRebinding()
            .WithTargetBinding(3)
            .WithControlsExcluding("<Gamepad>")
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(operation =>
            {
                k_SteerRightCurrentBind.color = Color.blue;
                k_SteerRightCurrentBind.text = InputControlPath.ToHumanReadableString(SteerAction.action.bindings[3].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);

                SaveKeybinds();

                rebindingOperation.Dispose();
                SteerAction.action.Enable();

                // Reselect the last Selected UI Button
                EventSystem.current.SetSelectedGameObject(lastSelectedButton);
            })
            .Start();
    }

    public void K_Reset_SteerRight()
    {
        // Store the currently Selected UI Button
        GameObject lastSelectedButton = EventSystem.current.currentSelectedGameObject;

        // DeSelect the currently Selected UI Button
        EventSystem.current.SetSelectedGameObject(null);

        // Disable before Re-Bind
        SteerAction.action.Disable();

        // Clear any existing binding overrides for the specific control index
        SteerAction.action.RemoveBindingOverride(3);

        // Apply the default binding for the specific control index
        SteerAction.action.ApplyBindingOverride(3, "Keyboard/D");

        // Reset Color
        k_SteerRightCurrentBind.color = Color.white;

        // Update the text with the new default binding information
        k_SteerRightCurrentBind.text = InputControlPath.ToHumanReadableString(SteerAction.action.bindings[3].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);

        // Save the keybinds after resetting to default
        SaveKeybinds();

        // Enable
        SteerAction.action.Enable();

        // Reselect the last Selected UI Button
        EventSystem.current.SetSelectedGameObject(lastSelectedButton);
    }

    public void K_AccelerateRebind()
    {
        // Store the currently Selected UI Button
        GameObject lastSelectedButton = EventSystem.current.currentSelectedGameObject;

        // DeSelect the currently Selected UI Button
        EventSystem.current.SetSelectedGameObject(null);

        // Disable before Re-Bind
        AccelerateAction.action.Disable();

        // Update Button Text to say "Press Any Button"
        k_AccelerateCurrentBind.text = "Press Any Button";


        rebindingOperation = AccelerateAction.action.PerformInteractiveRebinding()
            .WithControlsExcluding("<Gamepad>")
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(operation =>
            {
                k_AccelerateCurrentBind.color = Color.blue;
                k_AccelerateCurrentBind.text = InputControlPath.ToHumanReadableString(AccelerateAction.action.bindings[1].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);

                SaveKeybinds();

                rebindingOperation.Dispose();
                AccelerateAction.action.Enable();

                // Reselect the last Selected UI Button
                EventSystem.current.SetSelectedGameObject(lastSelectedButton);
            })
            .Start();
    }

    public void K_Reset_Accelerate()
    {
        // Store the currently Selected UI Button
        GameObject lastSelectedButton = EventSystem.current.currentSelectedGameObject;

        // DeSelect the currently Selected UI Button
        EventSystem.current.SetSelectedGameObject(null);

        // Disable before Re-Bind
        AccelerateAction.action.Disable();

        // Clear any existing binding overrides for the specific control index
        AccelerateAction.action.RemoveBindingOverride(1);

        // Apply the default binding for the specific control index
        AccelerateAction.action.ApplyBindingOverride(1, "Keyboard/W");

        // Reset Color
        k_AccelerateCurrentBind.color = Color.white;

        // Update the text with the new default binding information
        k_AccelerateCurrentBind.text = InputControlPath.ToHumanReadableString(AccelerateAction.action.bindings[1].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);

        // Save the keybinds after resetting to default
        SaveKeybinds();

        // Enable
        AccelerateAction.action.Enable();

        // Reselect the last Selected UI Button
        EventSystem.current.SetSelectedGameObject(lastSelectedButton);
    }

    public void K_BrakeRebind()
    {
        // Store the currently Selected UI Button
        GameObject lastSelectedButton = EventSystem.current.currentSelectedGameObject;

        // DeSelect the currently Selected UI Button
        EventSystem.current.SetSelectedGameObject(null);

        // Disable before Re-Bind
        BrakeAction.action.Disable();

        // Update Button Text to say "Press Any Button"
        k_BrakeCurrentBind.text = "Press Any Button";


        rebindingOperation = BrakeAction.action.PerformInteractiveRebinding()
            .WithControlsExcluding("<Gamepad>")
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(operation =>
            {
                k_BrakeCurrentBind.color = Color.blue;
                k_BrakeCurrentBind.text = InputControlPath.ToHumanReadableString(BrakeAction.action.bindings[1].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);

                SaveKeybinds();

                rebindingOperation.Dispose();
                BrakeAction.action.Enable();

                // Reselect the last Selected UI Button
                EventSystem.current.SetSelectedGameObject(lastSelectedButton);
            })
            .Start();
    }

    public void K_Reset_Brake()
    {
        // Store the currently Selected UI Button
        GameObject lastSelectedButton = EventSystem.current.currentSelectedGameObject;

        // DeSelect the currently Selected UI Button
        EventSystem.current.SetSelectedGameObject(null);

        // Disable before Re-Bind
        BrakeAction.action.Disable();

        // Clear any existing binding overrides for the specific control index
        BrakeAction.action.RemoveBindingOverride(1);

        // Apply the default binding for the specific control index
        BrakeAction.action.ApplyBindingOverride(1, "Keyboard/S");

        // Reset Color
        k_BrakeCurrentBind.color = Color.white;

        // Update the text with the new default binding information
        k_BrakeCurrentBind.text = InputControlPath.ToHumanReadableString(BrakeAction.action.bindings[1].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);

        // Save the keybinds after resetting to default
        SaveKeybinds();

        // Enable
        BrakeAction.action.Enable();

        // Reselect the last Selected UI Button
        EventSystem.current.SetSelectedGameObject(lastSelectedButton);
    }

    public void K_BoostRebind()
    {
        // Store the currently Selected UI Button
        GameObject lastSelectedButton = EventSystem.current.currentSelectedGameObject;

        // DeSelect the currently Selected UI Button
        EventSystem.current.SetSelectedGameObject(null);

        // Disable before Re-Bind
        BoostAction.action.Disable();

        // Update Button Text to say "Press Any Button"
        k_BoostCurrentBind.text = "Press Any Button";


        rebindingOperation = BoostAction.action.PerformInteractiveRebinding()
            .WithControlsExcluding("<Gamepad>")
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(operation =>
            {
                k_BoostCurrentBind.color = Color.blue;
                k_BoostCurrentBind.text = InputControlPath.ToHumanReadableString(BoostAction.action.bindings[1].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);

                SaveKeybinds();

                rebindingOperation.Dispose();
                BoostAction.action.Enable();

                // Reselect the last Selected UI Button
                EventSystem.current.SetSelectedGameObject(lastSelectedButton);
            })
            .Start();
    }

    public void K_Reset_Boost()
    {
        // Store the currently Selected UI Button
        GameObject lastSelectedButton = EventSystem.current.currentSelectedGameObject;

        // DeSelect the currently Selected UI Button
        EventSystem.current.SetSelectedGameObject(null);

        // Disable before Re-Bind
        BoostAction.action.Disable();

        // Clear any existing binding overrides for the specific control index
        BoostAction.action.RemoveBindingOverride(1);

        // Apply the default binding for the specific control index
        BoostAction.action.ApplyBindingOverride(1, "Keyboard/Space");

        // Reset Color
        k_BoostCurrentBind.color = Color.white;

        // Update the text with the new default binding information
        k_BoostCurrentBind.text = InputControlPath.ToHumanReadableString(BoostAction.action.bindings[1].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);

        // Save the keybinds after resetting to default
        SaveKeybinds();

        // Enable
        BoostAction.action.Enable();

        // Reselect the last Selected UI Button
        EventSystem.current.SetSelectedGameObject(lastSelectedButton);
    }

    public void K_DriftRebind()
    {
        // Store the currently Selected UI Button
        GameObject lastSelectedButton = EventSystem.current.currentSelectedGameObject;

        // DeSelect the currently Selected UI Button
        EventSystem.current.SetSelectedGameObject(null);

        // Disable before Re-Bind
        DriftAction.action.Disable();

        // Update Button Text to say "Press Any Button"
        k_DriftCurrentBind.text = "Press Any Button";


        rebindingOperation = DriftAction.action.PerformInteractiveRebinding()
            .WithControlsExcluding("<Gamepad>")
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(operation =>
            {
                k_DriftCurrentBind.color = Color.blue;
                k_DriftCurrentBind.text = InputControlPath.ToHumanReadableString(DriftAction.action.bindings[1].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);

                SaveKeybinds();

                rebindingOperation.Dispose();
                DriftAction.action.Enable();

                // Reselect the last Selected UI Button
                EventSystem.current.SetSelectedGameObject(lastSelectedButton);
            })
            .Start();
    }

    public void K_Reset_Drift()
    {
        // Store the currently Selected UI Button
        GameObject lastSelectedButton = EventSystem.current.currentSelectedGameObject;

        // DeSelect the currently Selected UI Button
        EventSystem.current.SetSelectedGameObject(null);

        // Disable before Re-Bind
        DriftAction.action.Disable();

        // Clear any existing binding overrides for the specific control index
        DriftAction.action.RemoveBindingOverride(1);

        // Apply the default binding for the specific control index
        DriftAction.action.ApplyBindingOverride(1, "Keyboard/Shift");

        // Reset Color
        k_DriftCurrentBind.color = Color.white;

        // Update the text with the new default binding information
        k_DriftCurrentBind.text = InputControlPath.ToHumanReadableString(DriftAction.action.bindings[1].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);

        // Save the keybinds after resetting to default
        SaveKeybinds();

        // Enable
        DriftAction.action.Enable();

        // Reselect the last Selected UI Button
        EventSystem.current.SetSelectedGameObject(lastSelectedButton);
    }

    public void K_PauseRebind()
    {
        // Store the currently Selected UI Button
        GameObject lastSelectedButton = EventSystem.current.currentSelectedGameObject;

        // DeSelect the currently Selected UI Button
        EventSystem.current.SetSelectedGameObject(null);

        // Disable before Re-Bind
        PauseAction.action.Disable();

        // Update Button Text to say "Press Any Button"
        k_PauseCurrentBind.text = "Press Any Button";


        rebindingOperation = PauseAction.action.PerformInteractiveRebinding()
            .WithControlsExcluding("<Gamepad>")
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(operation =>
            {
                k_PauseCurrentBind.color = Color.blue;
                k_PauseCurrentBind.text = InputControlPath.ToHumanReadableString(PauseAction.action.bindings[1].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);

                SaveKeybinds();

                rebindingOperation.Dispose();
                PauseAction.action.Enable();

                // Reselect the last Selected UI Button
                EventSystem.current.SetSelectedGameObject(lastSelectedButton);
            })
            .Start();
    }

    public void K_Reset_Pause()
    {
        // Store the currently Selected UI Button
        GameObject lastSelectedButton = EventSystem.current.currentSelectedGameObject;

        // DeSelect the currently Selected UI Button
        EventSystem.current.SetSelectedGameObject(null);

        // Disable before Re-Bind
        PauseAction.action.Disable();

        // Clear any existing binding overrides for the specific control index
        PauseAction.action.RemoveBindingOverride(1);

        // Apply the default binding for the specific control index
        PauseAction.action.ApplyBindingOverride(1, "Keyboard/Escape");

        // Reset Color
        k_PauseCurrentBind.color = Color.white;

        // Update the text with the new default binding information
        k_PauseCurrentBind.text = InputControlPath.ToHumanReadableString(PauseAction.action.bindings[1].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);

        // Save the keybinds after resetting to default
        SaveKeybinds();

        // Enable
        PauseAction.action.Enable();

        // Reselect the last Selected UI Button
        EventSystem.current.SetSelectedGameObject(lastSelectedButton);
    }

    public void K_ResetRebind()
    {
        // Store the currently Selected UI Button
        GameObject lastSelectedButton = EventSystem.current.currentSelectedGameObject;

        // DeSelect the currently Selected UI Button
        EventSystem.current.SetSelectedGameObject(null);

        // Disable before Re-Bind
        ResetAction.action.Disable();

        // Update Button Text to say "Press Any Button"
        k_ResetCurrentBind.text = "Press Any Button";


        rebindingOperation = ResetAction.action.PerformInteractiveRebinding()
            .WithControlsExcluding("<Gamepad>")
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(operation =>
            {
                k_ResetCurrentBind.color = Color.blue;
                k_ResetCurrentBind.text = InputControlPath.ToHumanReadableString(ResetAction.action.bindings[1].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);

                SaveKeybinds();

                rebindingOperation.Dispose();
                ResetAction.action.Enable();

                // Reselect the last Selected UI Button
                EventSystem.current.SetSelectedGameObject(lastSelectedButton);
            })
            .Start();
    }

    public void K_Reset_Reset()
    {
        // Store the currently Selected UI Button
        GameObject lastSelectedButton = EventSystem.current.currentSelectedGameObject;

        // DeSelect the currently Selected UI Button
        EventSystem.current.SetSelectedGameObject(null);

        // Disable before Re-Bind
        ResetAction.action.Disable();

        // Clear any existing binding overrides for the specific control index
        ResetAction.action.RemoveBindingOverride(1);

        // Apply the default binding for the specific control index
        ResetAction.action.ApplyBindingOverride(1, "Keyboard/Tab");

        // Reset Color
        k_ResetCurrentBind.color = Color.white;

        // Update the text with the new default binding information
        k_ResetCurrentBind.text = InputControlPath.ToHumanReadableString(ResetAction.action.bindings[1].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);

        // Save the keybinds after resetting to default
        SaveKeybinds();

        // Enable
        ResetAction.action.Enable();

        // Reselect the last Selected UI Button
        EventSystem.current.SetSelectedGameObject(lastSelectedButton);
    }

    #endregion

    #region Controller

    public void C_SteerRebind()
    {
        // Store the currently Selected UI Button
        GameObject lastSelectedButton = EventSystem.current.currentSelectedGameObject;

        // DeSelect the currently Selected UI Button
        EventSystem.current.SetSelectedGameObject(null);

        // Disable before Re-Bind
        SteerAction.action.Disable();

        // Update Button Text to say "Press Any Button"
        c_SteerCurrentBind.text = "Press Any Button";

        rebindingOperation = SteerAction.action.PerformInteractiveRebinding()
            .WithTargetBinding(0)
            .WithControlsExcluding("<Mouse>")
            .WithControlsExcluding("<Mouse>/LeftButton")
            .WithControlsExcluding("Keyboard")
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(operation =>
            {
                c_SteerCurrentBind.color = Color.blue;
                c_SteerCurrentBind.text = InputControlPath.ToHumanReadableString(SteerAction.action.bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);

                SaveKeybinds();

                rebindingOperation.Dispose();
                SteerAction.action.Enable();

                // Reselect the last Selected UI Button
                EventSystem.current.SetSelectedGameObject(lastSelectedButton);
            })
            .Start();
    }

    public void C_Reset_Steer()
    {
        // Store the currently Selected UI Button
        GameObject lastSelectedButton = EventSystem.current.currentSelectedGameObject;

        // DeSelect the currently Selected UI Button
        EventSystem.current.SetSelectedGameObject(null);

        // Disable before Re-Bind
        SteerAction.action.Disable();

        // Clear any existing binding overrides for the specific control index
        SteerAction.action.RemoveBindingOverride(0);

        // Apply the default binding for the specific control index
        SteerAction.action.ApplyBindingOverride(0, "<Gamepad>/leftStick");

        // Reset Color
        c_SteerCurrentBind.color = Color.white;

        // Update the text with the new default binding information
        c_SteerCurrentBind.text = InputControlPath.ToHumanReadableString(SteerAction.action.bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);

        // Save the keybinds after resetting to default
        SaveKeybinds();

        // Enable
        SteerAction.action.Enable();

        // Reselect the last Selected UI Button
        EventSystem.current.SetSelectedGameObject(lastSelectedButton);
    }

    public void C_AccelerateRebind()
    {
        // Store the currently Selected UI Button
        GameObject lastSelectedButton = EventSystem.current.currentSelectedGameObject;

        // DeSelect the currently Selected UI Button
        EventSystem.current.SetSelectedGameObject(null);

        // Disable before Re-Bind
        AccelerateAction.action.Disable();

        // Update Button Text to say "Press Any Button"
        c_AccelerateCurrentBind.text = "Press Any Button";

        rebindingOperation = AccelerateAction.action.PerformInteractiveRebinding()
            .WithControlsExcluding("<Mouse>")
            .WithControlsExcluding("<Mouse>/LeftButton")
            .WithControlsExcluding("Keyboard")
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(operation =>
            {
                c_AccelerateCurrentBind.color = Color.blue;
                c_AccelerateCurrentBind.text = InputControlPath.ToHumanReadableString(AccelerateAction.action.bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);

                SaveKeybinds();

                rebindingOperation.Dispose();
                AccelerateAction.action.Enable();

                // Reselect the last Selected UI Button
                EventSystem.current.SetSelectedGameObject(lastSelectedButton);
            })
            .Start();
    }

    public void C_Reset_Accelerate()
    {
        // Store the currently Selected UI Button
        GameObject lastSelectedButton = EventSystem.current.currentSelectedGameObject;

        // DeSelect the currently Selected UI Button
        EventSystem.current.SetSelectedGameObject(null);

        // Disable before Re-Bind
        AccelerateAction.action.Disable();

        // Clear any existing binding overrides for the specific control index
        AccelerateAction.action.RemoveBindingOverride(0);

        // Apply the default binding for the specific control index
        AccelerateAction.action.ApplyBindingOverride(0, "<Gamepad>/righttrigger");

        // Reset Color
        c_AccelerateCurrentBind.color = Color.white;

        // Update the text with the new default binding information
        c_AccelerateCurrentBind.text = InputControlPath.ToHumanReadableString(AccelerateAction.action.bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);

        // Save the keybinds after resetting to default
        SaveKeybinds();

        // Enable
        AccelerateAction.action.Enable();

        // Reselect the last Selected UI Button
        EventSystem.current.SetSelectedGameObject(lastSelectedButton);
    }

    public void C_BrakeRebind()
    {
        // Store the currently Selected UI Button
        GameObject lastSelectedButton = EventSystem.current.currentSelectedGameObject;

        // DeSelect the currently Selected UI Button
        EventSystem.current.SetSelectedGameObject(null);

        // Disable before Re-Bind
        BrakeAction.action.Disable();

        // Update Button Text to say "Press Any Button"
        c_BrakeCurrentBind.text = "Press Any Button";

        rebindingOperation = BrakeAction.action.PerformInteractiveRebinding()
            .WithControlsExcluding("<Mouse>")
            .WithControlsExcluding("<Mouse>/LeftButton")
            .WithControlsExcluding("Keyboard")
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(operation =>
            {
                c_BrakeCurrentBind.color = Color.blue;
                c_BrakeCurrentBind.text = InputControlPath.ToHumanReadableString(BrakeAction.action.bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);

                SaveKeybinds();

                rebindingOperation.Dispose();
                BrakeAction.action.Enable();

                // Reselect the last Selected UI Button
                EventSystem.current.SetSelectedGameObject(lastSelectedButton);
            })
            .Start();
    }

    public void C_Reset_Brake()
    {
        // Store the currently Selected UI Button
        GameObject lastSelectedButton = EventSystem.current.currentSelectedGameObject;

        // DeSelect the currently Selected UI Button
        EventSystem.current.SetSelectedGameObject(null);

        // Disable before Re-Bind
        BrakeAction.action.Disable();

        // Clear any existing binding overrides for the specific control index
        BrakeAction.action.RemoveBindingOverride(0);

        // Apply the default binding for the specific control index
        BrakeAction.action.ApplyBindingOverride(0, "<Gamepad>/lefttrigger");

        // Reset Color
        c_BrakeCurrentBind.color = Color.white;

        // Update the text with the new default binding information
        c_BrakeCurrentBind.text = InputControlPath.ToHumanReadableString(BrakeAction.action.bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);

        // Save the keybinds after resetting to default
        SaveKeybinds();

        // Enable
        BrakeAction.action.Enable();

        // Reselect the last Selected UI Button
        EventSystem.current.SetSelectedGameObject(lastSelectedButton);
    }

    public void C_BoostRebind()
    {
        // Store the currently Selected UI Button
        GameObject lastSelectedButton = EventSystem.current.currentSelectedGameObject;

        // DeSelect the currently Selected UI Button
        EventSystem.current.SetSelectedGameObject(null);

        // Disable before Re-Bind
        BoostAction.action.Disable();

        // Update Button Text to say "Press Any Button"
        c_BoostCurrentBind.text = "Press Any Button";

        rebindingOperation = BoostAction.action.PerformInteractiveRebinding()
            .WithControlsExcluding("<Mouse>")
            .WithControlsExcluding("<Mouse>/LeftButton")
            .WithControlsExcluding("Keyboard")
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(operation =>
            {
                c_BoostCurrentBind.color = Color.blue;
                c_BoostCurrentBind.text = InputControlPath.ToHumanReadableString(BoostAction.action.bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);

                SaveKeybinds();

                rebindingOperation.Dispose();
                BoostAction.action.Enable();

                // Reselect the last Selected UI Button
                EventSystem.current.SetSelectedGameObject(lastSelectedButton);
            })
            .Start();
    }

    public void C_Reset_Boost()
    {
        // Store the currently Selected UI Button
        GameObject lastSelectedButton = EventSystem.current.currentSelectedGameObject;

        // DeSelect the currently Selected UI Button
        EventSystem.current.SetSelectedGameObject(null);

        // Disable before Re-Bind
        BoostAction.action.Disable();

        // Clear any existing binding overrides for the specific control index
        BoostAction.action.RemoveBindingOverride(0);

        // Apply the default binding for the specific control index
        BoostAction.action.ApplyBindingOverride(0, "<Gamepad>/rightshoulder");

        // Reset Color
        c_BoostCurrentBind.color = Color.white;

        // Update the text with the new default binding information
        c_BoostCurrentBind.text = InputControlPath.ToHumanReadableString(BoostAction.action.bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);

        // Save the keybinds after resetting to default
        SaveKeybinds();

        // Enable
        BoostAction.action.Enable();

        // Reselect the last Selected UI Button
        EventSystem.current.SetSelectedGameObject(lastSelectedButton);
    }

    public void C_DriftRebind()
    {
        // Store the currently Selected UI Button
        GameObject lastSelectedButton = EventSystem.current.currentSelectedGameObject;

        // DeSelect the currently Selected UI Button
        EventSystem.current.SetSelectedGameObject(null);

        // Disable before Re-Bind
        DriftAction.action.Disable();

        // Update Button Text to say "Press Any Button"
        c_DriftCurrentBind.text = "Press Any Button";

        rebindingOperation = DriftAction.action.PerformInteractiveRebinding()
            .WithControlsExcluding("<Mouse>")
            .WithControlsExcluding("<Mouse>/LeftButton")
            .WithControlsExcluding("Keyboard")
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(operation =>
            {
                c_DriftCurrentBind.color = Color.blue;
                c_DriftCurrentBind.text = InputControlPath.ToHumanReadableString(DriftAction.action.bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);

                SaveKeybinds();

                rebindingOperation.Dispose();
                DriftAction.action.Enable();

                // Reselect the last Selected UI Button
                EventSystem.current.SetSelectedGameObject(lastSelectedButton);
            })
            .Start();
    }

    public void C_Reset_Drift()
    {
        // Store the currently Selected UI Button
        GameObject lastSelectedButton = EventSystem.current.currentSelectedGameObject;

        // DeSelect the currently Selected UI Button
        EventSystem.current.SetSelectedGameObject(null);

        // Disable before Re-Bind
        DriftAction.action.Disable();

        // Clear any existing binding overrides for the specific control index
        DriftAction.action.RemoveBindingOverride(0);

        // Apply the default binding for the specific control index
        DriftAction.action.ApplyBindingOverride(0, "<Gamepad>/leftshoulder");

        // Reset Color
        c_DriftCurrentBind.color = Color.white;

        // Update the text with the new default binding information
        c_DriftCurrentBind.text = InputControlPath.ToHumanReadableString(DriftAction.action.bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);

        // Save the keybinds after resetting to default
        SaveKeybinds();

        // Enable
        DriftAction.action.Enable();

        // Reselect the last Selected UI Button
        EventSystem.current.SetSelectedGameObject(lastSelectedButton);
    }

    public void C_PauseRebind()
    {
        // Store the currently Selected UI Button
        GameObject lastSelectedButton = EventSystem.current.currentSelectedGameObject;

        // DeSelect the currently Selected UI Button
        EventSystem.current.SetSelectedGameObject(null);

        // Disable before Re-Bind
        PauseAction.action.Disable();

        // Update Button Text to say "Press Any Button"
        c_PauseCurrentBind.text = "Press Any Button";

        rebindingOperation = PauseAction.action.PerformInteractiveRebinding()
            .WithControlsExcluding("<Mouse>")
            .WithControlsExcluding("<Mouse>/LeftButton")
            .WithControlsExcluding("Keyboard")
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(operation =>
            {
                c_PauseCurrentBind.color = Color.blue;
                c_PauseCurrentBind.text = InputControlPath.ToHumanReadableString(PauseAction.action.bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);

                SaveKeybinds();

                rebindingOperation.Dispose();
                PauseAction.action.Enable();

                // Reselect the last Selected UI Button
                EventSystem.current.SetSelectedGameObject(lastSelectedButton);
            })
            .Start();
    }

    public void C_Reset_Pause()
    {
        // Store the currently Selected UI Button
        GameObject lastSelectedButton = EventSystem.current.currentSelectedGameObject;

        // DeSelect the currently Selected UI Button
        EventSystem.current.SetSelectedGameObject(null);

        // Disable before Re-Bind
        PauseAction.action.Disable();

        // Clear any existing binding overrides for the specific control index
        PauseAction.action.RemoveBindingOverride(0);

        // Apply the default binding for the specific control index
        PauseAction.action.ApplyBindingOverride(0, "<Gamepad>/start");

        // Reset Color
        c_PauseCurrentBind.color = Color.white;

        // Update the text with the new default binding information
        c_PauseCurrentBind.text = InputControlPath.ToHumanReadableString(PauseAction.action.bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);

        // Save the keybinds after resetting to default
        SaveKeybinds();

        // Enable
        PauseAction.action.Enable();

        // Reselect the last Selected UI Button
        EventSystem.current.SetSelectedGameObject(lastSelectedButton);
    }

    public void C_ResetRebind()
    {
        // Store the currently Selected UI Button
        GameObject lastSelectedButton = EventSystem.current.currentSelectedGameObject;

        // DeSelect the currently Selected UI Button
        EventSystem.current.SetSelectedGameObject(null);

        // Disable before Re-Bind
        ResetAction.action.Disable();

        // Update Button Text to say "Press Any Button"
        c_ResetCurrentBind.text = "Press Any Button";

        rebindingOperation = ResetAction.action.PerformInteractiveRebinding()
            .WithControlsExcluding("<Mouse>")
            .WithControlsExcluding("<Mouse>/LeftButton")
            .WithControlsExcluding("Keyboard")
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(operation =>
            {
                c_ResetCurrentBind.color = Color.blue;
                c_ResetCurrentBind.text = InputControlPath.ToHumanReadableString(ResetAction.action.bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);

                SaveKeybinds();

                rebindingOperation.Dispose();
                ResetAction.action.Enable();

                // Reselect the last Selected UI Button
                EventSystem.current.SetSelectedGameObject(lastSelectedButton);
            })
            .Start();
    }

    public void C_Reset_Reset()
    {
        // Store the currently Selected UI Button
        GameObject lastSelectedButton = EventSystem.current.currentSelectedGameObject;

        // DeSelect the currently Selected UI Button
        EventSystem.current.SetSelectedGameObject(null);

        // Disable before Re-Bind
        ResetAction.action.Disable();

        // Clear any existing binding overrides for the specific control index
        ResetAction.action.RemoveBindingOverride(0);

        // Apply the default binding for the specific control index
        ResetAction.action.ApplyBindingOverride(0, "<Gamepad>/select");

        // Reset Color
        c_ResetCurrentBind.color = Color.white;

        // Update the text with the new default binding information
        c_ResetCurrentBind.text = InputControlPath.ToHumanReadableString(ResetAction.action.bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);

        // Save the keybinds after resetting to default
        SaveKeybinds();

        // Enable
        ResetAction.action.Enable();

        // Reselect the last Selected UI Button
        EventSystem.current.SetSelectedGameObject(lastSelectedButton);
    }

    #endregion

    public void BackButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
