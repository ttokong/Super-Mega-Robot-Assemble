using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MultipleTargetCamera : MonoBehaviour
{
    // list of targets we want the camera to follow
    public List<Transform> targets;

    public Vector3 offset;
    public Vector3 newPosition;

    float minZoom = 50f;
    float maxZoom = 25f;
    float zoomLimiter = 150f;

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // lateupdate is called after the camera has done its movement so using this lateupdate prevents the updates to be jittery sometimes
    void LateUpdate()
    {
        // returns if there are no targets to prevent error
        if (targets.Count == 0)
            return;

        Move();
        Zoom();
    }

    void Move()
    {
        // center of all targets
        Vector3 centerPoint = GetCenterPoint();

        newPosition = centerPoint + offset;

        // moves the camera
        transform.position = Vector3.Lerp(transform.position, newPosition, 0.3f);
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

    void Zoom()
    {
        // calculates the zoom within max and min depending on the greatest distance between the targets
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / zoomLimiter); // divided by zoomLimiter which is the max distance between targets
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime); // updates the cam's FOV
    }

    float GetGreatestDistance()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        // saves the width of the box that fits all target as a variable
        return bounds.size.x;
    }

}
