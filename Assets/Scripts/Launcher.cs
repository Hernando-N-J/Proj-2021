using System;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Launcher : MonoBehaviourPunCallbacks
{
    public GameObject connectButton;
    public GameObject joinRoomButton;
    public byte maxPlayersPerGame = 10;

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    private void Start()
    {
        joinRoomButton.SetActive(false);
    }

    public void Connect()
    {
        if(!PhotonNetwork.IsConnected)
            PhotonNetwork.ConnectUsingSettings();
    }

    public void JoinNewRoom()
    {
        Debug.Log("Joining new room");
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to master");
        joinRoomButton.SetActive(true);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Join room failed: " + returnCode + " --- " + message);
        PhotonNetwork.CreateRoom(null, new RoomOptions{MaxPlayers = maxPlayersPerGame});
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("PUN_VoiceDemo2");
    }
}
