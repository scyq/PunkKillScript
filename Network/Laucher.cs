using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Laucher : MonoBehaviourPunCallbacks
{
    private int _playerIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        Random.InitState((int)System.DateTime.Now.Ticks);
        _playerIndex = Random.Range(0, 2);
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log("Connected");
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions() {MaxPlayers = 2}, default);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();

        if (_playerIndex == 0)
        {
            PhotonNetwork.Instantiate("HeadsetPerson", new Vector3(0, 0.5f, 0), Quaternion.identity, 0);
        }
        else
        {
            PhotonNetwork.Instantiate("HatPerson", new Vector3(0, 0.5f, 0), Quaternion.identity, 0);
        }
    }
}
