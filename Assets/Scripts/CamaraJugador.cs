using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraJugador : MonoBehaviour
{
    [SerializeField] private string inputMouseX, inputMouseY;
    [SerializeField] private float sensibilidadMouse;

    [SerializeField] private Transform CuerpoJugador;

    private float topeEjeX;
    
    private void Awake()
    {
        BloquearCursor();
        topeEjeX = 0.0f;
    }

    private void BloquearCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    private void Update()
    {
        RotacionCamara();
    }

    private void RotacionCamara()
    {
        float mouseX = Input.GetAxis(inputMouseX) * sensibilidadMouse * Time.deltaTime;
        float mouseY = Input.GetAxis(inputMouseY) * sensibilidadMouse * Time.deltaTime;

        topeEjeX += mouseY;

        if(topeEjeX > 90.0f)
        {
            topeEjeX = 90.0f;
            mouseY = 0.0f;
            PararRotacionEjeX(270.0f);
        } else if (topeEjeX < -90.0f)
        {
            topeEjeX = -90.0f;
            mouseY = 0.0f;
            PararRotacionEjeX(90.0f);
        }
        transform.Rotate(Vector3.left * mouseY);
        CuerpoJugador.Rotate(Vector3.up * mouseX);
    }

    private void PararRotacionEjeX (float valor)
    {
        Vector3 rotacionEuler = transform.eulerAngles;
        rotacionEuler.x = valor;
        transform.eulerAngles = rotacionEuler;
    }
}
