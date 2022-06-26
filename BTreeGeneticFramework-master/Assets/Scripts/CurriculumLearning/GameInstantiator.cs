using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInstantiator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject game;
    void Start()
    {
        for (int x = 0; x< 4; x++)
            for (int z = 0; z < 4; z++)
            {
                Instantiate(game, new Vector3(128 * x, 0, 128 * z), Quaternion.identity);
            }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
