using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageBox : MonoBehaviour
{
    // Start is called before the first frame update
    public HealthScript health;
    public float damageMultiplier = 1;

    public void TakeHit(float damage)
    {
        health.TakeDamage(damage * damageMultiplier);
    }

    private void Awake()
    {
        health = GetComponentInParent<HealthScript>();
    }
}
