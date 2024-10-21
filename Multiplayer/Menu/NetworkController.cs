using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class NetworkController : MonoBehaviourPunCallbacks
{
    protected string playerNick;

    //GameObjects

    [SerializeField] GameObject loadingAnimation;
    [SerializeField] GameObject textGroupDebugs;
    [SerializeField] GameObject settingGamePanel;
    [SerializeField] GameObject inputPlaceholder;
    [SerializeField] GameObject waitingPanel;
    [SerializeField] GameObject lobbyPanel;

    //Buttons

    [SerializeField] Button enterLobby;
    [SerializeField] Button enterCreatedRoom;
    [SerializeField] Button enterRandomRoom;
    [SerializeField] Button disconnectRoom;

    //Text Debugs

    [SerializeField] TMPro.TMP_Text enteredLobby;
    [SerializeField] TMPro.TMP_Text currentRoom;
    [SerializeField] TMPro.TMP_Text debugPing;
    [SerializeField] TMPro.TMP_Text playersCount;

    //Input Fields

    [SerializeField] TMPro.TMP_InputField playerNickInputfield;
    [SerializeField] TMPro.TMP_InputField roomNameInputfield;

    private void Start()
    {
        //Interactables

        enterLobby.interactable = false;
        roomNameInputfield.interactable = false;

        //GameObjects

        loadingAnimation.SetActive(false);
        waitingPanel.SetActive(false);

        //Buttons

        disconnectRoom.gameObject.SetActive(false);
        enterCreatedRoom.gameObject.SetActive(false);
        enterRandomRoom.gameObject.SetActive(false);
        roomNameInputfield.gameObject.SetActive(false);
    }

    private void Update()
    {
        InputFieldPlayerNick();

        InputFieldRoomName();

        IsPlayerOnRoom();
    }

    private void FixedUpdate()
    {
        Ping();
    }

    public void InputFieldPlayerNick()
    {
        //activate inputfield if there is a player nickname
        if (playerNickInputfield.text != "")
        {
            enterLobby.interactable = true;
        }
        else
        {
            enterLobby.interactable = false;
        }
    }

    public void InputFieldRoomName()
    {
        //activates inputfield if player enters a room name
        if (roomNameInputfield.text != "")
        {
            enterCreatedRoom.interactable = true;
        }
        else
        {
            enterCreatedRoom.interactable = false;
        }
    }

    public void IsPlayerOnRoom()
    {
        if (PhotonNetwork.CountOfRooms > 0)
        {
            enterRandomRoom.gameObject.SetActive(true);
            enterRandomRoom.interactable = true;
        }

    }

    //connect to the Photon Network - PUN
    public void ConnnectPN()
    {
        loadingAnimation.SetActive(true);
        PhotonNetwork.ConnectUsingSettings();
    }

    //callback function of ConnectUsingSettings will run when connected to Photon Network
    public override void OnConnected()
    {
        playerNick = playerNickInputfield.text;
        PhotonNetwork.NickName = playerNick;

        loadingAnimation.SetActive(false);
        playerNickInputfield.gameObject.SetActive(false);
        enterLobby.gameObject.SetActive(false);

        Debug.Log("Step 1 - Conectado a Photon!");
    }

    //callback from MonoBehaviourPunCallbacks - override
    public override void OnConnectedToMaster()
    {
        //master means you are connected as a player
        Debug.Log("Step 2 - Conectado a Master!");

        JoinLobby();
        lobbyPanel.gameObject.SetActive(true);
    }

    public void JoinLobby()
    {
        PhotonNetwork.JoinLobby();

        enterCreatedRoom.gameObject.SetActive(true);
        roomNameInputfield.interactable = true;
        disconnectRoom.interactable = true;

        enterCreatedRoom.gameObject.SetActive(true);

        disconnectRoom.interactable = false;
        disconnectRoom.gameObject.SetActive(true);

        roomNameInputfield.gameObject.SetActive(true);
        roomNameInputfield.interactable = true;
    }

    public override void OnJoinedLobby()
    {
        enteredLobby.text = "Boas vindas ao lobby " + PhotonNetwork.NickName + "!";
        Debug.Log("Step 3 - Conectado ao lobby!");

        if (PhotonNetwork.CountOfRooms > 0)
        {
            enterRandomRoom.gameObject.SetActive(true);
            enterRandomRoom.interactable = true;
        }
        else
        {
            enterRandomRoom.gameObject.SetActive(true);
            enterRandomRoom.interactable = false;
        }
    }

    //save the input's room name to a variable and creates a room
    public void CreateOrConnectRoom()
    {
        string roomName = roomNameInputfield.text;
        PhotonNetwork.JoinOrCreateRoom(roomName, new RoomOptions { MaxPlayers = 2 }, TypedLobby.Default);
        Debug.Log("Step 4 - Conectado a sala!");
    }


    public void JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
        disconnectRoom.interactable = true;
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Step 5 - Entrei em uma sala chamada " + PhotonNetwork.CurrentRoom.Name + ".");
        Debug.Log("Step 6 - Aguardando jogadores.");

        debugPing.gameObject.SetActive(true);
        disconnectRoom.interactable = true;
        waitingPanel.SetActive(true);

        currentRoom.text = "Sala atual: " + PhotonNetwork.CurrentRoom.Name;
        playersCount.text = "Jogadores: " + PhotonNetwork.CurrentRoom.PlayerCount;

        //if (PhotonNetwork.LocalPlayer.IsMasterClient)
        CheckPlayersAndLoad();
    }

    public override void OnPlayerEnteredRoom(Player newplayer)
    {
        Debug.Log("Step 7 - Jogador entrou na sala.");
        playersCount.text = "Jogadores: " + PhotonNetwork.CurrentRoom.PlayerCount;

        CheckPlayersAndLoad();
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        if (PhotonNetwork.CountOfRooms > 0)
        {
            enterRandomRoom.gameObject.SetActive(true);
            enterRandomRoom.interactable = true;
        }
        else
        {
            enterRandomRoom.gameObject.SetActive(true);
            enterRandomRoom.interactable = false;
        }

        Debug.Log("Info - O número de salas é " + roomList.Count + ".");
    }

    //disconnect the current room
    public void DisconnectRoom()
    {
        PhotonNetwork.LeaveRoom();
        Debug.Log("Desconectado da sala!");

        disconnectRoom.interactable = false;
        waitingPanel.SetActive(false);
        roomNameInputfield.text = "";
    }

    public void LoadGame()
    {
        PhotonNetwork.LoadLevel("Gameplay");
        Debug.Log("Step 8 - Troca para cena Gameplay.");
    }

    public void CheckPlayersAndLoad()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount >= 2)
        {
            LoadGame();
        }
    }



    public void Ping()
    {
        debugPing.text = ("Ping: " + PhotonNetwork.GetPing());
    }

    /*
    //if there is no room, this function will run, creating a room and the player will join the room
    //the function's parameters are for debug purposes
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.LogWarning("Sala inexistente. Criando aleatória...");
        string randomName = "Sala_ " + Random.Range(0, 1000) + ".";
        PhotonNetwork.CreateRoom(randomName); //a função Create já faz com que o jogador entre na sala
        currentRoom.text = "Conectado a sala " + PhotonNetwork.CurrentRoom + ".";
        Debug.LogWarning("Conectado a sala " + PhotonNetwork.CurrentRoom + ".");
    }
    */
}
