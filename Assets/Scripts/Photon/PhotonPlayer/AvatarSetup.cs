using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class AvatarSetup : MonoBehaviour
{
    public GameObject myCharacter;

    // Start is called before the first frame update
    void Start()
    {
        RPC_AddCharacter(myCharacter);
    }
        
    void RPC_AddCharacter(GameObject playerPrefab)
    {
        myCharacter = Instantiate(playerPrefab, transform.position, transform.rotation, transform);
    }
}
