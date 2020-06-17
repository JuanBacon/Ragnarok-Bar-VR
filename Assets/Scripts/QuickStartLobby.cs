using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class QuickStartLobby : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private int RoomSize;


    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void QuickStart()
    {
        PhotonNetwork.JoinRandomRoom();
        Debug.Log("QuickStart");

    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to join a room");
        CreateRoom();
}

    void CreateRoom()
    {
        Debug.Log("Creating a new room");
        int randomRoomNumber = Random.Range(0, 1000);
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)RoomSize };
        PhotonNetwork.CreateRoom("Room" + randomRoomNumber, roomOps);
        Debug.Log(randomRoomNumber);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to create a room");
        CreateRoom();
    }
}
