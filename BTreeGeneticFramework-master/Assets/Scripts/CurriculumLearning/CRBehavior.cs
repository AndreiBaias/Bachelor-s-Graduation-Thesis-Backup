using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine.UI;



public class CRBehavior : Agent
{
    private GameObject goalObject;
    private GameObject targetObject;
    private Rigidbody AgentRigidbody;
    private ShootingScript shootingScript;
    private UpgradeScript upgradeScript;
    private TargetScript targetScript;
    private TargetBehaviour targetBehaviour;
    private EnvManager EM;
    private GameObject closestEnemy;
    private GameObject[] closestBoxes;
    public int debugS;
    public int debugB;
    public int debugMS;
    public int eps;
    public float acc;
    public float lessonValue;
    [SerializeField]
    public Text accText;
    private float oldRelativePos;
    private float newRelativePos;
//and than your can get you value for example in OnEpisodeBeginn()
// distanceToAgent = m_ResetParams.GetWithDefault("distanceToAgent", 1.0f);
    
    public override void Initialize()
    {
        EM = GetComponent<EnvManager>();

        goalObject = GameObject.FindGameObjectWithTag("Goal");
        targetObject = GameObject.FindGameObjectWithTag("Target");
        // bMaterial = bounds.transform.GetChild(0).gameObject.GetComponent<Renderer>().material;
        AgentRigidbody = GetComponent<Rigidbody>();
        shootingScript = GetComponent<ShootingScript>();
        upgradeScript = GetComponent<UpgradeScript>();
        targetScript = targetObject.GetComponent<TargetScript>();

        debugS = 0;
        debugB = 0;
        debugMS = 0;
        eps = 0;
        acc = 0f;
    }
    public override void OnEpisodeBegin()
    {  
       
        eps++;
        lessonValue = Academy.Instance.EnvironmentParameters.GetWithDefault("CRTraining", 31.0f);
        goalObject = EM.goal;
        targetObject = EM.target;
        closestEnemy = EM.getClosestEnemy();
        closestBoxes = EM.getClosestBoxes();
        shootingScript.ShootingReset();
        
        if (lessonValue < 5)
        {
            EM.EnvObjectsToggle(false);
            EM.RectBoundsManager(lessonValue);
        }
        else
            if( lessonValue > 4 && lessonValue < 10)
            {
                EM.EnvObjectsToggle(false);
                EM.RectBoundsManager(lessonValue);
                EM.RandomSpawnRect(lessonValue);
            }
            else
            if(lessonValue > 9 && lessonValue < 15)
            {
                EM.EnvObjectsToggle(false);
                EM.SquareBoundsManager(lessonValue);
            }
            else
                if(lessonValue == 15)
                {
                    EM.EnvObjectsToggle(false);
                    EM.RandomSpawnPoints(8);
                    EM.GoalSpawn();
                }
                else
                    if((int)lessonValue%2 == 0)
                    {
                        EM.RandomSpawnPoints((int)(0.5*lessonValue - 7));
                        EM.EnvObjectsToggle(true);
                        EM.GoalSpawnCenter();
                    }
                    else
                    {
                        EM.RandomSpawnPoints((int)(0.5*(lessonValue-1) - 7));
                        EM.EnvObjectsToggle(true);
                        EM.GoalSpawn();
                    }
                   
        // GoalSpawn();
        // transform.localPosition = new Vector3(-30, 0, -5*lessonValue);
        // backWall = bounds.transform.GetChild(1).gameObject;
        // backWall.transform.localPosition = transform.localPosition + new Vector3(0, 0, -5);
        // transform.rotation = Quaternion.identity;
        // Debug.Log("Lesson number: " + lessonValue);
         oldRelativePos = Vector3.ClampMagnitude((goalObject.transform.position - transform.position),1).magnitude;
    }
    
