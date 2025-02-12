using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UMA.PoseTools;

public class PainExpressionAnimatorGirl : MonoBehaviour
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

        expression.leftEyeOpen_Close = -1f;
        expression.rightEyeOpen_Close = -1f;

      
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
