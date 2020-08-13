using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerSelectionManager : MonoBehaviour
{
    private int PlayerIndex;

    public GameObject[] PlayerSelectionPrefabs;
    public PlayerInput playerInput;

    private float ignoreInputTime = 1.5f;
    private bool inputEnabled;
    private bool canSelect = true;

    private GameObject rootMenu;
    private PlayerSelectionController playerSelection;
    private int currentSelection = 2;

    [HideInInspector]
    public PlayerControls controls;

    private PlayerConfiguration[] playerConfig;

    private void Awake()
    {
        rootMenu = GameObject.Find("Layouts");
        if (rootMenu != null)
        {
            var menu = Instantiate(PlayerSelectionPrefabs[playerInput.playerIndex], rootMenu.GetComponent<MenuController>().Layouts[0].transform.position,
                rootMenu.GetComponent<MenuController>().Layouts[0].transform.rotation,
                rootMenu.GetComponent<MenuController>().Layouts[0].transform);

            //menu.GetComponent<PlayerSelectionController>().SetPlayerIndex(playerInput.playerIndex);

            var playerSelections = FindObjectsOfType<PlayerSelectionController>();
            var index = playerInput.playerIndex;
            SetPlayerIndex();
            playerSelection = playerSelections.FirstOrDefault(m => m.GetPlayerIndex() == index);
            playerConfig = GameObject.Find("LobbyController").GetComponent<PlayerManager>().GetPlayerConfigurations().ToArray();
            playerConfig[index].Input.onActionTriggered += Input_OnActionTriggered;
        }

        controls = new PlayerControls();

    }

    public void Input_OnActionTriggered(CallbackContext obj)
    {
        if (obj.action.name == controls.Gameplay.UINav.name)
        {
            DpadDown(obj);
        }
        else if (obj.action.name == controls.Gameplay.UISelection.name)
        {
            Selection(obj);
        }
    }


    public void SetPlayerIndex()
    {
        PlayerIndex = playerInput.playerIndex;
        ignoreInputTime = Time.time + ignoreInputTime;
    }

    public void Selection(CallbackContext context)
    {
        float value = context.ReadValue<float>();

        if (inputEnabled)
        {
            if (canSelect)
            {
                if (context.performed && value >= 0.9) //if X button is pressed AKA select
                {
                    if (rootMenu.GetComponent<MenuController>().CharactersSelectCheck[currentSelection] == false)
                    {
                        rootMenu.GetComponent<MenuController>().SelectCharacter(inputEnabled, PlayerIndex, currentSelection);
                        rootMenu.GetComponent<MenuController>().CharactersSelectCheck[currentSelection] = true;
                        canSelect = false;
                        rootMenu.GetComponent<MenuController>().ReadyPlayer(inputEnabled, PlayerIndex, currentSelection);
                    }
                    else if (rootMenu.GetComponent<MenuController>().CharactersSelectCheck[currentSelection] == true)
                    {
                        Debug.Log("Cant Select this character as it is already selected by another player!");
                    }
                }
            }
            else if (!canSelect)
            {

                if (context.performed && value <= -0.9) //if O button is pressed AKA back
                {
                    rootMenu.GetComponent<MenuController>().CancelSelection(inputEnabled, PlayerIndex, currentSelection);
                    rootMenu.GetComponent<MenuController>().CharactersSelectCheck[currentSelection] = false;
                    canSelect = true;
                }
            }

        }
        else { return; }
    }

    public void DpadDown(InputAction.CallbackContext context)
    {
        float value = context.ReadValue<float>();

        if (inputEnabled && canSelect)
        {
            if (context.performed && value >= 0.9) //if right dpad is pressed
            {
                if (playerSelection.transform.parent == rootMenu.GetComponent<MenuController>().Layouts[0].transform)
                {
                    playerSelection.transform.SetParent(rootMenu.GetComponent<MenuController>().Layouts[1].transform);
                    playerSelection.transform.SetSiblingIndex(PlayerIndex);
                    currentSelection = 1;
                }
                else if (playerSelection.transform.parent == rootMenu.GetComponent<MenuController>().Layouts[1].transform)
                {
                    playerSelection.transform.SetParent(rootMenu.GetComponent<MenuController>().Layouts[2].transform);
                    playerSelection.transform.SetSiblingIndex(PlayerIndex);
                    currentSelection = 0;
                }
                else if (playerSelection.transform.parent == rootMenu.GetComponent<MenuController>().Layouts[2].transform) { return; }
            }

            if (context.performed && value <= -0.9) //if left dpad is pressed
            {
                if (playerSelection.transform.parent == rootMenu.GetComponent<MenuController>().Layouts[2].transform)
                {
                    playerSelection.transform.SetParent(rootMenu.GetComponent<MenuController>().Layouts[1].transform);
                    playerSelection.transform.SetSiblingIndex(PlayerIndex);
                    currentSelection = 1;
                }
                else if (playerSelection.transform.parent == rootMenu.GetComponent<MenuController>().Layouts[1].transform)
                {
                    playerSelection.transform.SetParent(rootMenu.GetComponent<MenuController>().Layouts[0].transform);
                    playerSelection.transform.SetSiblingIndex(PlayerIndex);
                    currentSelection = 2;
                }
                else if (playerSelection.transform.parent == rootMenu.GetComponent<MenuController>().Layouts[0].transform) { return; }
            }
        }
        else { return; }
    }

    private void Update()
    {
        if (Time.time > ignoreInputTime)
        {
            inputEnabled = true;
        }
    }


    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
