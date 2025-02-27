using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UMA.PoseTools;

public class PainExpressionAnimatorGirl : MonoBehaviour
{
    private ExpressionPlayer expression;
    [SerializeField]
    private bool isAnimating = false;
    [SerializeField]
    private bool isAnimatingBreathe = false;
    [SerializeField]
    private bool isAnimatingBreatheCalm = false;

    [Header("Animation Settings")]
    public float speed = 1.0f; // Speed of the animation
    public float speedJaw = 0.2f; // Speed of the animation
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
        else if (isAnimatingBreathe)
        {
            Breathing();
        }
        else if (isAnimatingBreatheCalm)
        {
            BreathingCalm();
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

    private void Breathing()
    {
        isAnimating = false; // Stop pain animation if breathing is active

        float time = Time.time * speed * 0.7f; // Adjusted breathing cycle speed
        float breathCycle = Mathf.Sin(time) * (amplitude * 0.5f); // Breathing up/down motion
        float tremble = Mathf.Sin(Time.time * 10f) * 0.05f; // Small trembling effect
        float lipPulse = Mathf.Sin(time * 2f) * 0.1f; // Faster lip motion for realism

        // Eyes slightly widened (for panic effect)
        expression.leftEyeOpen_Close = Mathf.Clamp(0.4f + breathCycle * 0.2f, -1f, 1f);
        expression.rightEyeOpen_Close = Mathf.Clamp(0.4f + breathCycle * 0.2f, -1f, 1f);

        // Eyebrows raised slightly (to look more scared)
        expression.leftBrowUp_Down = Mathf.Clamp(0.7f + tremble, -1f, 1f);
        expression.rightBrowUp_Down = Mathf.Clamp(0.7f + tremble, -1f, 1f);

        // 🔥 Improved Breathing Effect:

        // Smooth transition from 0.0 to 0.5 and back (jaw opening/closing)
        float jawMovement = Mathf.PingPong(Time.time * speedJaw * 0.5f, 0.5f);
        expression.jawOpen_Close = jawMovement;

        // Lips widen slightly on inhale, contract on exhale
        expression.rightMouthSmile_Frown = Mathf.Clamp(-0.4f + breathCycle * 0.3f, -1f, 1f);
        expression.leftMouthSmile_Frown = Mathf.Clamp(-0.4f + breathCycle * 0.3f, -1f, 1f);

        // Lips move outward slightly on inhale, inward on exhale
        expression.rightUpperLipUp_Down = Mathf.Clamp(0.6f + breathCycle * 0.3f + lipPulse, -1f, 1f);
        expression.leftUpperLipUp_Down = Mathf.Clamp(0.6f + breathCycle * 0.3f + lipPulse, -1f, 1f);
        expression.rightLowerLipUp_Down = Mathf.Clamp(-0.4f - breathCycle * 0.3f - lipPulse, -1f, 1f);
        expression.leftLowerLipUp_Down = Mathf.Clamp(-0.4f - breathCycle * 0.3f - lipPulse, -1f, 1f);

        // Lips tremble slightly for realism
        expression.rightMouthSmile_Frown += tremble * 0.5f;
        expression.leftMouthSmile_Frown += tremble * 0.5f;

    }

    private void BreathingCalm()
    {
        isAnimating = false; // Stop pain animation if breathing is active

        float time = Time.time * speed * 0.5f; // Slower, calmer breathing
        float breathCycle = Mathf.Sin(time) * (amplitude * 0.2f); // Subtle breathing motion
        float tremble = Mathf.Sin(Time.time * 12f) * 0.03f; // Slightly more trembling for nervousness
        float lipPulse = Mathf.Sin(time * 2f) * 0.05f; // Reduced lip motion

        // 👀 **Eyes slightly wider than neutral but not exaggerated**
        expression.leftEyeOpen_Close = Mathf.Clamp(0.3f + breathCycle * 0.15f, -1f, 1f);
        expression.rightEyeOpen_Close = Mathf.Clamp(0.3f + breathCycle * 0.15f, -1f, 1f);

        // 😟 **Eyebrows raised a bit higher to look more worried**
        expression.leftBrowUp_Down = Mathf.Clamp(0.4f + tremble, -1f, 1f);
        expression.rightBrowUp_Down = Mathf.Clamp(0.4f + tremble, -1f, 1f);

        // 🫣 **Jaw remains almost closed but trembles slightly**
        expression.jawOpen_Close = Mathf.Clamp(0.05f + breathCycle * 0.05f + tremble * 0.1f, 0f, 0.12f); // Slight shaking

        // 😬 **Mouth corners slightly pulled back in fear**
        expression.rightMouthSmile_Frown = Mathf.Clamp(-0.3f + breathCycle * 0.15f, -1f, 1f);
        expression.leftMouthSmile_Frown = Mathf.Clamp(-0.3f + breathCycle * 0.15f, -1f, 1f);

        // 👄 **Lips move slightly but remain mostly closed**
        expression.rightUpperLipUp_Down = Mathf.Clamp(0.15f + breathCycle * 0.1f, -1f, 1f);
        expression.leftUpperLipUp_Down = Mathf.Clamp(0.15f + breathCycle * 0.1f, -1f, 1f);
        expression.rightLowerLipUp_Down = Mathf.Clamp(-0.1f - breathCycle * 0.1f, -1f, 1f);
        expression.leftLowerLipUp_Down = Mathf.Clamp(-0.1f - breathCycle * 0.1f, -1f, 1f);

        // 😟 **Subtle trembling effect for realism**
        expression.rightMouthSmile_Frown += tremble * 0.3f;
        expression.leftMouthSmile_Frown += tremble * 0.3f;

    }



    public void activateBreathe()
    {
        isAnimating = false;
        isAnimatingBreathe = true;
    }


    public void activateBreatheCalm()
    {
        isAnimating = false;
        isAnimatingBreathe = false;

        isAnimatingBreatheCalm = true;
    }
}
