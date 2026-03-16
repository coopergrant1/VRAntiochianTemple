using UnityEngine;
using UnityEngine.UI;

public class VRCanvasRightController : MonoBehaviour
{
    public string displayText = "WELCOME";
    public int fontSize = 40;
    public Color fontColor = Color.white;

    private Text textComponent;

    void Start()
    {
        // Look for a Text component on this canvas
        textComponent = GetComponentInChildren<Text>();
        if (textComponent == null)
        {
            // Create a new Text if none exists
            GameObject textGO = new GameObject("RightHandText");
            textGO.transform.SetParent(transform);
            textGO.transform.localPosition = Vector3.zero;
            textGO.transform.localRotation = Quaternion.identity;

            RectTransform rt = textGO.AddComponent<RectTransform>();
            rt.sizeDelta = new Vector2(300, 100); // adjust size to your canvas

            textComponent = textGO.AddComponent<Text>();
            textComponent.alignment = TextAnchor.MiddleCenter;
            textComponent.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        }

        // Set text
        textComponent.text = displayText;
        textComponent.fontSize = fontSize;
        textComponent.color = fontColor;
    }
}
