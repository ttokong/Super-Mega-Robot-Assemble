using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform cam;

    void Start()
    {
        // finds gameobject using its name and converting it to transform
        cam = GameObject.Find("Main Camera").transform;
    }

    // lateupdate is called after the camera has done its movement so using this lateupdate prevents the updates to be jittery sometimes
    void LateUpdate()
    {
        // points the billboard in the same direction as the camera
        // transform.LookAt(transform.position + cam.forward);

        transform.LookAt(transform.position + cam.forward);
    }
}
