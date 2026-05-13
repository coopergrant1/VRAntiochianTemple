using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;


public class RespawnHold : MonoBehaviour
{
    [Header("Input")]
    public InputActionProperty respawnAction;

    [Header("UI")]
    public GameObject respawnUI;
    public Image radialFill;

    [Header("Settings")]
    public float holdTime = 2f;

    private float holdTimer = 0f;
    private bool isHolding = false;

    void OnEnable() => respawnAction.action.Enable();
    void OnDisable() => respawnAction.action.Disable();

    void Start()
{
    if (respawnUI != null) respawnUI.SetActive(false);
    if (radialFill != null)
    {
        radialFill.fillAmount = 0f;
        
        // Force UI to always render on top
        radialFill.material.SetInt("unity_GUIZTestMode", (int)CompareFunction.Always);
    }

    // Also apply to any other Image components in the RespawnUI
    if (respawnUI != null)
    {
        foreach (Image img in respawnUI.GetComponentsInChildren<Image>())
        {
            img.material = new Material(img.material); // instance the material
            img.material.SetInt("unity_GUIZTestMode", (int)CompareFunction.Always);
        }
    }
}

    void Update()
    {
        float triggerValue = respawnAction.action.ReadValue<float>();

        if (triggerValue > 0.1f)
        {
            if (!isHolding)
            {
                isHolding = true;
                holdTimer = 0f;
                if (respawnUI != null) respawnUI.SetActive(true);
            }

            holdTimer += Time.deltaTime;
            if (radialFill != null)
                radialFill.fillAmount = Mathf.SmoothStep(0f, 1f, holdTimer / holdTime);

            if (holdTimer >= holdTime)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            if (isHolding) ResetHold();
        }
    }

    void ResetHold()
    {
        holdTimer = 0f;
        isHolding = false;
        if (radialFill != null) radialFill.fillAmount = 0f;
        if (respawnUI != null) respawnUI.SetActive(false);
    }
}