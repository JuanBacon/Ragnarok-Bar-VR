﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class QuickStartLobby : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject StartButton;
    [SerializeField]
    private GameObject LoadingButton;
    [SerializeField]
    private GameObject CancelButton;
    [SerializeField]
    private GameObject SalirButton;
    [SerializeField]
    private int RoomSize;

   

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        StartButton.SetActive(true);
        SalirButton.SetActive(true);
        LoadingButton.SetActive(false);
        
    }

    public void QuickStart()
    {
        StartButton.SetActive(false);
        CancelButton.SetActive(true);
        PhotonNetwork.JoinRandomRoom();
        Debug.Log("QuickStart");

    }

    public override void OnJoinRandomFailed(short returnCode, string message)
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

    public void QuickCancel()
    {
        CancelButton.SetActive(false);
        StartButton.SetActive(true);
        SalirButton.SetActive(true);
        PhotonNetwork.LeaveRoom();
    }
}
