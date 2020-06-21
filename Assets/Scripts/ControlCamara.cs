using UnityEngine;
using System.Collections;

public class ControlCamara : MonoBehaviour
{

    public GameObject target;
    private Vector3 HeightPos = new Vector3((float)0, (float)3, (float)0);

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = target.transform.position + HeightPos;
            transform.rotation = Quaternion.Euler(new Vector3(transform.eulerAngles.x,target.transform.eulerAngles.y,0));
        }
    }
}