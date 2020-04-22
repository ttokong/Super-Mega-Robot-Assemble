using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    #region Singleton

    public static LevelManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public Transform[] spawnpoints;

    public GameObject[] playersOnScene;


    private void Start()
    {
        playersOnScene = new GameObject[4];
        PlayerManager.instance.AllocatePlayers();
    }


    public void SpawnPlayer(int playerid)
    {
        GameObject playerSpawned = (GameObject)Instantiate(PlayerManager.instance.playerPrefabs[playerid], spawnpoints[playerid].position, transform.rotation);
        playersOnScene[playerid] = playerSpawned;
    }
}