    private void FixedUpdate()
    {
        if(eps > 0)
            acc = (float)debugS / ((float)eps - 1);
        else
            eps++;
        accText.text = "Cumulative reward: " + GetCumulativeReward().ToString() + "\nGoal reached: " + debugS.ToString() + "\nObjects hit: " + debugB.ToString() + "\nMax steps: " + debugMS.ToString()+"\nEpisodes: "+ (eps-1).ToString() + "\nAccuracy: " + acc;
        if (lessonValue < 15){
            if(StepCount >= 1000)
            {
                // AddReward(-1.2f);
                debugMS++;
                EM.changeMaterial(EM.msMaterial);
                if(lessonValue <=31)
                {
                    SetReward( - 1.2f+1-Vector3.ClampMagnitude((goalObject.transform.position - transform.position),1).magnitude);
                }

                EndEpisode();
            }
        }
        else
        if(StepCount >= 10000)
            {
                // AddReward(-1.2f);
                debugMS++;
                EM.changeMaterial(EM.msMaterial);
                // if(lessonValue <=31)
                // {
                //     SetReward( - 1.2f+1-Vector3.ClampMagnitude((goalObject.transform.position - transform.position),1).magnitude);

                // }

                EndEpisode();
            }
        closestEnemy = EM.getClosestEnemy();
        closestBoxes = EM.getClosestBoxes();

        newRelativePos = Vector3.ClampMagnitude((goalObject.transform.position - transform.position),1).magnitude;
        if (newRelativePos < oldRelativePos)
            AddReward(+0.0001f);
        
        oldRelativePos = Vector3.ClampMagnitude((goalObject.transform.position - transform.position),1).magnitude;

        // if(targetScript.targetHealth != targetScript.prevTargetHealth)
        // {
        //     targetScript.prevTargetHealth = targetScript.targetHealth;
        //     SetReward(Mathf.Max(+1.0f/targetScript.maxHealth,1.0f));
        //     if(targetScript.targetHealth == 0)
        //     {
        //         Debug.Log("Target dead");
        //         EndEpisode();
        //     }
        // }
        // AddReward(-1/MaxStep);
    }
    // private float DistanceToGoal()
    // {
    //     return (transform.position - goalObject.transform.position).magnitude;
    // }
    public override void CollectObservations(VectorSensor sensor)
    {
//for movement
        sensor.AddObservation(transform.position.normalized); // Vector3
        sensor.AddObservation(transform.rotation.normalized);// Quaternion
        sensor.AddObservation(Vector3.ClampMagnitude((goalObject.transform.position - transform.position),1).magnitude);// float
    
//for shooting a target    
        sensor.AddObservation(Vector3.ClampMagnitude((targetObject.transform.position - transform.position),1).magnitude);// float
        sensor.AddObservation(targetObject.GetComponent<TargetScript>().targetHealth);// Target Health -> float -> 1
        sensor.AddObservation(shootingScript.agentCooldown);// Shooting Cooldown -> float -> 1
        sensor.AddObservation(shootingScript.agentAmmo);// Ammo -> float -> 1

//for fighting an enemy
//obs: need to implement a danger system which returns a gameObject which will be the enemy and then target becomes that gameObject
        sensor.AddObservation(upgradeScript.agentShieldActive);// Shield Active -> bool -> 1
        sensor.AddObservation(upgradeScript.agentHealth);// Health -> float -> 1
        sensor.AddObservation(upgradeScript.agentLives);// Num Lives -> float -> 1
        sensor.AddObservation(upgradeScript.agentWeaponUpgrade);// Weapon upgraded ->bool -> 1
        sensor.AddObservation(Vector3.ClampMagnitude((closestEnemy.transform.position- transform.position),1).magnitude);// float
        sensor.AddObservation(closestEnemy.transform.rotation);// Rotation of closest enemy -> quaternion -> 4
        sensor.AddObservation(closestEnemy.GetComponent<TargetScript>().enemyShieldActive);// Enemy Shield Active -> bool -> 1
        sensor.AddObservation(closestEnemy.GetComponent<TargetScript>().enemyWeaponUpgrade);// Enemy Weapon Upgraded -> bool -> 1
        sensor.AddObservation(closestEnemy.GetComponent<TargetScript>().enemyHealth);// Enemy Health -> float -> 1
        foreach (GameObject i in closestBoxes)
        {
            sensor.AddObservation(Vector3.ClampMagnitude((i.transform.position- transform.position),1).magnitude);// float
        }

        Debug.Log("Collection observations");
         //total : 45
        //RaysPerDirection : 4
        //
    }
    private void Move(float MovementInputValue, float MovementSpeed)
    {
        // Create a vector in the direction the tank is facing with a magnitude based on the input, speed and the time between frames.
        Vector3 movement = transform.forward * MovementInputValue * MovementSpeed * Time.deltaTime;

        // Apply this movement to the rigidbody's position.
        AgentRigidbody.MovePosition(AgentRigidbody.position + movement);
        Debug.Log("I am moving");
    }

