using UnityEngine;

public class Button1Controller : MonoBehaviour
{
    public Transform chuckTransform;
    public Material activeMaterial; // Assign this in the Inspector
    public Material originalMaterial; // Assign this in the Inspector

    private bool button1Activated = false;
    private Renderer chuckRenderer;

    private void Start()
    {
        chuckRenderer = chuckTransform.GetComponent<Renderer>();
    }

    private void Update()
    {
        if (button1Activated)
        {
            // Button 1 is activated, change the material to activeMaterial
            chuckRenderer.material = activeMaterial;
        }
        else
        {
            // Button 1 is deactivated, revert the material to originalMaterial
            chuckRenderer.material = originalMaterial;
        }
    }

    public void SetButtonState(bool activated)
    {
        button1Activated = activated;
    }
}
