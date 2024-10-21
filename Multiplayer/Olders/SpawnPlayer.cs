using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] GameObject spawnPlayerButton;
    [SerializeField] GameObject player;

    //offline method for a local spawn
    public void InstatiatePlayer()
    {
        GameObject.Instantiate(player);
    }

    //online method for spawing a player
    public void SpawnPlayerOnline()
    {
        //instantiate player and sync its position    
        PhotonNetwork.Instantiate(player.name, player.transform.position, player.transform.rotation);
        Debug.Log("Player was spawned");
    }
}
