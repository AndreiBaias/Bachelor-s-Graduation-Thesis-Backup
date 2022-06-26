using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnvManager : MonoBehaviour
{
    public GameObject[] envObjects;
    public Rigidbody agent;
    public GameObject bounds;
    public GameObject cliffs;
    public GameObject goal;
    public GameObject target;
    public GameObject spawns;
    public Material sMaterial;
    public Material fMaterial;
    public Material bMaterial;
    public Material msMaterial;
        [SerializeField]
    public Text accText;
    // Start is called before the first frame update
    void Start()
    {
        agent = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        bounds = GameObject.FindGameObjectWithTag("Bounds");
        cliffs = GameObject.Find("Boundaries");
        goal = GameObject.FindGameObjectWithTag("Goal");
        target = GameObject.FindGameObjectWithTag("Target");
        // EnvObjectsToggle(false);
        // RectBoundsManager(5);
        // RandomSpawnRect(5);
        // SquareBoundsManager(10);
        // RandomSpawnPoints(8);
        // GoalSpawn();
        // TagToTarget();
    }
    public void EnvObjectsToggle(bool x)
    {
        envObjects = GameObject.FindGameObjectsWithTag("EnvObject");
        foreach (GameObject o in envObjects)
            o.SetActive(x);
    }

    public void RectBoundsManager(float lessonValue)
    {
        GameObject frontWall = bounds.transform.GetChild(0).gameObject;
        GameObject backWall = bounds.transform.GetChild(1).gameObject;
        GameObject leftWall = bounds.transform.GetChild(2).gameObject;
        GameObject rightWall = bounds.transform.GetChild(3).gameObject;

        frontWall.transform.localPosition = new Vector3(0, 0 , 5 + 2.5f*lessonValue);
        backWall.transform.localPosition = new Vector3(0, 0, -5-2.5f*lessonValue);
        leftWall.transform.localPosition = new Vector3(-5, 0, 0);
        rightWall.transform.localPosition = new Vector3(5, 0, 0);

        Vector3 rescale = new Vector3(15, 1, 1);;
        rescale.x += 5*lessonValue;
        leftWall.transform.localScale = rescale;
        rightWall.transform.localScale = rescale;

        agent.transform.localPosition = backWall.transform.localPosition + new Vector3(0, 0, 2.5f);
        agent.transform.eulerAngles = new Vector3(0, 0, 0);

        goal.transform.localPosition = frontWall.transform.localPosition + new Vector3(0, 0, -2.5f);

    }

    public void RandomSpawnRect(float lessonValue)
    {
        Vector3 frontWall = bounds.transform.GetChild(0).gameObject.transform.localPosition;
        Vector3 backWall = bounds.transform.GetChild(1).gameObject.transform.localPosition;
        agent.transform.localPosition += new Vector3(0, 0, (frontWall-backWall).magnitude * Random.Range(0f, 0.85f));
        goal.transform.localPosition -= new Vector3(0, 0, (frontWall-backWall).magnitude * Random.Range(0f, 0.85f));
        if(agent.transform.localPosition.z-goal.transform.localPosition.z > 0)
        {
            agent.transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    public void SquareBoundsManager(float lessonValue)
    {
        GameObject frontWall = bounds.transform.GetChild(0).gameObject;
        GameObject backWall = bounds.transform.GetChild(1).gameObject;
        GameObject leftWall = bounds.transform.GetChild(2).gameObject;
        GameObject rightWall = bounds.transform.GetChild(3).gameObject;

        frontWall.transform.localPosition = new Vector3(0, 0 , lessonValue);
        backWall.transform.localPosition = new Vector3(0, 0, -lessonValue);
        leftWall.transform.localPosition = new Vector3(-lessonValue, 0, 0);
        rightWall.transform.localPosition = new Vector3(lessonValue, 0, 0);

        Vector3 rescale = new Vector3(1 + 2*lessonValue, 1, 1);
        leftWall.transform.localScale = rescale;
        rightWall.transform.localScale = rescale;
        frontWall.transform.localScale = rescale;
        backWall.transform.localScale = rescale;

        goal.transform.localPosition = new Vector3(Random.Range(leftWall.transform.localPosition.x + 1, rightWall.transform.localPosition.x - 1),
                                                0,
                                                Random.Range(backWall.transform.localPosition.z + 1, frontWall.transform.localPosition.z - 1));
        agent.transform.localPosition = new Vector3(Random.Range(leftWall.transform.localPosition.x + 1, rightWall.transform.localPosition.x - 1),
                                                0,
                                                Random.Range(backWall.transform.position.z + 1, frontWall.transform.position.z - 1));
        //tank must not spawn too close to the goal
        while(Mathf.Abs((goal.transform.localPosition - agent.transform.localPosition).magnitude)<5)
        {
            agent.transform.localPosition = new Vector3(Random.Range(leftWall.transform.localPosition.x + 1, rightWall.transform.localPosition.x -1 ),
                                                    0,
                                                    Random.Range(backWall.transform.localPosition.z + 1, frontWall.transform.localPosition.z - 1));
        }
        
    }

    public void RandomSpawnPoints(int numSpawnPoints)
    {
        spawns = GameObject.FindGameObjectWithTag("SpawnPoint");
        agent.transform.localPosition = spawns.transform.GetChild((int)Random.Range(0,numSpawnPoints-1)).transform.localPosition;
        Transform[] allChildren = bounds.GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            child.gameObject.SetActive(false);
        }
    }

    public void GoalSpawnCenter()
    {
        goal.transform.localPosition = new Vector3(0, 0.5f, 0);
    }

    public void GoalSpawn()
    {
        goal.transform.localPosition = new Vector3(Random.Range(-40.0f, 40.0f), 0.5f, Random.Range(-40.0f,40.0f));
        while (Physics.CheckSphere(transform.localPosition, 5, 1<<10))
            transform.localPosition = new Vector3(Random.Range(-40.0f, 40.0f), 0.5f, Random.Range(-40.0f, 40.0f));
    }  

    public void TargetSpawn()
    {
        goal.transform.localPosition = new Vector3(Random.Range(-40.0f, 40.0f), 0.5f, Random.Range(-40.0f,40.0f));
        while (Physics.CheckSphere(transform.localPosition, 2, 1<<10))
            transform.localPosition = new Vector3(Random.Range(-40.0f, 40.0f), 0.5f, Random.Range(-40.0f, 40.0f));
    }  

    public void TagToTarget()
    {
        goal.transform.tag = "Target";
    }

    public IEnumerator changeMaterial(Material m)
    {
        foreach(Transform child in bounds.transform)
        {
            child.gameObject.GetComponent<Renderer>().material = m;
        }
        yield return new WaitForSeconds(2);
        foreach(Transform child in bounds.transform)
        {
            child.gameObject.GetComponent<Renderer>().material = bMaterial;
        }
    }

    public GameObject getClosestEnemy()
    {
        float minDist = 1000f;
        GameObject closestEnemy = GameObject.FindGameObjectWithTag("Target");
        foreach (GameObject i in GameObject.FindGameObjectsWithTag("Target"))
        {
            float dist = Mathf.Abs((agent.transform.localPosition-i.transform.localPosition).magnitude);
            if(dist < minDist)
            {
                closestEnemy = i;
                minDist = dist;
            }
        }

        return closestEnemy;
    }

    private GameObject getClosestBox(string boxTag)
    {
        float minDist = 1000;
        GameObject closestBox = GameObject.FindGameObjectWithTag(boxTag);
        foreach (GameObject i in GameObject.FindGameObjectsWithTag(boxTag))
        {
            float dist = Mathf.Abs((agent.transform.localPosition-i.transform.localPosition).magnitude);
            if(dist < minDist)
            {
                closestBox = i;
                minDist = dist;
            }
        }

        return closestBox;
    }
    public GameObject[] getClosestBoxes()
    {
        GameObject[] closestBoxes = new GameObject[4];
        
        closestBoxes[0] = getClosestBox("Box_Ammo");
        closestBoxes[1] = getClosestBox("Box_Shield");
        closestBoxes[2] = getClosestBox("Box_WeaponUpgrade");
        closestBoxes[3] = getClosestBox("Box_HP");
        
        for(int i = 0;  i < 4; i++ )
        {
            if (closestBoxes[i] == null)
                closestBoxes[i] = target;
        }
        return closestBoxes;
    }

    // Update is called once per frame
    // void Update()
    // {
        
    // }
}
