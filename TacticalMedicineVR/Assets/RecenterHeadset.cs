using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecenterHeadset : MonoBehaviour
{
    public Transform position;

    void Start()
    {
        RecenterHeadset1();
    }

    ///this works!
    public void RecenterHeadset1()
    {
        StartCoroutine(ResetCamera(position.position, 90f));
    }



    //Resets the OVRCameraRig's position and Y-axis rotation to help align the player's starting position and view to the target parameters
    IEnumerator ResetCamera(Vector3 targetPosition, float targetYRotation)
    {
        Transform _OVRCameraRig = startupScript.ovr.transform;
        Transform _centreEyeAnchor = startupScript.ovr.centerEyeAnchor;

        //EditorDebugOffset();
        yield return new WaitForEndOfFrame();
        float currentRotY = _centreEyeAnchor.eulerAngles.y;
        float difference = targetYRotation - currentRotY;
        _OVRCameraRig.Rotate(0, difference, 0);

        Vector3 newPos = new Vector3(targetPosition.x - _centreEyeAnchor.position.x, 0, targetPosition.z - _centreEyeAnchor.position.z);
        _OVRCameraRig.transform.position += newPos;
    }
}
