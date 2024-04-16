using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMainWeapon : MonoBehaviour
{
    private float damage = 5f;
    private bool isAttacking;

    private void Start()
    {
        isAttacking = false;
    }

    public void ActivateIsAtacking(bool isAtacking)
    {
        isAttacking = isAtacking;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (isAttacking)
        {
            if (other.tag == "Skeletor")
            {

                other.GetComponent<HealthAndDamage>().IGetDamage(damage);
                
            }

            isAttacking = false;
        }
    }
}
