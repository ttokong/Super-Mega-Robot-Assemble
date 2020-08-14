using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{

    [SerializeField]
    private GameObject[] readyPanel;

    [SerializeField]
    private Text waitingForPlayers;


    //public GameObject[] playerprefabs;

    public GameObject[] Layouts;

    public bool[] CharactersSelectCheck;

    public void SelectCharacter(bool inputEnabled, int playerIndex, int characterID)
    {
        if (!inputEnabled) { return; }

        PlayerManager.instance.SetPlayerCharacter(playerIndex, characterID);
        //PlayerManager.instance.SetPlayerPrefab(PlayerIndex, playerprefabs[SelectedCharacter]);
        readyPanel[characterID].SetActive(true);
    }

    public void ReadyPlayer(bool inputEnabled, int playerIndex, int characterID)
    {
        if (!inputEnabled) { return; }

        waitingForPlayers.text = "Waiting for Players " + (playerIndex + 1) + "/" + PlayerManager.instance.MaxPlayers;
        PlayerManager.instance.ReadyPlayer(playerIndex);

    }
    
    public void CancelSelection(bool inputEnabled, int playerIndex, int characterID)
    {
        if (!inputEnabled) { return; }

        PlayerManager.instance.UnreadyPlayer(playerIndex);
        readyPanel[characterID].SetActive(false);
    }

    /*
    if (PlayerInfo.instance !=null)
    {
        PlayerInfo.instance.mySelectedCharacter = whichCharacter;
        PlayerPrefs.SetInt("MyCharacter", whichCharacter);
    }*/
}
