using System.IO;
using UnityEngine;
using Photon.Pun;

public class GameSetupController : MonoBehaviour
{
    public int playerId;

    // this script will be added to any multiplayer scene
    void Start()
    {
        CreatePlayer(); // create a networked player object for each player that loads into the multiplayer scenes
    }

    private void CreatePlayer()
    {
        playerId++;
        Debug.Log("Creating Player" + playerId);
        PhotonNetwork.Instantiate(Path.Combine("PlayerPrefabs", "Player" + playerId), LevelManager.instance.spawnpoints[playerId - 1].position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
