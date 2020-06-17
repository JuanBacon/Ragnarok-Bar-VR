using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
using System;

public class GameSetupController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        createPlayer();
    }

    private void createPlayer()
    {
        Debug.Log("Creating player");
        PhotonNetwork.Instantiate(Path.Combine("PhotonPreFabs", "PhotonPlayer"), Vector3.zero, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
