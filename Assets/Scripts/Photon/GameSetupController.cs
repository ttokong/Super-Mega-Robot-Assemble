using System.IO;
using UnityEngine;

public class GameSetupController : MonoBehaviour
{
    private PlayerConfiguration[] playerconfigs;

    public GameObject[] avatarPrefabs;

    // this script will be added to any multiplayer scene
    void Start()
    {
        playerconfigs = PlayerManager.instance.GetPlayerConfigurations().ToArray();
        CreatePlayer(); // create a networked player object for each player that loads into the multiplayer scenes
    }

    public void CreatePlayer()
    {

        for (int i = 0; i < playerconfigs.Length; i++)
        {
            GameObject player = Instantiate(avatarPrefabs[playerconfigs[i].SelectedCharacter], LevelManager.instance.spawnpoints[playerconfigs[i].SelectedCharacter].position, Quaternion.identity);
            player.GetComponent<PlayerStats>().InitializePlayer(playerconfigs[i]);
            player.GetComponent<PlayerInputHandler>().InitializePlayer(playerconfigs[i]);
            LevelManager.instance.HealthBars[i].SetHealth(5);
            LevelManager.instance.UltimateBars[i].SetUltimatePercentage(0); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
