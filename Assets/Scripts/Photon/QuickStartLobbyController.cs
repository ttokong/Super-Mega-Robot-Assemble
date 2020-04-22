using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class QuickStartLobbyController : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject quickStartButton; // button used for creating and joining a game
    [SerializeField]
    private GameObject quickCancelButton; // button used to stop searing for a game to join
    [SerializeField]
    private int RoomSize; // manual set the number of player in the room at one time

    public override void OnConnectedToMaster() // callback function for when the first connection is established
    {
        PhotonNetwork.AutomaticallySyncScene = true; // makes it so whatever scene the master client has is the same for every other client
        quickStartButton.SetActive(true);
    }

    public void QuickStart() // paired to the quick start button
    {
        quickStartButton.SetActive(false);
        quickCancelButton.SetActive(true);
        PhotonNetwork.JoinRandomRoom(); // first tries to join an existing room
        Debug.Log("Quick Start");
    }

    public override void OnJoinRandomFailed(short returnCode, string message) // callback function for when joining a room fails
    {
        Debug.Log("Failed to join a room");
        CreateRoom();
    }

    void CreateRoom()
    {
        Debug.Log("Creating new room");
        int randomRoomNumber = Random.Range(0, 10000); // creating a random name for the room
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)RoomSize };
        PhotonNetwork.CreateRoom("Room" + randomRoomNumber, roomOps); // attempting to create a new room
        Debug.Log(randomRoomNumber);
    }

    public override void OnCreateRoomFailed(short returnCode, string message) // callback function for when creating a room fails
    {
        Debug.Log("Failed to create room... trying again");
        CreateRoom(); // retrying to create a new room with a different name
    }

    public void QuickCancel() // paired to the cancel button. used to stop looking for a room to join
    {
        quickCancelButton.SetActive(false);
        quickStartButton.SetActive(true);
        PhotonNetwork.LeaveRoom(); // disconnect from any room it tries to join
    }

}
