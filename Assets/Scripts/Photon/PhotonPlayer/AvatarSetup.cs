using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class AvatarSetup : MonoBehaviour
{

    #region PhotonView

    private PhotonView PV;

    #endregion

    public GameObject myCharacter;
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
}
