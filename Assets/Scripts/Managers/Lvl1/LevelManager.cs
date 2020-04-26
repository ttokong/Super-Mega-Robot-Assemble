using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    #region Singleton

    public static LevelManager instance;

    private void OnEnable()
    {
        if(LevelManager.instance == null)
        {
            LevelManager.instance = this;
        }

    }

    #endregion

    public Transform[] spawnpoints;


}
