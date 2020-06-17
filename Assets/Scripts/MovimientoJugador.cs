using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    [SerializeField] private string EntradaHorizontal;
    [SerializeField] private string EntradaVertical;
    [SerializeField] private float velocidad;

    private CharacterController Controlador;

    private void Awake()
    {
        Controlador = GetComponent<CharacterController>();
    }

   
    void Update()
    {
        float horizontal = Input.GetAxis(EntradaHorizontal) * velocidad;
        float vertical = Input.GetAxis(EntradaVertical) * velocidad;

        Vector3 adelante = transform.forward * vertical;
        Vector3 derecha = transform.right * horizontal;

        Controlador.SimpleMove(adelante + derecha);
    }
}
