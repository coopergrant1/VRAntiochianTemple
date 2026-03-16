using UnityEngine;
using FlexXR.Runtime.FlexXRPanel;

public class panelOpener : MonoBehaviour
{
    [Header("FlexXR Panel")]
    public FlexXRPanelManager panelManager; // Assign your FlexXR panel manager

    [Header("Left Controller")]
    public Transform leftController;        // Assign your left hand controller

    [Header("Panel Settings")]
    public Vector3 localPosition = new Vector3(0.1f, 0f, 0.15f);
    public Vector3 localRotationEuler = Vector3.zero;
    public float worldContentScale = 0.15f;

    void Start()
    {
        if (panelManager == null)
        {
            Debug.LogError("PanelManager not assigned!");
            return;
        }

        if (leftController == null)
        {
            Debug.LogError("LeftController not assigned!");
            return;
        }

        // Delay one frame to let FlexXR initialize properly
        StartCoroutine(ActivatePanelNextFrame());
    }

    System.Collections.IEnumerator ActivatePanelNextFrame()
    {
        yield return null; // wait one frame

        // 1️⃣ Set interaction mode to World → activates World Content
        panelManager.runtimeSettings.interactionMode = InteractionMode.World;

        // 2️⃣ Scale World Content
        var worldContent = panelManager.transform.Find("World Content");
        if (worldContent != null)
        {
            worldContent.localScale = Vector3.one * worldContentScale;
        }
        else
        {
            Debug.LogError("World Content not found under FlexXRPanel!");
        }

        // 3️⃣ Parent panel to left controller
        panelManager.transform.SetParent(leftController);
        panelManager.transform.localPosition = localPosition;
        panelManager.transform.localRotation = Quaternion.Euler(localRotationEuler);
    }
}
