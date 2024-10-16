using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.Net.NetworkInformation;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;
using UnityEngine.PlayerLoop;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class NetworkController : MonoBehaviourPunCallbacks
{
    protected string playerNick;

    //GameObjects

    [SerializeField] GameObject loadingAnimation;
    [SerializeField] GameObject textGroupDebugs;
    [SerializeField] GameObject settingGamePanel;
    [SerializeField] GameObject playingGamePanel;
    [SerializeField] GameObject inputPlaceholder;

    //Buttons

    [SerializeField] Button connectPhotonNetwork;
    [SerializeField] Button enterCreatedRoom;
    [SerializeField] Button enterRandomRoom;
    [SerializeField] Button disconnectRoom;

    //Text Debugs

    [SerializeField] TMPro.TMP_Text debug;
    [SerializeField] TMPro.TMP_Text debug2;
    [SerializeField] TMPro.TMP_Text debug3;
    [SerializeField] TMPro.TMP_Text debug4;
    [SerializeField] TMPro.TMP_Text debug5;
    [SerializeField] TMPro.TMP_Text debug6;
    [SerializeField] TMPro.TMP_Text debug7;
    [SerializeField] TMPro.TMP_Text debug8;

    //Input Fields

    [SerializeField] TMPro.TMP_InputField playerNickInputfield;
    [SerializeField] TMPro.TMP_InputField roomNameInputfield;

    //public string randomName = "Sala_ " + Random.Range(0, 1000) + ".";

    private void Start()
    {
        //Interactables

        connectPhotonNetwork.interactable = false;
        roomNameInputfield.interactable = false;

        //GameObjects

        loadingAnimation.SetActive(false);
        textGroupDebugs.SetActive(false);

        //Buttons

        disconnectRoom.gameObject.SetActive(false);
        enterCreatedRoom.gameObject.SetActive(false);
        enterRandomRoom.gameObject.SetActive(false);
        roomNameInputfield.gameObject.SetActive(false);
        debug6.gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        //activates inputfield if there is a player nickname
        if (playerNickInputfield.text != "")
        {
            connectPhotonNetwork.interactable = true;
        }

        //otherwise stays deactivated
        else
        {
            connectPhotonNetwork.interactable = false;
        }

        //activates inputfield if player enters a room name
        if (roomNameInputfield.text != "")
        {
            enterCreatedRoom.interactable = true;
        }

        Ping();
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
        loadingAnimation.SetActive(false);
        PhotonNetwork.NickName = playerNick;
        debug.text = "Conectado a Photon Network!";
        textGroupDebugs.SetActive(true);
        playerNickInputfield.gameObject.SetActive(false);
        connectPhotonNetwork.gameObject.SetActive(false);
        Debug.Log("Step 1 - Conectado a Photon!");
    }

    //callback from MonoBehaviourPunCallbacks - override
    public override void OnConnectedToMaster()
    {
        debug2.text = "Conectado a Master " + PhotonNetwork.NickName + " !";

        enterCreatedRoom.gameObject.SetActive(true);
        enterRandomRoom.gameObject.SetActive(true);

        disconnectRoom.interactable = false;
        disconnectRoom.gameObject.SetActive(true);

        roomNameInputfield.gameObject.SetActive(true);
        roomNameInputfield.interactable = true;

        Debug.Log("Step 2 - Conectado a Master!");
        //master significa que está conectado como um jogador

    }

    public void JoinLobby()
    {
        if (roomNameInputfield.text != "")
        {
            PhotonNetwork.JoinLobby();

            enterRandomRoom.gameObject.SetActive(false);
            enterCreatedRoom.gameObject.SetActive(false);
            roomNameInputfield.interactable = false;

            disconnectRoom.interactable = true;

            debug3.text = "Conectado ao lobby!";
            Debug.Log("Step 3 - Conectado ao lobby!");
        }

        //this is a text message inside the inputfield
        else
        {
            inputPlaceholder.SetActive(true);
        }
    }

    //save the input's room name to a variable and creates a room
    public void CreateOrConnectRoom()
    {
        string roomName = roomNameInputfield.text;
        PhotonNetwork.JoinOrCreateRoom(roomName, new RoomOptions { MaxPlayers = 10 }, TypedLobby.Default);
        debug4.text = "Step 4 - Conectado a sala " + roomName;
        Debug.LogWarning("Step 4 - Conectado a sala!");
    }

    public void JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
        disconnectRoom.interactable = true;
    }

    //if there is no room, this function will run, creating a room and the player will join the room
    //the function's parameters are for debug purposes
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.LogWarning("Sala inexistente. Criando aleatória...");
        string randomName = "Sala_ " + Random.Range(0, 1000) + ".";
        PhotonNetwork.CreateRoom(randomName); //a função Create já faz com que o jogador entre na sala
        debug4.text = "Conectado a sala " + PhotonNetwork.CurrentRoom + ".";
        Debug.LogWarning("Conectado a sala " + PhotonNetwork.CurrentRoom + ".");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Step 5 - Entrei em uma sala chamada " + PhotonNetwork.CurrentRoom.Name);
        Debug.Log("Tem " + PhotonNetwork.CurrentRoom.PlayerCount + " jogadores.");
        debug5.text = ("Sala atual: " + PhotonNetwork.CurrentRoom.Name);
        debug6.gameObject.SetActive(true);
        disconnectRoom.interactable = true;

        if (PhotonNetwork.CurrentRoom.PlayerCount >= 2)
        {
            LoadGame();
        }
    }

    //disconnect the current room
    public void DisconnectRoom()
    {
        PhotonNetwork.LeaveRoom();
        //PhotonNetwork.LeaveLobby();
        debug4.text = "Desconectado da Sala!";
        debug5.text = "Sala atual: ";
        disconnectRoom.interactable = false;
    }
    public void Ping()
    {
        debug6.text = ("Ping: " + PhotonNetwork.GetPing());
    }

    /*public void PlayerCount()
    {
        debug7.text = "Jogadores: " + PhotonNetwork.CurrentRoom.PlayerCount + ".";
    }*/

    public void LoadGame()
    {
        PhotonNetwork.LoadLevel("Gameplay");
    }

    public void WaitingPlayers()
    {
        SceneManager.LoadScene("WaitingPlayers");
    }

    //quit application build
    public void Quit()
    {
        Application.Quit();
    }




    /*public override void OnJoinedLobby()
    {
    string roomName = serverInput.text;
    PhotonNetwork.CreateRoom(roomName);
    debug4.text = "Step 4 - Conectado a sala " + roomName;

    PhotonNetwork.JoinRoom(roomName);
    Debug.LogWarning("Step 4 - Conectado a sala!");
    }*/

    /*
    IEnumerator ReturnPing(float time)
    {
        yield return new WaitForSeconds(time);
        
        float ping = PhotonNetwork.GetPing();
        Debug.Log($"Ping: {ping}");
        
        string region = PhotonNetwork.CloudRegion;
        Debug.Log($"Região: {region}");
        
        StartCoroutine(ReturnPing(1f));
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(10f);
    }*/
}
