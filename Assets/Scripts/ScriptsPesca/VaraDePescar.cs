using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaraDePescar : MonoBehaviour
{
    public GameObject Pez;
    public GameObject PezPescado;
    public Transform InteractionZone;
    public string ColorCanaPescar;
    public int Puntaje=0;
    public GameObject SeFue;

    void Update()
    {
        // valida si ya tiene un objeto en el collider
        if(Pez !=null && Pez.GetComponent<JuegoPescar>().Pick == true && PezPescado==null)
        {
            Pez.transform.SetParent(InteractionZone);
            Pez.GetComponent<Rigidbody>().useGravity= false;
            Pez.GetComponent<Rigidbody>().isKinematic= true;

            if(ColorCanaPescar== Pez.GetComponent<JuegoPescar>().Color)
            {                
                Puntaje+= 2;
            } else  if(ColorCanaPescar!= Pez.GetComponent<JuegoPescar>().Color)
            {                
                Puntaje-= 3;
            } 
            
           Destroy(Pez);
           SeFue.GetComponent<GanadorPesca>().Cont+=1;
        }
        else if (PezPescado!=null)
        {



        }

        

    }
}
