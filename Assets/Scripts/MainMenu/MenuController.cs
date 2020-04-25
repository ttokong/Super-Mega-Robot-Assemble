using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{

    public void OnClickCharacterPick(int whichCharacter)
    {
        if (PlayerInfo.instance !=null)
        {
            PlayerInfo.instance.mySelectedCharacter = whichCharacter;
            PlayerPrefs.SetInt("MyCharacter", whichCharacter);
        }
    }
}
