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
    [SerializeField] TextMeshProUGUI c_SteerLeftCurrentBind;
    [SerializeField] TextMeshProUGUI c_SteerRightCurrentBind;
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


        // Controller Steer Left
        c_SteerLeftCurrentBind.text = asset.FindAction("Steer").GetBindingDisplayString(0);
        // Controller Steer Right
        c_SteerRightCurrentBind.text = asset.FindAction("Steer").GetBindingDisplayString(0);
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

    public void K_SteerLeftRebind()
    {
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
                k_SteerLeftCurrentBind.text = InputControlPath.ToHumanReadableString(SteerAction.action.bindings[2].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);

                rebindingOperation.Dispose();
                SteerAction.action.Enable();
            })
            .Start();
    }

    public void K_SteerRightRebind()
    {
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
                // Assuming the right steering is at index 3
                k_SteerRightCurrentBind.text = InputControlPath.ToHumanReadableString(SteerAction.action.bindings[3].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);

                rebindingOperation.Dispose();
                SteerAction.action.Enable();
            })
            .Start();
    }

    public void K_AccelerateRebind()
    {
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
                k_AccelerateCurrentBind.text = InputControlPath.ToHumanReadableString(AccelerateAction.action.bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);

                rebindingOperation.Dispose();
                AccelerateAction.action.Enable();
            })
            .Start();
    }

    public void K_BrakeRebind()
    {
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
                k_BrakeCurrentBind.text = InputControlPath.ToHumanReadableString(BrakeAction.action.bindings[1].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);

                rebindingOperation.Dispose();
                BrakeAction.action.Enable();
            })
            .Start();
    }

    public void K_BoostRebind()
    {
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
                k_BoostCurrentBind.text = InputControlPath.ToHumanReadableString(BoostAction.action.bindings[1].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);

                rebindingOperation.Dispose();
                BoostAction.action.Enable();
            })
            .Start();
    }

    public void K_DriftRebind()
    {
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
                k_DriftCurrentBind.text = InputControlPath.ToHumanReadableString(DriftAction.action.bindings[1].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);

                rebindingOperation.Dispose();
                DriftAction.action.Enable();
            })
            .Start();
    }

    public void K_PauseRebind()
    {
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
                k_PauseCurrentBind.text = InputControlPath.ToHumanReadableString(PauseAction.action.bindings[1].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);

                rebindingOperation.Dispose();
                PauseAction.action.Enable();
            })
            .Start();
    }

    public void K_ResetRebind()
    {
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
                k_ResetCurrentBind.text = InputControlPath.ToHumanReadableString(ResetAction.action.bindings[1].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);

                rebindingOperation.Dispose();
                ResetAction.action.Enable();
            })
            .Start();
    }

    // Controller

    public void C_SteerLeftRebind()
    {
        // DeSelect the currently Selected UI Button
        EventSystem.current.SetSelectedGameObject(null);

        // Disable before Re-Bind
        SteerAction.action.Disable();

        // Update Button Text to say "Press Any Button"
        c_SteerLeftCurrentBind.text = "Press Any Button";

        rebindingOperation = SteerAction.action.PerformInteractiveRebinding()
            .WithControlsExcluding("<Mouse>")
            .WithControlsExcluding("<Mouse>/LeftButton")
            .WithControlsExcluding("Keyboard")
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(operation =>
            {
                c_SteerLeftCurrentBind.text = InputControlPath.ToHumanReadableString(SteerAction.action.bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);

                rebindingOperation.Dispose();
                SteerAction.action.Enable();
            })
            .Start();
    }

    public void C_SteerRightRebind()
    {

    }

    public void C_AccelerateRebind()
    {
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
                c_AccelerateCurrentBind.text = InputControlPath.ToHumanReadableString(AccelerateAction.action.bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);

                rebindingOperation.Dispose();
                AccelerateAction.action.Enable();
            })
            .Start();
    }

    public void BackButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
