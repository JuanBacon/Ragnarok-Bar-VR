using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuegoPescar : MonoBehaviour
{

    public GameObject canaPescar;
    public bool Pick= false;
    public string Color;

    // Start is called before the first frame update
    void Start()
    {
        //Necesita añadir tags dependiendo del color
        Color = this.gameObject.tag;
    }



    void OnTriggerEnter (Collider other)
    {
       
        other.GetComponentInParent<VaraDePescar>().Pez = this.gameObject;
        Pick = true;
    } 

     void OnTriggerExit (Collider other)
     {

        other.GetComponentInParent<VaraDePescar>().Pez = null;
        Pick = false;
     }

}
