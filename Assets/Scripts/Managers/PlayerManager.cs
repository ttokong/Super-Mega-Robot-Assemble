using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public Toggle skipTutorial;

    private List<PlayerConfiguration> playerConfigs;

    public int MaxPlayers;

    #region Singleton

    public static PlayerManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance.gameObject);
            instance = this;
            DontDestroyOnLoad(instance);
            playerConfigs = new List<PlayerConfiguration>();
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(instance);
            playerConfigs = new List<PlayerConfiguration>();
        }
    }

    #endregion

    public List<PlayerConfiguration> GetPlayerConfigurations()
    {
        return playerConfigs;
    }

    public void SetPlayerCharacter(int index, int characterID)
    {
        playerConfigs[index].SelectedCharacter = characterID;
    }

    public void ActivateScript()
    {
        GetComponent<PlayerInputManager>().enabled = true;
    }

    public void ReadyPlayer (int index)
    {
        playerConfigs[index].IsReady = true;
        if (playerConfigs.Count == MaxPlayers && playerConfigs.All(p => p.IsReady == true))
        {
            if (skipTutorial.isOn == false)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else if (skipTutorial.isOn == true)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
            }
        }
    }

    public void UnreadyPlayer(int index)
    {
        playerConfigs[index].IsReady = false;
    }

    public void HandlePlayerJoin(PlayerInput pi)
    {
        Debug.Log("Player " + pi.playerIndex + " joined");
        if (!playerConfigs.Any(p => p.PlayerIndex == pi.playerIndex))
        {
            pi.transform.SetParent(transform);
            playerConfigs.Add(new PlayerConfiguration(pi));
        }
    }
}

public class PlayerConfiguration
{
    public PlayerConfiguration(PlayerInput pi)
    {
        PlayerIndex = pi.playerIndex;
        Input = pi;
    }
    public PlayerInput Input { get; set; }
    public int PlayerIndex { get; set; }
    public int SelectedCharacter { get; set; }
    public bool IsReady { get; set; }
}

