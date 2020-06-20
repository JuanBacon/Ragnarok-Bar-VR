using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaraDePescar : MonoBehaviour
{
    public GameObject Pez;
    public GameObject PezPescado;
    public Transform InteractionZone;


    void Update()
    {
        
        if(Pez !=null )
        {
            Pez.transform.SetParent(InteractionZone);
            Pez.GetComponent<Rigidbody>().useGravity= false;
            Pez.GetComponent<Rigidbody>().isKinematic= true;

        }

    }
}
