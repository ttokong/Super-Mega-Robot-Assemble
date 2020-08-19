using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    //public Transform cam;
    MultipleTargetCamera multipleTargetCamera;
    Vector3 offset;
    Vector3 cameraVector;

    float newPosX;
    float newPosY;
    float newPosZ;

    float offsetX;
    float offsetY;
    float offsetZ;

    void Start()
    {
        multipleTargetCamera = GetComponent<MultipleTargetCamera>();
        offset = multipleTargetCamera.offset;

        offsetX = offset.x;
        offsetY = offset.y;
        offsetZ = offset.z;
    }

    void Update()
    {
        cameraVector = new Vector3(multipleTargetCamera.newPosition.x, multipleTargetCamera.newPosition.y, multipleTargetCamera.newPosition.z);

        newPosX = cameraVector.x;
        newPosY = cameraVector.y;
        newPosZ = cameraVector.z;
    }

    // magnitude is the strength of the shake
    public IEnumerator Shake (float duration, float magnitude)
    {
        // stores OG position of camera
        // Vector3 originalPos = transform.position;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(newPosX - 1f, newPosX + 1f) * magnitude;
            float y = (newPosY);
            float z = Random.Range(newPosZ - 1f, newPosZ + 1f) * magnitude;

            transform.position = new Vector3(x, y, z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        // resets camera position
        transform.position = cameraVector;
    }
}
