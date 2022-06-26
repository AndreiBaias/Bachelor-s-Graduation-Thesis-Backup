using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public void goalSpawn()
    {
        transform.localPosition = new Vector3(Random.Range(-40.0f, 40.0f), 1.5f, Random.Range(-40.0f,40.0f));
        while (Physics.CheckSphere(transform.position, 2, 1<<10))
            transform.localPosition = new Vector3(Random.Range(-40.0f, 40.0f), 1.5f, Random.Range(-40.0f, 40.0f));
    }    
}
