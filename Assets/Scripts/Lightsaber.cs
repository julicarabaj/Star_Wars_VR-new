using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightsaber : MonoBehaviour
{
    public OVRInput.Controller controller;
    private bool activate = false;
    private GameObject laser;
    private Vector3 fullSize;
    private AudioSource source;
    public AudioClip audioclip;
    public AudioClip audioHum;

    void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
        source.spatialBlend = 1;
        source.volume = 0.3f;
        laser = transform.Find("SingleLine-TextureAdditive").gameObject;
        fullSize = laser.transform.localScale;
        laser.transform.localScale = new Vector3(fullSize.x, 0, fullSize.z);
    }

    void Update()
    {
        InputController();
        LaserController();
        var velocity = OVRInput.GetLocalControllerAngularVelocity(controller);
        if (velocity.magnitude > 1)
        {
            source.PlayOneShot(audioclip);
        }
        else if (source.isPlaying == false)
        {
            source.PlayOneShot(audioHum);
        }
    }
    void InputController ()
    {
        if (Input.GetKeyDown(KeyCode.Space))//(OVRInput.Get(OVRInput.Button.One))
        {
            Debug.Log("Botón One presionado");
            activate = !activate;
        }

    }
    void LaserController ()
    {
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
