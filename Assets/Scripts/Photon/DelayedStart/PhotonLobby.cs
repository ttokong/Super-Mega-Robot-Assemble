using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class PhotonLobby : MonoBehaviourPunCallbacks
{

    public static PhotonLobby lobby;

    public GameObject playerButton1;
    public GameObject playButton;
    public GameObject cancelButton;

    public Text WaitingForPlayers;
    public Text GameStarting;

    private void Awake()
    {
        lobby = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("We are now connected to the " + PhotonNetwork.CloudRegion + " server!");
        PhotonNetwork.AutomaticallySyncScene = true;
        playerButton1.SetActive(true);
    }

    public void OnPlayButtonClicked()
    {
        Debug.Log("Play Button was clicked");
        playButton.SetActive(false);
        cancelButton.SetActive(true);
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Tried to join a random game but failed. There must be no open games available");
        CreateRoom();
    }

    void CreateRoom()
    {
        Debug.Log("Trying to create a new Room");
        int randomRoomName = Random.Range(0, 10000);
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)MultiPlayerSettings.multiPlayerSetting.maxPlayers };
        PhotonNetwork.CreateRoom("Room" + randomRoomName, roomOps);
    }


    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Tried to create a new room but failed, there must already be a room with the same name.");
        CreateRoom();
    }

    public void OnCancelButtonClicked()
    {
        Debug.Log("Cancel Button was clicked");
        playButton.SetActive(true);
        cancelButton.SetActive(false);
        PhotonRoom.room.playersInRoom--;
        WaitingForPlayers.text = "Waiting for Players " + PhotonRoom.room.playersInRoom + "/" + MultiPlayerSettings.multiPlayerSetting.maxPlayers;
        GameStarting.gameObject.SetActive(false);
        PhotonNetwork.LeaveRoom();
    }
}
