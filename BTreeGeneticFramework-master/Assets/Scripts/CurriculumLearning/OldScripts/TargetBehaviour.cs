using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehaviour : MonoBehaviour
{
    public int targetHealth;
    public int maxHealth;
    public bool dead;
    
    public void targetSpawn(float lessonValue)
    {
        dead = false;      
        goalSpawn();  
        if(lessonValue <3.0f)
        {
            targetHealth = 1;
            // transform.localPosition = new Vector3(0, 0, 10 + lessonValue*5);
        }
        else
        {
            if(lessonValue == 3.0f)
                targetHealth = 1;
            else
                targetHealth = 3;
            // transform.localPosition = new Vector3(Random.Range(-40.0f, 40.0f), 1.5f, Random.Range(-40.0f,40.0f));
            //for final training
            // while (Physics.CheckSphere(transform.position, 2, 1<<10))
            //     transform.localPosition = new Vector3(Random.Range(-40.0f, 40.0f), 1.5f, Random.Range(-40.0f, 40.0f)); 
        }
        maxHealth = targetHealth;
    }

    public void goalSpawn()
    {
        transform.localPosition = new Vector3(Random.Range(-40.0f, 40.0f), 1.5f, Random.Range(-40.0f,40.0f));
        while (Physics.CheckSphere(transform.position, 2, 1<<10))
            transform.localPosition = new Vector3(Random.Range(-40.0f, 40.0f), 1.5f, Random.Range(-40.0f, 40.0f));
    }    

    private int OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Shell")
            {
                targetHealth--;
                Debug.Log("Target hit");
            }
        return targetHealth;
    }
}
