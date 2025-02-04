using UnityEngine;

public class ColorTransitionLoop : MonoBehaviour
{
    public Material material; // The material of the object
    public float transitionDuration = 2.0f; // Duration of the color transition

    private Color startColor = new Color(0.678f, 0.847f, 0.902f, 1.0f); // Light blue (RGBA)
    private Color endColor = new Color(0.2f, 0.2f, 0.8f, 1.0f); // Dark blue (RGBA)
    private float transitionTime = 0.0f;
    private bool transitioningToEndColor = true;

    void Update()
    {
        transitionTime += Time.deltaTime;
        float t = Mathf.Clamp01(transitionTime / transitionDuration);

        if (transitioningToEndColor)
        {
            material.color = Color.Lerp(startColor, endColor, t);
            if (t >= 1.0f)
            {
                transitioningToEndColor = false;
                transitionTime = 0.0f; // Reset the time for reverse transition
            }
        }
        else
        {
            material.color = Color.Lerp(endColor, startColor, t);
            if (t >= 1.0f)
            {
                transitioningToEndColor = true;
                transitionTime = 0.0f; // Reset the time for forward transition
            }
        }
    }
}
