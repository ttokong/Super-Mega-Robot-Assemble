using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public GameObject groundExplosion;
    public Transform target;
    public GameObject firepoint;
    public LineRenderer laserLineRenderer;
    public float laserWidth = 0.1f;
    public float laserMaxLength = 5f;

    public float skillCd;
    private float cd = 0;

    void Start()
    {
        cd = skillCd;
        Vector3[] initLaserPositions = new Vector3[2] { Vector3.zero, Vector3.zero };
        laserLineRenderer.SetPositions(initLaserPositions);

        laserLineRenderer.startWidth = laserWidth;
        laserLineRenderer.endWidth = laserWidth;
        laserLineRenderer.positionCount = 2;
    }

    void Update()
    {
        cd += Time.deltaTime;
    }


    IEnumerator LaserCo()
    {
        laserLineRenderer.enabled = true;
        yield return new WaitForSeconds(2f);
        laserLineRenderer.enabled = false;
        FindObjectOfType<AudioManager>().Play("RobotLaser");
        GameObject effect = Instantiate(groundExplosion, target.position, Quaternion.identity);
        Destroy(effect, 5f);
        cd = 0;
    }

    public void ShootBeam()
    {
        if (cd >= skillCd)
        {
            StartCoroutine(LaserCo());
        }
    }

    public void ShootLaserFromTargetPosition(Vector3 targetPosition, Vector3 direction, float length)
    {
        Ray ray = new Ray(targetPosition, direction);
        RaycastHit raycastHit;
        Vector3 endPosition = targetPosition + (length * direction);

        if (Physics.Raycast(ray, out raycastHit, length))
        {
            endPosition = raycastHit.point;
        }

        laserLineRenderer.SetPosition(0, targetPosition);
        laserLineRenderer.SetPosition(1, endPosition);
    }
}
