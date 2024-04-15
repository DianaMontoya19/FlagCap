using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthAndDamage : MonoBehaviour
{
    
    [SerializeField] private float Health =  100f;
    private DamageMainWeapon damageMainWeapon;

    private void Start()
    {
        damageMainWeapon = GameObject.FindObjectOfType<DamageMainWeapon>();
    }
    public void IGetDamage(float damageRecive)
    {   
        Health -= damageRecive;   
    }
     public void StarAttack()
    {
        damageMainWeapon.ActivateIsAtacking(true);
    }

}
