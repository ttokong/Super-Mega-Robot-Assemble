using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    #region Singleton

    public static PlayerManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public int players;

    public GameObject[] playerPrefabs;


    public void AllocatePlayers()
    {
        for (int i = 0; i < players; i++)
        {
            LevelManager.instance.SpawnPlayer(i);   
        }
    }
}
