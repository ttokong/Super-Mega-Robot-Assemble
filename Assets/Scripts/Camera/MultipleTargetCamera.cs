using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleTargetCamera : MonoBehaviour
{
    // list of targets we want the camera to follow
    public List<Transform> targets;

    public Vector3 offset;

    // lateupdate is called after the camera has done its movement so using this lateupdate prevents the updates to be jittery sometimes
    void LateUpdate()
    {
        // returns if there are no targets to prevent error
        if (targets.Count == 0)
            return;

        // center of all targets
        Vector3 centerPoint = GetCenterPoint();

        Vector3 newPosition = centerPoint + offset;

        transform.position = Vector3.Lerp(transform.position, newPosition,.05f);
    }

    Vector3 GetCenterPoint()
    {
        // if target is 1, no need to do calculation to find center point
        if (targets.Count == 1)
        {
            return targets[0].position;
        }
        
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            // resizes the bounds to fit all targets within the camera
            bounds.Encapsulate(targets[i].position);
        }

        // calculates the center point
        return bounds.center;
    }

}
