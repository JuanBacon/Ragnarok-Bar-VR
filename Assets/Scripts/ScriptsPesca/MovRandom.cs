using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovRandom : MonoBehaviour
{

    public Vector3 NewPos;
    
    public float SegundosMov= 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        SegundosMov -= Time.deltaTime;

        if(SegundosMov<0)
        {
        NewPos = new Vector3(Random.insideUnitSphere.x*1.2f,0,Random.insideUnitSphere.z*1.2f);
        SegundosMov= 3f;
        }
        transform.Translate(NewPos*Time.deltaTime);
        
    }


}
