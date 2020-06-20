using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCaña : MonoBehaviour
{

    public GameObject objPre;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(objPre,transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
