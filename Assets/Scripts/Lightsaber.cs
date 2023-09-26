using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightsaber : MonoBehaviour
{
    private bool activate = false;
    private GameObject laser;
    private Vector3 fullSize;

    void Start()
    {
        laser = transform.Find("SingleLine-TextureAdditive").gameObject;
        fullSize = laser.transform.localScale;
        laser.transform.localScale = new Vector3(fullSize.x, 0, fullSize.z);
    }

    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.One)) //Input.GetKeyDown(KeyCode.Space))
        {
            activate = !activate;
            Debug.Log("Botón One presionado");
        }

        if (activate && laser.transform.localScale.y < fullSize.y)
        {
            laser.transform.localScale += new Vector3(0, 0.0001f, 0);
        }
        else if (activate == false && laser.transform.localScale.y >= 0)
        {
            laser.transform.localScale += new Vector3(0, -0.0001f, 0);
        }
    }
}
