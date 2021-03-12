using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class Laucher : MonoBehaviourPunCallbacks
{

    public GameObject NameUI;
    public GameObject ConnectUI;
    public InputField roomName;
    public InputField playerName;
    public GameObject Loading;

    private float _loadingInterval = 0.2f;
    private Text _loadingText;

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        _loadingText = Loading.GetComponent<Text>();
    }

    private void Update()
    {
        _loadingInterval -= Time.deltaTime;
        if (_loadingInterval <= 0)
        {
            _loadingInterval = 0.2f;
            switch (_loadingText.text)
            {
                case "Connecting":
                    _loadingText.text = "Connecting.";
                    break;
                case "Connecting.":
                    _loadingText.text = "Connecting..";
                    break;
                case "Connecting..":
                    _loadingText.text = "Connecting...";
                    break;
                case "Connecting...":
                    _loadingText.text = "Connecting";
                    break;
            }
        }
    }

    public override void OnConnectedToMaster()
    {
        // base.OnConnectedToMaster();
        NameUI.SetActive(true);
        Loading.SetActive(false);
    }

    public void PlayButton()
    {
        NameUI.SetActive(false);
        PhotonNetwork.NickName = playerName.text;
        ConnectUI.SetActive(true);
    }

    public void JoinOrCreateRoom()
    {
        if (roomName.text.Length < 1)
            return;
        RoomOptions options = new RoomOptions() {MaxPlayers = 2};
        PhotonNetwork.JoinOrCreateRoom(roomName.text, options, default);
        ConnectUI.SetActive(false);
    }

    public override void OnJoinedRoom()
    {
        // base.OnJoinedRoom();
        PhotonNetwork.LoadLevel(1);
    }
}
