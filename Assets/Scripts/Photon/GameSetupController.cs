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

        switch (PlayerInfo.instance.mySelectedCharacter)
        {
            case 0:
                PhotonNetwork.Instantiate(Path.Combine("PlayerPrefabs", "Tank"), LevelManager.instance.spawnpoints[0].position, Quaternion.identity);
                break;


            case 1:
                PhotonNetwork.Instantiate(Path.Combine("PlayerPrefabs", "DPS"),
                    LevelManager.instance.spawnpoints[1].position, Quaternion.identity);
                break;


            case 2:
                PhotonNetwork.Instantiate(Path.Combine("PlayerPrefabs", "Support"),
                    LevelManager.instance.spawnpoints[2].position, Quaternion.identity);
                break;
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
