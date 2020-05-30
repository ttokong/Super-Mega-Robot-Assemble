using System.IO;
using UnityEngine;
using Photon.Pun;

public class GameSetupController : MonoBehaviour
{

    // this script will be added to any multiplayer scene
    void Start()
    {
        CreatePlayer(); // create a networked player object for each player that loads into the multiplayer scenes
    }

    private void CreatePlayer()
    {
        PhotonNetwork.Instantiate(Path.Combine("PlayerPrefabs", "PhotonNetworkPlayer"), 
        LevelManager.instance.spawnpoints[PlayerInfo.instance.mySelectedCharacter].position, Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
