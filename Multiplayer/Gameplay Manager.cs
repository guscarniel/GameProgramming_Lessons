using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameplayManager : MonoBehaviourPunCallbacks
{


    [SerializeField] TMPro.TMP_Text gpDebug;

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
    Debug.LogWarning("Jogador " + newPlayer.NickName + " entrou na sala!");
    gpDebug.text = ("Jogador " + newPlayer.NickName + " entrou na sala!");
    }

    //quit application build
    public void QuitApp()
    {
        Application.Quit();
    }

}
