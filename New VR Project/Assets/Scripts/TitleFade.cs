using UnityEngine;
using System.Collections;

public class TitleFade : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float delay = 2f;
    public float fadeTime = 2f;

    void Start()
    {
        // canvasGroup.alpha = 0;
        // StartCoroutine(FadeInThenOut());
        StartCoroutine(FadeOut());

    }

    // void Update()
    // {
    //     if (Input.GetMouseButtonDown(0))
    //         gameObject.SetActive(false);
    // }

    // IEnumerator FadeInThenOut()
    // {
    //     float t = 0;
    //     while (t < 1f)
    //     {
    //         t += Time.deltaTime;
    //         canvasGroup.alpha = t;
    //         yield return null;
    //     }

    //     yield return new WaitForSeconds(delay);
    //     StartCoroutine(FadeOut());
    // }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(delay);

        float t = 0;
        while (t < fadeTime)
        {
            t += Time.deltaTime;
            canvasGroup.alpha = 1 - (t / fadeTime);
            yield return null;
        }

        canvasGroup.alpha = 0;
        gameObject.SetActive(false);   // Hide after fade
    }
}
