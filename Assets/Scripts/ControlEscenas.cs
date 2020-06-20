using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ControlEscenas : MonoBehaviour
{
    public void CargarEscenaJugar(){
        SceneManager.LoadScene(1);
    }

    public void SalirJuego()
    {
        Application.Quit();
    }
}