    //https://docs.unity3d.com/ScriptReference/Transform-eulerAngles.html

    private void Turn(float TurnInputValue, float TurnSpeed)
    {
        // Determine the number of degrees to be turned based on the input, speed and time between frames.
        float turn = TurnInputValue * TurnSpeed * Time.deltaTime;

        // Make this into a rotation in the y axis.
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

        // Apply this rotation to the rigidbody's rotation.
        AgentRigidbody.MoveRotation(AgentRigidbody.rotation * turnRotation);
    }
    public override void OnActionReceived(ActionBuffers actions)
    {
        
        int move = actions.DiscreteActions[0];
        int rotate = actions.DiscreteActions[1];
        int fire = actions.DiscreteActions[2];

        float moveSpeed = 5f;
        float rotateSpeed = 180f;
        
        if(move == 1)
            Move(move, moveSpeed);
        if(move == 2)
            Move(-1, moveSpeed);
        if(rotate == 1)
            Turn(rotate, rotateSpeed);
        if(rotate == 2)
            Turn(-1, rotateSpeed);
        // if(fire == 1)
        // {
            // shootingScript.Fire();
        // }       
        Debug.Log("Action received");
        Debug.Log("move: " + move);
        Debug.Log("rotate: " + rotate);
        Debug.Log("fire: " + fire);
        
        // AddReward(-0.0001f);
    }
    
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<int> DiscreteActions = actionsOut.DiscreteActions;
        // Forward movement decision
        if(Input.GetAxis("Vertical3") > 0)
            DiscreteActions[0] = 1;
        else
            if(Input.GetAxis("Vertical3") < 0)
                DiscreteActions[0] = 2;
            else
                DiscreteActions[0] = 0;
        //Turning decision
        if(Input.GetAxis("Horizontal3") > 0)
            DiscreteActions[1] = 1;
        else
            if(Input.GetAxis("Horizontal3") < 0)
                DiscreteActions[1] = 2;
            else
                DiscreteActions[1] = 0;
        //Fire decision
        if(Input.GetKey("space") == true)
            DiscreteActions[2] = 1;
        else
            DiscreteActions[2] = 0;
    }

    public void OnTriggerEnter(Collider other) {
        if(other.tag == "Goal")
            {
            // if (lessonValue>9)
                // SetReward(+lessonValue*0.1f + 1f);
            // else
                SetReward(+1f);
            debugS++;
            // Debug.Log("Success");
            StartCoroutine(EM.changeMaterial(EM.sMaterial));
            // Debug.Log(GetCumulativeReward());
            EndEpisode();    
            }

        if(other.transform.parent.gameObject.tag == "Bounds")
            {
                // AddReward(-1f);
                // Debug.Log("Failure distance: " + (-Math.Abs(DistanceToGoal())).ToString());
                // Debug.Log(GetCumulativeReward());
                // Debug.Log("Failure");
                debugB++;
                StartCoroutine(EM.changeMaterial(EM.fMaterial));
                if(lessonValue <=31)
            {
                SetReward(- 1+1-Vector3.ClampMagnitude((goalObject.transform.position - transform.position),1).magnitude);
            }
                EndEpisode();
            }
        if(other.gameObject.tag == "Cliff")
            {
                
                SetReward(-1.1f+1-Vector3.ClampMagnitude((goalObject.transform.position - transform.position),1).magnitude);
                // if(lessonValue <=31)
            // {
                // SetReward(-(goalObject.transform.position - transform.position).magnitude);
            // }
                EndEpisode();
                debugB++;

            }   
        Debug.Log(other.name + "trigger");

    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "EnvObject" || other.gameObject.transform.parent.tag == "EnvObject")
            {
                // AddReward(-1);
                debugB++;
                if(lessonValue <=31)
            {
                SetReward(- 1.5f+1-Vector3.ClampMagnitude((goalObject.transform.position - transform.position),1).magnitude);
            }
                // Debug.Log("Crash object");
                EndEpisode();
            }
        

    }
}
