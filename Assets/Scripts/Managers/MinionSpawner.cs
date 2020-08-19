using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionSpawner : MonoBehaviour
{
    ObjectPooler objectPooler;

    public int xPos;
    public int zPos;
    public static int minionCount;
    public static float minionSpawnRate = 3f;

    bool minionSpawningCalled = false;

    // Start is called before the first frame update
    private void Start()
    {

        objectPooler = ObjectPooler.instance;
    }

    private void Update()
    {
        if (!minionSpawningCalled)
        {
            StartCoroutine(MinionSpawning());
        }
    }

    IEnumerator MinionSpawning()
    {
        if (minionCount < 15)
        {
            minionSpawningCalled = true;

            xPos = Random.Range(-60, 55);
            zPos = Random.Range(-75, 32);
            Vector3 newPos = new Vector3 (xPos, 2, zPos);

            objectPooler.SpawnFromPool("Minion", newPos, Quaternion.identity);

            minionCount++;

            yield return new WaitForSeconds(minionSpawnRate);

            minionSpawningCalled = false;
        }
    }

}
