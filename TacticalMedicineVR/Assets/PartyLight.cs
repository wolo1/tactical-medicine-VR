using UnityEngine;

public class PartyLight : MonoBehaviour
{
    public Light partyLight;
    public Color[] colors; // Array of colors assigned from Inspector
    public float colorChangeInterval = 40f; // Time in seconds for each color change
    public float blinkInterval = 1f; // Time in seconds between blinks

    private int currentColorIndex = 0;
    private float colorChangeTimer = 0f;
    private float blinkTimer = 0f;

    void Start()
    {
        if (colors.Length > 0)
        {
            partyLight.color = colors[currentColorIndex]; // Set initial color
        }
    }

    void Update()
    {
        // Handle color change every 40 seconds
        colorChangeTimer += Time.deltaTime;
        if (colorChangeTimer >= colorChangeInterval)
        {
            currentColorIndex = (currentColorIndex + 1) % colors.Length; // Cycle through colors
            partyLight.color = colors[currentColorIndex]; // Apply new color
            colorChangeTimer = 0f; // Reset timer
        }

        // Handle blinking effect every 1 second
        blinkTimer += Time.deltaTime;
        if (blinkTimer >= blinkInterval)
        {
            partyLight.enabled = !partyLight.enabled; // Toggle light on/off
            blinkTimer = 0f; // Reset blink timer
        }
    }
}
