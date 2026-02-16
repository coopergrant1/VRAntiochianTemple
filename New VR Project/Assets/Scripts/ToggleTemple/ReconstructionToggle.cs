using UnityEngine;
using TMPro;
using System.Collections;

public class ReconstructionToggle : MonoBehaviour
{
    [Header("Temple Objects")]
    public GameObject reconstructedVersion;   // Parent object with reconstructed meshes

    private bool showingReconstruction = false;

    [Header("UI")]
    public TextMeshProUGUI modeText;          // TempleModeText from Canvas
    public CanvasGroup modePanel;             // Optional: panel background for fade effect

    void Start()
    {
        if (reconstructedVersion != null)
            reconstructedVersion.SetActive(false);

        UpdateUI(false);
    }

    void Update()
    {
        // Toggle with T key (matches your BlockToggle key)
        if (Input.GetKeyDown(KeyCode.T))
        {
            showingReconstruction = !showingReconstruction;

            if (reconstructedVersion != null)
                reconstructedVersion.SetActive(showingReconstruction);

            UpdateUI(showingReconstruction);

            if (modePanel != null)
                StartCoroutine(FlashPanel());
        }
    }

    void UpdateUI(bool isReconstructed)
    {
        if (modeText == null) return;

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

    IEnumerator FlashPanel()
    {
        modePanel.alpha = 1f;
        yield return new WaitForSeconds(2f);
        modePanel.alpha = 0.6f;
    }
}
