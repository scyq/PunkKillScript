using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class GameManager : MonoBehaviourPunCallbacks
{
    public GameObject readyButton;
    public Transform player0Reborn;
    public Transform player1Reborn;
    
    
    public void ReadyToPlay()
    {
        readyButton.SetActive(false);
        int playerIndex = Random.Range(0, 2);

        if (playerIndex == 0)
        {
            PhotonNetwork.Instantiate("HatPerson", player0Reborn.position, Quaternion.identity, 0);
        }
        else
        {
            PhotonNetwork.Instantiate("HeadsetPerson", player1Reborn.position, Quaternion.identity, 0);
        }
    }
}
