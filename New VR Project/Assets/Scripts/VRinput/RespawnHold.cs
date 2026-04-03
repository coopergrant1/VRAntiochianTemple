using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class RespawnHold : MonoBehaviour
{
    [Header("Input")]
    public InputActionProperty respawnAction; // Your custom "RespawnHold" action

    [Header("UI")]
    public GameObject respawnUI;   // Parent UI object (enable/disable)
    public Image radialFill;       // Image with Radial 360 fill

    [Header("XR References")]
    public Transform xrOrigin;     // XR Origin (player root)
    public Transform cameraOffset; // Camera Offset (child of XR Origin)
    public Transform spawnPoint;   // Respawn location

    [Header("Settings")]
    public float holdTime = 2f;

    private float holdTimer = 0f;
    private bool isHolding = false;

    void OnEnable()
    {
        respawnAction.action.Enable();
    }

    void OnDisable()
    {
        respawnAction.action.Disable();
    }

    void Start()
    {
        if (respawnUI != null)
            respawnUI.SetActive(false);

        if (radialFill != null)
            radialFill.fillAmount = 0f;
    }

    void Update()
    {
        float triggerValue = respawnAction.action.ReadValue<float>();

        // HOLDING TRIGGER
        if (triggerValue > 0.1f)
        {
            if (!isHolding)
            {
                isHolding = true;
                holdTimer = 0f;

                if (respawnUI != null)
                    respawnUI.SetActive(true);
            }

            holdTimer += Time.deltaTime;

            float progress = holdTimer / holdTime;

            // Smooth fill (looks nicer than linear)
            float smoothProgress = Mathf.SmoothStep(0f, 1f, progress);

            if (radialFill != null)
                radialFill.fillAmount = smoothProgress;

            if (holdTimer >= holdTime)
            {
                Respawn();
                ResetHold();
            }
        }
        else
        {
            // RELEASE EARLY → CANCEL
            if (isHolding)
            {
                ResetHold();
            }
        }
    }

    void Respawn()
    {
        if (xrOrigin == null || spawnPoint == null) return;

        // Correct XR repositioning (prevents camera offset issues)
        Vector3 cameraLocalOffset = cameraOffset.localPosition;

        xrOrigin.position = spawnPoint.position - cameraLocalOffset;
        xrOrigin.rotation = spawnPoint.rotation;
    }

    void ResetHold()
    {
        holdTimer = 0f;
        isHolding = false;

        if (radialFill != null)
            radialFill.fillAmount = 0f;

        if (respawnUI != null)
            respawnUI.SetActive(false);
    }
}