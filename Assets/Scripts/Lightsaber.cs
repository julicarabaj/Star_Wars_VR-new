using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightsaber : MonoBehaviour
{
    public OVRInput.Controller controller;
    private bool activate = false;
    private GameObject laser;
    public GameObject lightsaber;
    private Vector3 fullSize;
    private AudioSource source;
    public AudioClip AudioMovimiento;
    public AudioClip audioHum;
    private Rigidbody rb;

    void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
        source.spatialBlend = 1;
        source.volume = 3f;
        laser = transform.Find("SingleLine-TextureAdditive").gameObject;
        fullSize = laser.transform.localScale;
        laser.transform.localScale = new Vector3(fullSize.x, 0, fullSize.z);
       // rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        OVRInput.Update();
        OVRInput.FixedUpdate();
        InputController();
        LaserController();
        //Sounds();
    }
    void InputController ()
    {
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            Debug.Log("Botón One presionado");
            activate = !activate;

            // Si el botón One está encendido, reproducir el sonido de audioHum
            if (activate)
            {
                source.PlayOneShot(audioHum);
            }
            else
            {
                source.Stop();
            }
        }
    }
    void LaserController ()
    {
        if (activate && laser.transform.localScale.y < fullSize.y)
        {
            laser.transform.localScale += new Vector3(0, 0.001f, 0);
        }
        else if (activate == false && laser.transform.localScale.y >= 0)
        {
            laser.transform.localScale += new Vector3(0, -0.001f, 0);
        }
    }   
  void Sounds()
    {
        Vector3 velocidad = OVRInput.GetLocalControllerAngularVelocity(controller);

        // Verificar si la velocidad de la mano derecha es mayor a 5
        if (velocidad.magnitude > 5)
        {
            source.PlayOneShot(AudioMovimiento);
        }
    }
}