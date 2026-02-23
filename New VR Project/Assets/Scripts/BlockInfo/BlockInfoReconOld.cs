// using UnityEngine;

// public class BlockInfoRecon : MonoBehaviour
// {
//     public GameObject blockRecon; // Assign the block reconstruction in the Inspector
//     public GameObject pdfWindow; // Assign the PDF display panel in the Inspector

//     private bool isVisible = false;

//     void Start()
//     {
//         blockRecon.SetActive(false);   // Initially hide the block reconstruction
//         pdfWindow.SetActive(false);   // Initially hide the PDF window
//     }

//     public void ShowPDF()
//     {
//         isVisible = true;
//         blockRecon.SetActive(true);
//         pdfWindow.SetActive(true);
//     }

//     public void HidePDF()
//     {
//         isVisible = false;
//         blockRecon.SetActive(false);
//         pdfWindow.SetActive(false);
//     }

//     public void TogglePDF()
//     {
//         BlockManager.Instance.SetActiveBlock(this);
//     }
// }
