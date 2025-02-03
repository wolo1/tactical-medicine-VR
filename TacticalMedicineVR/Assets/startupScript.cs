using UnityEngine;

public class startupScript : MonoBehaviour
{
    public static OVRCameraRig ovr;

    void Awake()
    {
        ovr = FindObjectOfType<OVRCameraRig>();
    }
}
