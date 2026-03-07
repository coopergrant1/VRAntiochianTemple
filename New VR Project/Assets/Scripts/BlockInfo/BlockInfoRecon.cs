using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class BlockInfoRecon : MonoBehaviour
{
    [Header("Reconstruction Objects")]
    public GameObject blockRecon;      // 3D reconstructed block
    public GameObject pdfWindow;       // PDF / info panel

    [Header("UI Text")]
    public TextMeshProUGUI titleText;       // Assign titleText textMeshPro
    public TextMeshProUGUI descriptionText; // Assign descripitionText textMeshPro
    public TextMeshProUGUI placementText;   // Assign placementText textMeshPro
    public UnityEngine.UI.Image displayDrawing1;    // Assign displayImage UI Image
    public UnityEngine.UI.Image displayDrawing2;    // Assign displayImage UI Image


    [Header("Block Content")]
    public string blockTitle;
    [TextArea]
    public string blockDescription;
    [TextArea]
    public string blockPlacement;
    public Sprite blockDrawing1;
    public Sprite blockDrawing2;

    private bool isVisible = false;

    void Start()
    {
        blockRecon.SetActive(false);
        pdfWindow.SetActive(false);
    }

    // Called by XR Interaction Toolkit (hook this in Inspector)
    public void OnActivateEntered(ActivateEventArgs args)
    {
        TogglePDF();
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

        if (placementText != null)
            placementText.text = blockPlacement;

        if (displayDrawing1 != null)
            displayDrawing1.sprite = blockDrawing1;

        if (displayDrawing2 != null)
            displayDrawing2.sprite = blockDrawing2;
    }

    public void HidePDF()
    {
        isVisible = false;

        blockRecon.SetActive(false);
        pdfWindow.SetActive(false);
    }

    public void TogglePDF()
    {
        BlockManagerNew.Instance.SetActiveBlock(this);
    }
}