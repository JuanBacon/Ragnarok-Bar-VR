using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBeerPong : MonoBehaviour
{
    public GameObject beerpong;
    void Start()
    {
       
    }
    void OnTriggerEnter(Collider obj)
    {
        if(obj.gameObject.tag == "proyectil")
        {
            gameObject.transform.parent.gameObject.SetActive(false);
            if(gameObject.transform.parent.gameObject.tag == "beer1")
            {
                beerpong.GetComponent<TurnosBeerpong>().jugador1total += 1;
                Debug.Log("Uno menos al jugador 1");
            }else if (gameObject.transform.parent.gameObject.tag == "beer2")
            {
                beerpong.GetComponent<TurnosBeerpong>().jugador2total += 1;
                Debug.Log("Uno menos al jugador 2");
            }
        }
    }
}
