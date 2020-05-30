using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{

    #region Singleton

    public static PlayerInfo instance;

    private void OnEnable()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if(PlayerInfo.instance != this)
            {
                Destroy(PlayerInfo.instance.gameObject);
                PlayerInfo.instance = this;
            }
        }
        DontDestroyOnLoad(this.gameObject);
    }

    #endregion

    public int mySelectedCharacter;

    public GameObject[] allCharacters;

    public GameObject[] allRobotParts;


    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("MyCharacter"))
        {
            mySelectedCharacter = PlayerPrefs.GetInt("MyCharacter");
        }
        else
        {
            mySelectedCharacter = 0;
            PlayerPrefs.SetInt("MyCharacter", mySelectedCharacter);

        }
    }
}
