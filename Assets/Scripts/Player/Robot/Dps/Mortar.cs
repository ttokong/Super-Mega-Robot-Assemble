using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mortar : MonoBehaviour
{

    public GameObject targetArea;

    public int damage;
    public float gravityScale;

    public GameObject rockPrefab;
    public Transform firePoint;
    public float shootAngle;

    public float skillCd;
    private float cd = 0;


    void Start()
    {
        cd = skillCd;
        Physics.gravity = new Vector3(0, gravityScale, 0);
    }

    Vector3 CalcBallisticVelocityVector(Transform firePoint, Transform targetArea, float angle)
    {
        Vector3 direction = targetArea.position - firePoint.position;            // get target direction
        float h = direction.y;                                            // get height difference
        direction.y = 30;//0;                                                // remove height
        float distance = direction.magnitude;                            // get horizontal distance
        float a = angle * Mathf.Deg2Rad;                                // Convert angle to radians
        direction.y = distance * Mathf.Tan(a);                            // Set direction to elevation angle
        distance += h; /*/ Mathf.Tan(a);*/                                        // Correction for small height differences

        // calculate velocity
        float velocity = Mathf.Sqrt(distance * Physics.gravity.magnitude / Mathf.Sin(2 * a));
        return velocity * direction.normalized;

    }

    void Update()
    {
        Physics.gravity = new Vector3(0, gravityScale, 0);
        cd += Time.deltaTime;
    }

    public void Shoot()
    {
        if (cd >= skillCd)
        {
            RPC_LaunchMortar();  
        }
    }

    void RPC_LaunchMortar()
    {
        FindObjectOfType<AudioManager>().Play("RobotDPS");
        GameObject rock = Instantiate(rockPrefab, firePoint.position, firePoint.rotation) as GameObject;
        rock.GetComponent<Rigidbody>().velocity = CalcBallisticVelocityVector(firePoint, targetArea.transform, shootAngle);
        rock.GetComponent<MortarBullet>().dmg = damage; 
        cd = 0;
    }
}



