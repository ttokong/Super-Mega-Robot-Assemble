using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class PhotonPlayer : MonoBehaviour
{

    private PhotonView PV;
    public GameObject playerAvatar;

    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();

        if(PV.IsMine)
        {
            playerAvatar = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Player1"), LevelManager.instance.spawnpoints[0].position,
                LevelManager.instance.spawnpoints[0].rotation, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
