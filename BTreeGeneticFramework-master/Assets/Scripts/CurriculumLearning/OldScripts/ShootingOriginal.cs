using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingOriginal : MonoBehaviour
{
    // public float cooldown = 0.4f;
    // public int ammo;
    // public int maxAmmo = 3;
    // public Rigidbody shell;
    // private float lastFireTime;
    // public Transform fireTransform;
    // public void ShootingReset()
    // {
    //     ammo = maxAmmo;
    // }
    // public void Fire()
    // {
    //     if (Time.time - lastFireTime < cooldown)
    //         return;
        
    //     if(ammo == 0)
    //         {
    //             gameObject.GetComponent<TargetPracticeAgent>().SetReward(-1);
    //             gameObject.GetComponent<TargetPracticeAgent>().EndEpisode();
    //             Debug.Log("No ammo");
    //             return;
    //         }
        
    //     Rigidbody shellInstance =
    //         Instantiate(shell, fireTransform.position, fireTransform.rotation) as Rigidbody;
        
    //     shellInstance.velocity = fireTransform.forward * 10.0f;

    //     lastFireTime = Time.time;
    //     ammo--;
    // }

}
