using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnosBeerpong : MonoBehaviour
{

    public int jugador1total = 0;
    public int jugador2total = 0;
    // Update is called once per frame
    void Update()
    {
        if(jugador1total == 6)
        {
            Debug.Log("Gana jugador 2");
        }else
        if(jugador2total == 6){
            Debug.Log("Gana jugador 1");
        }
    }
}
