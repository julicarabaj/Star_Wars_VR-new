using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClonGun : MonoBehaviour
{
    public GameObject bullet;
    public GameObject player;
    public Transform bulletSpawn = null;
    public float reloadTime;
    public float inacuracy;
    float currReloadTime;
    float reloadTimeMultiplier;
    float baseReloadTime;
    bool canShoot = false;
    private AudioSource source;
    public AudioClip dispara;
    [SerializeField] Transform rayOrigin;
    [SerializeField] float rayLength;
    void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
        source.spatialBlend = 1;
        source.volume = 0f;
        baseReloadTime = reloadTime;
        currReloadTime = reloadTime;
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        //if raycast lo detecta canshoot true;
    }
    void Disparar()
    {
        var b = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
        //b.transform.eulerAngles += new Vector3(Random.Range(-inacuracy, inacuracy), Random.Range(-inacuracy, inacuracy), Random.Range(-inacuracy, inacuracy));
        currReloadTime = reloadTime;
        source.PlayOneShot(dispara);
    }
    void FixedUpdate()
    {
        Ray ray = new Ray(rayOrigin.position, rayOrigin.forward);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, rayLength))
        {
            if (hitInfo.collider.gameObject.CompareTag("Player"))
            {
                canShoot = true;
            }
        }
        if (canShoot)
        {
            if (currReloadTime > 0)
            {
                currReloadTime -= Time.deltaTime;
            }
            else
            {
                Disparar();
            }
        }
        else
        {
            reloadTime = baseReloadTime;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(rayOrigin.position, rayOrigin.position + rayOrigin.forward * rayLength);
    }
}
