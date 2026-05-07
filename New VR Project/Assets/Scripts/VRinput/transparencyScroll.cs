using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;

public class TransparencyGrip : MonoBehaviour
{
    public InputActionReference gripActionReference;

    public GameObject templeObj;
    public Material opaqueMaterial;
    public Material transparentMaterial;
    private Renderer[] tempRenderers;
    private bool isTransparent = false;    
    void Start()
    {
        if (templeObj != null)
        {
            tempRenderers = templeObj.GetComponentsInChildren<Renderer>();
            foreach (Renderer r in tempRenderers)
            {
                r.material = opaqueMaterial;
            }
        }
    }

    void Update()
    {
        if (gripActionReference == null || gripActionReference.action == null)
            return;

        float grip = gripActionReference.action.ReadValue<float>();
        bool turnTransparent = grip > 0.5f;
        if (turnTransparent && !isTransparent)
        {
            isTransparent = turnTransparent;
            foreach (Renderer r in tempRenderers)
            {
                r.material = transparentMaterial;
            }
        }
        else if (!turnTransparent && isTransparent)
        {
            isTransparent = turnTransparent;
            foreach (Renderer r in tempRenderers)
            {
                r.material = opaqueMaterial;
            }
        }

        // if (gripActionReference.action.WasPerformedThisFrame())
        // {
        //     isTransparent = !isTransparent;
        //     foreach (Renderer r in tempRenderers)
        //     {
        //         r.material = isTransparent ? transparentMaterial : opaqueMaterial;
        //     }
        // }
    }
}