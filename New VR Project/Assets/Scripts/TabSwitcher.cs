using UnityEngine;

public class TabSwitcher : MonoBehaviour
{
    public GameObject overviewPage;
    public GameObject galleryPage;

    public void ShowOverview()
    {
        overviewPage.SetActive(true);
        galleryPage.SetActive(false);
    }

    public void ShowGallery()
    {
        overviewPage.SetActive(false);
        galleryPage.SetActive(true);
    }
}
