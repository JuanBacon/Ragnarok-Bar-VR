using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnosBeerpong : MonoBehaviour
{
    public GameObject MostrarGanador;
    public int jugador1total = 0;
    public int jugador2total = 0;
    public GameObject[] jarras1;
    public GameObject[] jarras2;
    
    void Update()
    {
        if(jugador1total == 6)
        {
            Debug.Log("Gana jugador 2");
            MostrarGanador.GetComponent<TextMesh>().text = "Gana Jugador2";
            StartCoroutine(ReiniciarJuego());
        }else
        if(jugador2total == 6){
            Debug.Log("Gana jugador 1");
            MostrarGanador.GetComponent<TextMesh>().text = "Gana Jugador1";
            StartCoroutine(ReiniciarJuego());
        }
    }

    IEnumerator ReiniciarJuego()
    {
        yield return new WaitForSeconds(5);
        MostrarGanador.GetComponent<TextMesh>().text = "";
        jugador1total = 0;
        jugador2total = 0;
        for(int i = 0; i < jarras1.Length; i++)
        {
            jarras1[i].gameObject.SetActive(true);
            jarras2[i].gameObject.SetActive(true);
        }

    }
}
