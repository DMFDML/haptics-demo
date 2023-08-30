using UnityEngine; // Access Unity API

public class Button1Controller : MonoBehaviour // Inherit from MonoBehaviour
{
    // Assign these in the Inspector
    public Transform chuckTransform;
    public Material activeMaterial;
    public Material originalMaterial;

    // Private variables
    private bool button1Activated = false; // Button 1 state
    private Renderer chuckRenderer; // Chuck renderer component

    private void Start() // Start is called before the first frame update
    {
        // Get the chuck renderer component
        chuckRenderer = chuckTransform.GetComponent<Renderer>();
    }

    private void Update() // Update is called once per frame
    {
        if (button1Activated) // IF BUTTON 1 IS ACTIVATED
        {
            // %%%%% ADD YOUR CODE HERE %%%%%
            // e.g: Button 1 is activated, change material to activeMaterial
            chuckRenderer.material = activeMaterial;
        }
        else // IF BUTTON 1 IS DEACTIVATED
        {
            // %%%%% ADD YOUR CODE HERE %%%%%
            // e.g: Button 1 is deactivated, revert material to originalMaterial
            chuckRenderer.material = originalMaterial;
        }
    }

    public void SetButtonState(bool activated) // Set the button state
    {
        button1Activated = activated; // Set the button state
    }
}
