using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGroundSlam : MonoBehaviour
{
    private Vector3 dir;
    private bool slamCheck = false;
    public int slamDistance;
    public int slamIntervals;
    private bool findingTarget = true;
    private CameraShake cameraShake;

    public GameObject SlamEffect;

    private void Start()
    {
        cameraShake = GameObject.Find("CameraHolder/Main Camera").GetComponent<CameraShake>();
    }

    public void Slam()
    {
        if (findingTarget)
        {
            dir = (gameObject.GetComponent<BossBehaviour>().target.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 0.15F);
        }
        else if (findingTarget == false)
        {
            transform.rotation = Quaternion.LookRotation(dir);
        }

        if (slamCheck == false)
        {
            StartCoroutine(LockOn());
        }


    }


    public IEnumerator Slamming(int interval)
    {
        findingTarget = false;
        int invokeCount = slamDistance / interval;

        dir = (gameObject.GetComponent<BossBehaviour>().target.position - transform.position).normalized;

        GameObject[] slamExplosion = new GameObject[invokeCount];

        for (int i = 1; i < invokeCount; i++)
        {
            slamExplosion[i] = Instantiate(SlamEffect) as GameObject;
            FindObjectOfType<AudioManager>().Play("GroundSlam");
            StartCoroutine(cameraShake.Shake(.15f , .2f));              // triggers camera shake with duration and magnitude

            Destroy(slamExplosion[i], 4.9f);

            float newInterval;

            newInterval = interval * i;


            slamExplosion[i].transform.position = transform.position + (dir * newInterval);
            yield return new WaitForSeconds(.2f);
        }

        yield return new WaitForSeconds(1f);
        gameObject.GetComponent<BossBehaviour>().actionComplete = true;
        findingTarget = true;
        slamCheck = false;
    }

    IEnumerator LockOn()
    {
        slamCheck = true;
        gameObject.GetComponent<BossBehaviour>().agent.isStopped = true;
        yield return new WaitForSeconds(3f);
        StartCoroutine(Slamming(slamIntervals));
    }
}
