using UnityEngine;
using TMPro;  // If you're using TextMeshPro
using UnityEngine.InputSystem;

public class ReconstructionToggle : MonoBehaviour
{
    public GameObject reconstructedVersion;  // The reconstructed version (starts off)
    
    // UI Text element to show the current mode (use TextMeshPro or Unity Text)
    public TextMeshProUGUI modeText;  // TextMeshPro Text component
    // public UnityEngine.UI.Text modeText;  // If you are using Unity's default Text (uncomment this line instead)

    public InputActionReference toggleAction;  // Reference to the input action for toggling
    
    void OnEnable()
    {
        toggleAction.action.performed += onToggle;
        toggleAction.action.Enable();
    }

    void OnDisable()
    {
        toggleAction.action.performed -= onToggle;
        toggleAction.action.Disable();
    }

    void Start()
    {
        // Ensure the reconstructed version starts hidden
        reconstructedVersion.SetActive(false);

        // Set initial UI text (Ruins Mode at start)
        UpdateUI(false);
    }

    // when VR button is pressed
    private void onToggle(InputAction.CallbackContext context)
    {
        bool newState = !reconstructedVersion.activeSelf;
        if (newState)
        {
            ShowReconstruction();
        }
        else
        {
            HideReconstruction();
        }
    }

    // Shows the reconstructed version on top of the ruins
    void ShowReconstruction()
    {
        reconstructedVersion.SetActive(true);
        UpdateUI(true);  // Set text to "Reconstructed Mode"
    }

    // Hides the reconstructed version, leaving only the ruins
    void HideReconstruction()
    {
        reconstructedVersion.SetActive(false);
        UpdateUI(false);  // Set text to "Ruins Mode"
    }

    // Update the UI Text based on the mode (true = reconstructed, false = ruins)
    void UpdateUI(bool isReconstructed)
    {
        if (isReconstructed)
        {
            modeText.text =
                "TEMPLE RECONSTRUCTION:\n" +
                "<color=#8FFF8F>ACTIVE</color>\n" +
                "Press T to toggle";
        }
        else
        {
            modeText.text =
                "TEMPLE RECONSTRUCTION:\n" +
                "<color=#FF8F8F>HIDDEN</color>\n" +
                "Press T to toggle";
        }
    }
}