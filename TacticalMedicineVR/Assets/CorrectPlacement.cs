using UnityEngine;
using Oculus;

public class CorrectPlacement : MonoBehaviour
{

    public OVRCameraRig m_OVRCameraRig;


    void Start()
    {
        ResetPosition();
    }


    void ResetPosition()
    {
        float currentRotY = m_OVRCameraRig.centerEyeAnchor.eulerAngles.y;
        float targetRotY = 0.0f;
        float difference = targetRotY - currentRotY;
        m_OVRCameraRig.transform.Rotate(0, difference, 0);
        Vector3 currentPosition = m_OVRCameraRig.centerEyeAnchor.localPosition;
        m_OVRCameraRig.trackingSpace.localPosition = new Vector3(OffsetValue(currentPosition.x), OffsetValue(currentPosition.y), OffsetValue(currentPosition.z));
    }

    float OffsetValue(float value)
    {
        if (value != 0)
        {
            value *= -1;
        }
        return value;
    }
}
