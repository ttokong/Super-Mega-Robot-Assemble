using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGroundSlam : MonoBehaviour
{
    public bool enraged = false;

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
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 0.15f);
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
        if (!enraged)
        {
            findingTarget = false;
            int invokeCount = slamDistance / interval;

            dir = (gameObject.GetComponent<BossBehaviour>().target.position - transform.position).normalized;

            GameObject[] slamExplosion = new GameObject[invokeCount];

            for (int i = 1; i < invokeCount; i++)
            {
                slamExplosion[i] = Instantiate(SlamEffect) as GameObject;
                FindObjectOfType<AudioManager>().Play("GroundSlam");
                StartCoroutine(cameraShake.Shake(0.4f, 1f)); // triggers camera shake with duration and magnitude

                Destroy(slamExplosion[i], 4.9f);

                float newInterval;

                newInterval = interval * i;

                slamExplosion[i].transform.position = transform.position + (dir * newInterval);
                yield return new WaitForSeconds(.2f);
            }
        }
        else if (enraged)
        {
            findingTarget = false;

            StartCoroutine(GroundSlamFront(slamIntervals));
            StartCoroutine(GroundSlamBack(slamIntervals));
            StartCoroutine(GroundSlamLeft(slamIntervals));
            StartCoroutine(GroundSlamLeftTop(slamIntervals));
            StartCoroutine(GroundSlamLeftBot(slamIntervals));
            StartCoroutine(GroundSlamRight(slamIntervals));
            StartCoroutine(GroundSlamRightTop(slamIntervals));
            StartCoroutine(GroundSlamRightBot(slamIntervals));
        }

        yield return new WaitForSeconds(1f);
        gameObject.GetComponent<BossBehaviour>().actionComplete = true;
        findingTarget = true;
        slamCheck = false;
    }

    IEnumerator GroundSlamFront(int interval)
    {
        int invokeCount = slamDistance / interval;

        dir = (gameObject.GetComponent<BossBehaviour>().target.position - transform.position).normalized;

        GameObject[] slamExplosion = new GameObject[invokeCount];

        for (int i = 1; i < invokeCount; i++)
        {
            slamExplosion[i] = Instantiate(SlamEffect) as GameObject;
            FindObjectOfType<AudioManager>().Play("GroundSlam");
            StartCoroutine(cameraShake.Shake(0.4f, 1f)); // triggers camera shake with duration and magnitude

            Destroy(slamExplosion[i], 4.9f);

            float newInterval;

            newInterval = interval * i;

            slamExplosion[i].transform.position = transform.position + (dir * newInterval);
            yield return new WaitForSeconds(.2f);
        }
    }

    IEnumerator GroundSlamBack(int interval)
    {
        int invokeCount = slamDistance / interval;

        dir = (gameObject.GetComponent<BossBehaviour>().target.position - transform.position).normalized;

        GameObject[] slamExplosion = new GameObject[invokeCount];

        for (int i = 1; i < invokeCount; i++)
        {
            slamExplosion[i] = Instantiate(SlamEffect) as GameObject;
            FindObjectOfType<AudioManager>().Play("GroundSlam");
            StartCoroutine(cameraShake.Shake(0.4f, 1f)); // triggers camera shake with duration and magnitude

            Destroy(slamExplosion[i], 4.9f);

            float newInterval;

            newInterval = interval * i;

            slamExplosion[i].transform.position = transform.position + (-dir * newInterval);
            yield return new WaitForSeconds(.2f);
        }
    }

    IEnumerator GroundSlamLeft(int interval)
    {
        int invokeCount = slamDistance / interval;

        dir = (gameObject.GetComponent<BossBehaviour>().target.position - transform.position).normalized;

        GameObject[] slamExplosion = new GameObject[invokeCount];

        for (int i = 1; i < invokeCount; i++)
        {
            slamExplosion[i] = Instantiate(SlamEffect) as GameObject;
            FindObjectOfType<AudioManager>().Play("GroundSlam");
            StartCoroutine(cameraShake.Shake(0.4f, 1f)); // triggers camera shake with duration and magnitude

            Destroy(slamExplosion[i], 4.9f);

            float newInterval;

            newInterval = interval * i;

            slamExplosion[i].transform.position = transform.position + (Quaternion.Euler(0, -90, 0) * dir * newInterval);
            yield return new WaitForSeconds(.2f);
        }
    }

    IEnumerator GroundSlamLeftTop(int interval)
    {
        int invokeCount = slamDistance / interval;

        dir = (gameObject.GetComponent<BossBehaviour>().target.position - transform.position).normalized;

        GameObject[] slamExplosion = new GameObject[invokeCount];

        for (int i = 1; i < invokeCount; i++)
        {
            slamExplosion[i] = Instantiate(SlamEffect) as GameObject;
            FindObjectOfType<AudioManager>().Play("GroundSlam");
            StartCoroutine(cameraShake.Shake(0.4f, 1f)); // triggers camera shake with duration and magnitude

            Destroy(slamExplosion[i], 4.9f);

            float newInterval;

            newInterval = interval * i;

            slamExplosion[i].transform.position = transform.position + (Quaternion.Euler(0, -45, 0) * dir * newInterval);
            yield return new WaitForSeconds(.2f);
        }
    }

    IEnumerator GroundSlamLeftBot(int interval)
    {
        int invokeCount = slamDistance / interval;

        dir = (gameObject.GetComponent<BossBehaviour>().target.position - transform.position).normalized;

        GameObject[] slamExplosion = new GameObject[invokeCount];

        for (int i = 1; i < invokeCount; i++)
        {
            slamExplosion[i] = Instantiate(SlamEffect) as GameObject;
            FindObjectOfType<AudioManager>().Play("GroundSlam");
            StartCoroutine(cameraShake.Shake(0.4f, 1f)); // triggers camera shake with duration and magnitude

            Destroy(slamExplosion[i], 4.9f);

            float newInterval;

            newInterval = interval * i;

            slamExplosion[i].transform.position = transform.position + (Quaternion.Euler(0, -135, 0) * dir * newInterval);
            yield return new WaitForSeconds(.2f);
        }
    }

    IEnumerator GroundSlamRight(int interval)
    {
        int invokeCount = slamDistance / interval;

        Vector3 right = Quaternion.AngleAxis(-90, dir) * dir.normalized;

        GameObject[] slamExplosion = new GameObject[invokeCount];

        for (int i = 1; i < invokeCount; i++)
        {
            slamExplosion[i] = Instantiate(SlamEffect) as GameObject;
            FindObjectOfType<AudioManager>().Play("GroundSlam");
            StartCoroutine(cameraShake.Shake(0.4f, 1f)); // triggers camera shake with duration and magnitude

            Destroy(slamExplosion[i], 4.9f);

            float newInterval;

            newInterval = interval * i;

            slamExplosion[i].transform.position = transform.position + (Quaternion.Euler(0, 90, 0) * dir * newInterval);
            yield return new WaitForSeconds(.2f);
        }
    }

    IEnumerator GroundSlamRightTop(int interval)
    {
        int invokeCount = slamDistance / interval;

        dir = (gameObject.GetComponent<BossBehaviour>().target.position - transform.position).normalized;

        GameObject[] slamExplosion = new GameObject[invokeCount];

        for (int i = 1; i < invokeCount; i++)
        {
            slamExplosion[i] = Instantiate(SlamEffect) as GameObject;
            FindObjectOfType<AudioManager>().Play("GroundSlam");
            StartCoroutine(cameraShake.Shake(0.4f, 1f)); // triggers camera shake with duration and magnitude

            Destroy(slamExplosion[i], 4.9f);

            float newInterval;

            newInterval = interval * i;

            slamExplosion[i].transform.position = transform.position + (Quaternion.Euler(0, 45, 0) * dir * newInterval);
            yield return new WaitForSeconds(.2f);
        }
    }

    IEnumerator GroundSlamRightBot(int interval)
    {
        int invokeCount = slamDistance / interval;

        dir = (gameObject.GetComponent<BossBehaviour>().target.position - transform.position).normalized;

        GameObject[] slamExplosion = new GameObject[invokeCount];

        for (int i = 1; i < invokeCount; i++)
        {
            slamExplosion[i] = Instantiate(SlamEffect) as GameObject;
            FindObjectOfType<AudioManager>().Play("GroundSlam");
            StartCoroutine(cameraShake.Shake(0.4f, 1f)); // triggers camera shake with duration and magnitude

            Destroy(slamExplosion[i], 4.9f);

            float newInterval;

            newInterval = interval * i;

            slamExplosion[i].transform.position = transform.position + (Quaternion.Euler(0, 135, 0) * dir * newInterval);
            yield return new WaitForSeconds(.2f);
        }
    }

    IEnumerator LockOn()
    {
        slamCheck = true;
        gameObject.GetComponent<BossBehaviour>().agent.isStopped = true;
        yield return new WaitForSeconds(3f);
        StartCoroutine(Slamming(slamIntervals));
    }
}
