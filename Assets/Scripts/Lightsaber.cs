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
        source.volume = 0.8f;
        laser = transform.Find("SingleLine-TextureAdditive").gameObject;
        fullSize = laser.transform.localScale;
        laser.transform.localScale = new Vector3(fullSize.x, 0, fullSize.z);
        //rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        OVRInput.Update();
        OVRInput.FixedUpdate();
        InputController();
        LaserController();
        sounds();
    }
    void InputController ()
    {
        if (OVRInput.GetDown(OVRInput.Button.One))
            {
            Debug.Log("Botón One presionado");
            activate = !activate;
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
    void sounds ()
    {
        //var velocity = OVRInput.GetLocalControllerAngularVelocity(controller);
        Vector3 velocidad = rb.velocity;
        if (velocidad.magnitude > 0)
        {
            Debug.Log(":)");
        }
        if (velocidad.magnitude > 6)
        {
            source.PlayOneShot(AudioMovimiento);
        }
        else if (source.isPlaying == false)
        {
            source.PlayOneShot(audioHum);
        }
    }
}