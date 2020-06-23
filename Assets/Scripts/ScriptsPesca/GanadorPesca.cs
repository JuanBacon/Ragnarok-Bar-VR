using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GanadorPesca : MonoBehaviour
{

    public GameObject Projo;
    public GameObject Pazul;
    public GameObject Pverde;
    public int Cont=0;
    int PuntR;
    int PuntA;
    int PuntV;
    void Start()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if(Cont ==21)
        {
            PuntR= Projo.GetComponent<VaraDePescar>().Puntaje;
            PuntV= Pverde.GetComponent<VaraDePescar>().Puntaje;
            PuntA= Pazul.GetComponent<VaraDePescar>().Puntaje;

           if(PuntR>PuntV && PuntR>PuntA)
           {
                GetComponent<TextMesh>().text= "EL GANADOR ES EL ROJO"; 
           }else 
           if(PuntV>PuntA && PuntV>PuntR)
           {
                GetComponent<TextMesh>().text= "EL GANADOR ES EL VERDE"; 

           }else 
           if(PuntA>PuntR && PuntA>PuntV)
           {
               GetComponent<TextMesh>().text= "EL GANADOR ES EL AZUL"; 
           }
            GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
