using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public float agentCooldown = 0.4f;
    public int agentAmmo;
    public int maxAmmo = 3; 
    public Rigidbody shell;
    private float lastFireTime;
    public Transform fireTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShootingReset()
    {
        agentAmmo = maxAmmo;
    }
    public void Fire()
    {
        if (Time.time - lastFireTime < agentCooldown)
            return;
        
        if(agentAmmo == 0)
            {
                gameObject.GetComponent<CRBehavior>().SetReward(-1);
                gameObject.GetComponent<CRBehavior>().EndEpisode();
                Debug.Log("No ammo");
                return;
            }
        
        Rigidbody shellInstance =
            Instantiate(shell, fireTransform.position, fireTransform.rotation) as Rigidbody;
        
        shellInstance.velocity = fireTransform.forward * 10.0f;

        lastFireTime = Time.time;
        agentAmmo--;
    }
}
