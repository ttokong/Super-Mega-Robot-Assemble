using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using System.IO;

public class PhotonRoom : MonoBehaviourPunCallbacks, IInRoomCallbacks
{
    public static PhotonRoom room;
    private PhotonView PV;

    public bool isGameLoaded;
    public int currentScene;
    Player[] photonPlayers;
    public int playersInRoom;
    public int myNumberInRoom;

    public int playerInGame;

    private bool readyToCount;
    private bool readyToStart;
    public float startingTime;
    private float lessThanMaxPlayers;
    private float atMaxPlayers;
    private float timeToStart;

    private void Awake()
    {
        if (PhotonRoom.room == null)
        {
            PhotonRoom.room = this;
        }
        else
        {
            if (PhotonRoom.room != this)
            {
                Destroy(PhotonRoom.room.gameObject);
                PhotonRoom.room = this;
            }
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public override void OnEnable()
    {
        base.OnEnable();
        PhotonNetwork.AddCallbackTarget(this);
        SceneManager.sceneLoaded += OnSceneFinishedLoading;
    }

    public override void OnDisable()
    {
        base.OnDisable();
        PhotonNetwork.RemoveCallbackTarget(this);
        SceneManager.sceneLoaded -= OnSceneFinishedLoading;
    }

    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        readyToCount = false;
        readyToCount = false;
        lessThanMaxPlayers = startingTime;
        atMaxPlayers = 5.9f;
        timeToStart = startingTime;
        PhotonLobby.lobby.WaitingForPlayers.text = "Waiting for Players " + playersInRoom + "/" + MultiPlayerSettings.multiPlayerSetting.maxPlayers;
    }

    // Update is called once per frame
    void Update()
    {
        if(MultiPlayerSettings.multiPlayerSetting.delayStart)
        {
            if(playersInRoom == 1)
            {
                RestartTimer();
            }
            if(!isGameLoaded)
            {
                if (readyToStart)
                {
                    PhotonLobby.lobby.GameStarting.gameObject.SetActive(true);
                    atMaxPlayers -= Time.deltaTime;
                    lessThanMaxPlayers = atMaxPlayers;
                    timeToStart = atMaxPlayers;
                }
                else if (readyToCount)
                {
                    PhotonLobby.lobby.GameStarting.gameObject.SetActive(false);
                    lessThanMaxPlayers -= Time.deltaTime;
                    timeToStart = lessThanMaxPlayers;
                }
                PhotonLobby.lobby.GameStarting.text = "Game Starting in: " + timeToStart.ToString("F0");
                if (timeToStart <= 0)
                {
                    StartGame();
                }
            }
        }
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("We are now in a room");
        photonPlayers = PhotonNetwork.PlayerList;
        playersInRoom = photonPlayers.Length;
        myNumberInRoom = PlayerInfo.instance.mySelectedCharacter + 1;
        PhotonNetwork.NickName = myNumberInRoom.ToString();
        Debug.Log("You are now in-game as Player " + PhotonNetwork.NickName);
        PhotonLobby.lobby.WaitingForPlayers.text = "Waiting for Players " + playersInRoom + "/" + MultiPlayerSettings.multiPlayerSetting.maxPlayers;

        if (MultiPlayerSettings.multiPlayerSetting.delayStart)
        {
            Debug.Log("Displayer players in room out of max players possible (" + 
                playersInRoom + ":" + MultiPlayerSettings.multiPlayerSetting.maxPlayers + ")");

            if (playersInRoom > 1)
            {
                readyToCount = true;
            }
            if (playersInRoom == MultiPlayerSettings.multiPlayerSetting.maxPlayers)
            {
                readyToStart = true;
                if (!PhotonNetwork.IsMasterClient)
                    return;
                PhotonNetwork.CurrentRoom.IsOpen = false;
            }
        }
        else
        {
            StartGame();
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        Debug.Log("A new player had joined the room");
        photonPlayers = PhotonNetwork.PlayerList;
        playersInRoom++;
        PhotonLobby.lobby.WaitingForPlayers.text = "Waiting for Players " + playersInRoom + "/" + MultiPlayerSettings.multiPlayerSetting.maxPlayers;
        if (MultiPlayerSettings.multiPlayerSetting.delayStart)
        {
            Debug.Log("Displayer players in room out of max players possible (" + playersInRoom +
                ":" + MultiPlayerSettings.multiPlayerSetting.maxPlayers + ")");
            if (playersInRoom > 1)
            {
                readyToCount = true;
            }
            if (playersInRoom == MultiPlayerSettings.multiPlayerSetting.maxPlayers)
            {
                readyToStart = true;
                if (!PhotonNetwork.IsMasterClient)
                    return;
                PhotonNetwork.CurrentRoom.IsOpen = false;
            }
        }
    }

    void StartGame()
    {
        isGameLoaded = true;
        if (!PhotonNetwork.IsMasterClient)
            return;
        if (MultiPlayerSettings.multiPlayerSetting.delayStart)
        {
            PhotonNetwork.CurrentRoom.IsOpen = false;
        }
        PhotonNetwork.LoadLevel(MultiPlayerSettings.multiPlayerSetting.multiplayerScene);
    }

    void RestartTimer()
    {
        lessThanMaxPlayers = startingTime;
        timeToStart = startingTime;
        atMaxPlayers = 5.9f;
        readyToCount = false;
        readyToStart = false;
    }

    void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        currentScene = scene.buildIndex;
        if(currentScene == MultiPlayerSettings.multiPlayerSetting.multiplayerScene)
        {
            isGameLoaded = true;

            if (MultiPlayerSettings.multiPlayerSetting.delayStart)
            {
                PV.RPC("RPC_LoadedGameScene", RpcTarget.MasterClient);
            }
            else
            {
                PV.RPC("RPC_CreatePlayer", RpcTarget.All, PlayerInfo.instance.mySelectedCharacter);
            }
        }
    }

    [PunRPC]
    private void RPC_LoadedGameScene()
    {
        playerInGame++;
        if(playerInGame == PhotonNetwork.PlayerList.Length)
        {
            PV.RPC("RPC_LoadedGameScene", RpcTarget.AllBuffered);
        }
    }

    [PunRPC]
    private void RPC_CreatePlayer(int selectedCharacter)
    {
        Debug.Log("Player Created");
        //PhotonNetwork.Instantiate(Path.Combine("PlayerPrefabs", "PhotonNetworkPlayer"), transform.position, Quaternion.identity, 0);

    }
}
