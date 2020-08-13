using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionSpawner : MonoBehaviour
{
    public GameObject minion;
    public int xPos;
    public int zPos;
    public int minionCount;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MinionSpawning());
    }

    IEnumerator MinionSpawning()
    {
        while (minionCount < 10)
        {
            xPos = Random.Range(-54, 54);
            zPos = Random.Range(-58, 45);
            Instantiate(minion, new Vector3(xPos, 0.01f, zPos), Quaternion.identity);
            minionCount++;
            yield return new WaitForSeconds(8f);
        }
    }

}
