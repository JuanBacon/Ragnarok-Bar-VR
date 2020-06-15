using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuegoPescar : MonoBehaviour
{

    GameObject canaPescar;
    public string x;

    // Start is called before the first frame update
    void Start()
    {
        canaPescar = GameObject.Find("mjolnir");
    }



    void OnTriggerEnter (Collider other)
    {
       
       other.GetComponentInParent<VaraDePescar>().Pez = this.gameObject;

    } 
}
