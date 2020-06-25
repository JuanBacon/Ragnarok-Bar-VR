using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MovimientoJugador : MonoBehaviour, IPunObservable
{
    //Movimiento jugador
    [SerializeField] private string EntradaHorizontal;
    [SerializeField] private string EntradaVertical;
    [SerializeField] private float velocidad;
    private CharacterController Controlador;
    //Acción jugador
    [SerializeField] private string AccionJugador;
    //Camara
    [SerializeField] GameObject CamaraJugador;
    [SerializeField] private string inputMouseX, inputMouseY;
    [SerializeField] private float sensibilidadMouse;
    private float topeEjeX;
    PhotonView photonView;
    //Controles minujuegos
    //Beerpong
    private GameObject turnoBeerpong;
    public float fireDelta = 2.0F;
    private float nextFire = 0.5F;
    private float myTime = 0.0F;



    private void Awake()
    {
        
        photonView = this.gameObject.GetComponent<PhotonView>();
        photonView.ObservedComponents.Add(this);
        turnoBeerpong = GameObject.Find("Beerpong");
        if (!photonView.IsMine)
        {
            Debug.Log(" DISABLE CONTROLER ");
            enabled = false;
            return;
        }
            CamaraJugador = GameObject.FindWithTag("MainCamera");
            BloquearCursor();
            topeEjeX = 0.0f;
            Controlador = this.gameObject.GetComponent<CharacterController>();
        

        
    }
    private void BloquearCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        if(photonView.IsMine == false)
        {
            return;
        }
            //Movimiento
            float horizontal = Input.GetAxis(EntradaHorizontal) * velocidad;
            float vertical = Input.GetAxis(EntradaVertical) * velocidad;

            Vector3 adelante = transform.forward * vertical;
            Vector3 derecha = transform.right * horizontal;

            Controlador.SimpleMove(adelante + derecha);

            //CAMARA
            float mouseX = Input.GetAxis(inputMouseX) * sensibilidadMouse * Time.deltaTime;
            float mouseY = Input.GetAxis(inputMouseY) * sensibilidadMouse * Time.deltaTime;

            topeEjeX += mouseY;

            if (topeEjeX > 90.0f)
            {
                topeEjeX = 90.0f;
                mouseY = 0.0f;
                PararRotacionEjeX(270.0f);
            }
            else if (topeEjeX < -90.0f)
            {
                topeEjeX = -90.0f;
                mouseY = 0.0f;
                PararRotacionEjeX(90.0f);
            }
        transform.Rotate(Vector3.up * mouseX);
        CamaraJugador.transform.Rotate(Vector3.left * mouseY);

        //GameObject proyectilPrefab = Resources.Load("proyectil") as GameObject;
        myTime = myTime + Time.deltaTime;

        
        
    }
    void OnTriggerStay(Collider obj)
    {
        if(obj.gameObject.tag == "beerpong")
        {
            if (Input.GetButton(AccionJugador) && myTime > nextFire)
            {
                nextFire = myTime + fireDelta;
                GameObject proyectil = PhotonNetwork.Instantiate("proyectil", Vector3.zero, Quaternion.identity) as GameObject;
                proyectil.transform.position = transform.position + new Vector3(0, 3, 0) + Camera.main.transform.forward * 2;
                Rigidbody rb = proyectil.GetComponent<Rigidbody>();
                rb.velocity = Camera.main.transform.forward * 40;

                nextFire = nextFire - myTime;
                myTime = 0.0f;
            }
        }
    }
    private void PararRotacionEjeX(float valor)
    {
        Vector3 rotacionEuler = CamaraJugador.transform.eulerAngles;
        rotacionEuler.x = valor;
        CamaraJugador.transform.eulerAngles = rotacionEuler;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
            stream.SendNext(CamaraJugador.transform.rotation);
        }
        else
        {
            Vector3 syncPosition = (Vector3)stream.ReceiveNext();
            Quaternion syncRotation = (Quaternion)stream.ReceiveNext();
        }
    }
}
