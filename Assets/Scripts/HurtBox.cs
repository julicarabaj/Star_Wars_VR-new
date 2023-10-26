using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBox : MonoBehaviour
{
    // Start is called before the first frame update

    public float damagePoints;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger no damage");
        damageBox damagebox = other.GetComponent<damageBox>();
        if(damagebox)
        {
            Debug.Log("trigger damage");
            damagebox.TakeHit(damagePoints);
        }
    }
}
