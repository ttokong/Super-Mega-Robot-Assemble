using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class AvatarSetup : MonoBehaviour
{

    #region PhotonView

    [HideInInspector]
    public PhotonView PV;

    #endregion

    public GameObject myCharacter;
    public GameObject myRobotPart;
    public int characterValue;

    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        if (PV.IsMine)
        {
            PV.RPC("RPC_AddCharacter", RpcTarget.AllBuffered, PlayerInfo.instance.mySelectedCharacter);
        }
        
    }

    [PunRPC]
    void RPC_AddCharacter(int whichCharacter)
    {
        characterValue = whichCharacter;
        myCharacter = Instantiate(PlayerInfo.instance.allCharacters[whichCharacter], transform.position, transform.rotation, transform);
    }

    /*[PunRPC]
    void RPC_AddRobotPart()
    {
        if(characterValue == 0)
        {
            myRobotPart = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Torso"),
            LevelManager.instance.robotSpawnPoints[0].position, Quaternion.identity);
        }
        else if (characterValue == 1)
        {
            myRobotPart = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Legs"),
            LevelManager.instance.robotSpawnPoints[0].position, Quaternion.identity);
        }
        else if (characterValue == 2)
        {
            myRobotPart = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Arms"),
            LevelManager.instance.robotSpawnPoints[0].position, Quaternion.identity);
        }

        myRobotPart.transform.parent = LevelManager.instance.robot.transform;
        LevelManager.instance.robot.GetComponent<RobotController>().robotParts[characterValue] = myRobotPart;
        LevelManager.instance.robot.GetComponent<RobotController>().PC = gameObject.GetComponent<PlayerController>();
    }*/
}
