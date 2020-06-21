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
        GameObject jugador = PhotonNetwork.Instantiate(Path.Combine("PhotonPreFabs", "PhotonPlayer"), Vector3.zero, Quaternion.identity);
        GameObject camera = GameObject.FindWithTag("MainCamera");
        if (camera != null)
        {
            ControlCamara followScript = camera.GetComponent("ControlCamara") as ControlCamara;
            if (followScript != null)
            {
                followScript.target = jugador;
            }
        }



    }

   
}
