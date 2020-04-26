using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public float TeamUltimate;

    #region Singleton

    // static makes this -buildmanager- accessible from any other script
    public static GameManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one Game Manager in scene!");
            Destroy(gameObject);
        }
        // references instance to GameManager
        instance = this;
    }

    #endregion
}
