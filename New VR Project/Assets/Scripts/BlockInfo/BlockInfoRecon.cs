using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class BlockInfoRecon : MonoBehaviour
{
    [Header("Reconstruction Objects")]
    public GameObject blockRecon;      // 3D reconstructed block
    public GameObject pdfWindow;       // PDF / info panel

    [Header("UI Text")]
    public TextMeshProUGUI titleText;        // Assign in Inspector
    public TextMeshProUGUI descriptionText;  // Assign in Inspector

    [Header("Block Content")]
    public string blockTitle;
    [TextArea]
    public string blockDescription;

    private bool isVisible = false;

    void Start()
    {
        blockRecon.SetActive(false);
        pdfWindow.SetActive(false);
    }

    // Called by XR Interaction Toolkit (hook this in Inspector)
    public void OnSelectEntered(SelectEnterEventArgs args)
    {
        ShowPDF();
    }

    public void ShowPDF()
    {
        isVisible = true;

        // Show objects
        blockRecon.SetActive(true);
        pdfWindow.SetActive(true);

        // Update UI text
        if (titleText != null)
            titleText.text = blockTitle;

        if (descriptionText != null)
            descriptionText.text = blockDescription;
    }

    public void HidePDF()
    {
        isVisible = false;

        blockRecon.SetActive(false);
        pdfWindow.SetActive(false);
    }

    public void TogglePDF()
    {
        BlockManager.Instance.SetActiveBlock(this);
    }
}