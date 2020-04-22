using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class QuickStartRoomController : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private int multiplayerSceneIndex; // number for the build index to the multiplayer scene

    public override void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }

    public override void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    public override void OnJoinedRoom() // callback function for when we successfully create or join a room
    {
        Debug.Log("Joined Room");
        StartGame();
    }

    private void StartGame() // function for loading into the multiplayer scene
    {
        if (PhotonNetwork.IsMasterClient)
        {
            Debug.Log("Starting Game");
            PhotonNetwork.LoadLevel(multiplayerSceneIndex); // because of AutoSyncScene, all players who joins this room after the master client has loaded into multiplayer scene, will also be loaded into multiplayer scene
        }
    }
}
