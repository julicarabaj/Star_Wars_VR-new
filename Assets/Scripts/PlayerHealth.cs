using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int disparosRecibidos = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Laser")
        {
            disparosRecibidos++;
            if (disparosRecibidos >= 5)
            {
                 
            }
        }
    }

}
