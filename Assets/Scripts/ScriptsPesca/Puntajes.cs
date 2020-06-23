using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puntajes : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Cana;
    public string PuntajeCa;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PuntajeCa =Cana.GetComponent<VaraDePescar>().Puntaje.ToString();
        GetComponent<TextMesh>().text= PuntajeCa; 
    }
}
