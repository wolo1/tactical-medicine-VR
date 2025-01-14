using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMA.PoseTools;

public class PainExpressionAnimator : MonoBehaviour
{
    private ExpressionPlayer expression;
    private bool isAnimating = false;

    [Header("Animation Settings")]
    public float speed = 1.0f; // Speed of the animation
    public float amplitude = 0.1f; // How much the expression parameters change

    void Start()
    {
        expression = GetComponent<ExpressionPlayer>();
        if (expression != null)
        {
            isAnimating = true;
        }
        else
        {
            Debug.LogError("ExpressionPlayer component not found on the GameObject.");
        }
    }

    void Update()
    {
        if (isAnimating)
        {
            AnimatePainExpression();
        }
    }

    private void AnimatePainExpression()
    {
        float time = Time.time * speed;

        // Modulate the dynamic expressions
        expression.midBrowUp_Down = Mathf.Clamp(0.8f + Mathf.Sin(time * 0.9f) * amplitude, -1f, 1f); // Furrowed brow
        expression.leftBrowUp_Down = Mathf.Clamp(-0.5f + Mathf.Cos(time * 1.1f) * amplitude, -1f, 1f); // Raised inner brow
        expression.rightBrowUp_Down = Mathf.Clamp(-0.5f + Mathf.Sin(time * 1.2f) * amplitude, -1f, 1f); // Raised inner brow

        expression.mouthNarrow_Pucker = Mathf.Clamp(-0.3f + Mathf.Sin(time * 1.4f) * amplitude, -1f, 1f); // Slight narrowing animation
        expression.jawOpen_Close = Mathf.Clamp(0.3f + Mathf.Cos(time * 1.6f) * amplitude, -1f, 1f); // Subtle jaw motion
        expression.noseSneer = Mathf.Clamp(0.2f + Mathf.Sin(time * 1.2f) * amplitude, -1f, 1f); // Subtle nose wrinkle

        expression.leftEyeOpen_Close = Mathf.Clamp(0.4f + Mathf.Cos(time * 1.8f) * amplitude, -1f, 1f); // Subtle eye squint
        expression.rightEyeOpen_Close = Mathf.Clamp(0.4f + Mathf.Sin(time * 1.9f) * amplitude, -1f, 1f); // Subtle eye squint

        // Simplified up-down movement for lips
        float lipOffset = Mathf.Sin(time) * amplitude; // Smooth up-down motion
        expression.rightUpperLipUp_Down = Mathf.Clamp(0.5f + lipOffset, -1f, 1f); // Upper lip up-down
        expression.leftUpperLipUp_Down = Mathf.Clamp(0.5f + lipOffset, -1f, 1f); // Upper lip up-down
        expression.rightLowerLipUp_Down = Mathf.Clamp(0.3f - lipOffset, -1f, 1f); // Lower lip up-down (inverted)
        expression.leftLowerLipUp_Down = Mathf.Clamp(0.3f - lipOffset, -1f, 1f); // Lower lip up-down (inverted)

        // Static expressions
        expression.leftMouthSmile_Frown = Mathf.Clamp(-0.6f, -1f, 1f); // Static frown
        expression.rightMouthSmile_Frown = Mathf.Clamp(-0.6f, -1f, 1f); // Static frown
    }
}
