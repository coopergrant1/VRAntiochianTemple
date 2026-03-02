using UnityEngine;
using UnityEngine.InputSystem;

public class CanvasToggle : MonoBehaviour
{
    public GameObject panelCanvas;
    public InputActionReference toggleAction;

    public InputActionReference switchTabAction;

    public GameObject description;
    public GameObject drawing;

    private bool showDescription= true;
    private void OnEnable()
    {
        toggleAction.action.performed += OnToggle;
        toggleAction.action.Enable();

        switchTabAction.action.performed += OnSwitchTab;
        switchTabAction.action.Enable();
    }

    private void OnDisable()
    {
        toggleAction.action.performed -= OnToggle;
        toggleAction.action.Disable();

        switchTabAction.action.performed -= OnSwitchTab;
        switchTabAction.action.Disable();
    }

    private void OnToggle(InputAction.CallbackContext ctx)
    {
        panelCanvas.SetActive(!panelCanvas.activeSelf);
    }

    private void OnSwitchTab(InputAction.CallbackContext ctx)
    {
        showDescription = !showDescription;

        description.SetActive(showDescription);
        drawing.SetActive(!showDescription);
    }
}

