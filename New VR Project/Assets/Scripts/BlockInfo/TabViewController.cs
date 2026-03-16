using UnityEngine;
using UnityEngine.UIElements;

public class TabController : MonoBehaviour
{
    public VisualTreeAsset uxml;

    private Button overviewTab, placementTab, galleryTab;
    private VisualElement overviewPage, placementPage, galleryPage;
    private VisualElement root;

    void OnEnable()
    {
        // Load UXML
        var panel = GetComponent<UIDocument>();
        root = panel.rootVisualElement;

        // Find tabs
        overviewTab = root.Q<Button>("overview-tab");
        galleryTab = root.Q<Button>("gallery-tab");

        // Find pages
        overviewPage = root.Q<VisualElement>("overview-page");
        galleryPage = root.Q<VisualElement>("gallery-page");

        // Add click events
        overviewTab.clicked += () => ShowPage(overviewTab, overviewPage);
        galleryTab.clicked += () => ShowPage(galleryTab, galleryPage);

        // Show default page
        ShowPage(overviewTab, overviewPage);
    }

    void AddVRClick(VisualElement element, System.Action callback)
    {
        // Use pointer events instead of Button.clicked
        element.RegisterCallback<PointerDownEvent>(evt =>
        {
            callback?.Invoke();
        });
    }
    void ShowPage(Button selectedTab, VisualElement selectedPage)
    {
        // Toggle tab classes
        overviewTab.RemoveFromClassList("selected");
        galleryTab.RemoveFromClassList("selected");
        selectedTab.AddToClassList("selected");

        // Toggle page visibility
        overviewPage.AddToClassList("hidden");
        galleryPage.AddToClassList("hidden");

        overviewPage.RemoveFromClassList("visible");
        galleryPage.RemoveFromClassList("visible");

        selectedPage.AddToClassList("visible");
        selectedPage.RemoveFromClassList("hidden");
    }
}
