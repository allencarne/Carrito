using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

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

    [SerializeField] InputActionAsset asset;


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

    }

    public void K_SteerRightRebind()
    {

    }

    public void K_AccelerateRebind()
    {

    }

    // Controller

    public void C_SteerLeftRebind()
    {

    }

    public void C_SteerRightRebind()
    {

    }

    public void C_AccelerateRebind()
    {

    }
}
