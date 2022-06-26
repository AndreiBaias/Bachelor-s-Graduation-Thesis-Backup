
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
// using Unity.MLAgents;
// using Unity.MLAgents.Actuators;
// using Unity.MLAgents.Sensors;
using Random=UnityEngine.Random;



public class MoveToGoalAgent : MonoBehaviour//Agent
{
    // public Vector3 goalObject;
    // private Rigidbody AgentRigidbody;
    // public GameObject bounds;
    // public GameObject spawnPoints;
    // public GameObject target;
    // public Shooting shooting;
    // public int prevTargetHealth;

    
    // public override void Initialize()
    // {
    //     AgentRigidbody = GetComponent<Rigidbody>();
    //     shooting = GetComponent<Shooting>();
    //     target = GameObject.FindWithTag("Target");
    // }
    // public override void OnEpisodeBegin()
    // {  
    //     float lessonValue = Academy.Instance.EnvironmentParameters.GetWithDefault("tankPos", 0.0f);
    //     transform.rotation = Quaternion.Euler(new Vector3(0.0f, Random.Range(-180.0f,180.0f), 0.0f));
    //     target = GameObject.FindWithTag("Target"); 
    //     target.GetComponent<TargetBehaviour>().targetSpawn(lessonValue);
    //     tankSpawn(spawnPoints.transform.childCount);
    //     prevTargetHealth = target.GetComponent<TargetBehaviour>().targetHealth;
    //     shooting.ShootingReset();


    // }
    // private void tankSpawn(int numSpawnPoints)
    // {
    //     transform.localPosition = spawnPoints.transform.GetChild((int)Random.Range(0,numSpawnPoints-1)).transform.localPosition;
    // }
    
    // private void FixedUpdate()
    // {
    //     goalObject = (transform.position - target.transform.position) - new Vector3(0, 0, 19f);
    //     if(StepCount >= 20000)
    //     {
    //         SetReward(-1);
    //         Debug.Log("Max steps reached");
    //         EndEpisode();
    //     }
    //     if(target.GetComponent<TargetBehaviour>().targetHealth != prevTargetHealth)
    //         {
    //             prevTargetHealth = target.GetComponent<TargetBehaviour>().targetHealth;
    //             SetReward(Mathf.Max(+1.0f/target.GetComponent<TargetBehaviour>().maxHealth,1.0f));
    //             if(target.GetComponent<TargetBehaviour>().targetHealth == 0)
    //             {
    //                 Debug.Log("Target dead");
    //                 EndEpisode();
    //             }
    //         }
    // }
    // public override void CollectObservations(VectorSensor sensor)
    // {
    //     sensor.AddObservation(transform.position.normalized);
    //     sensor.AddObservation(transform.rotation.normalized);
    //     sensor.AddObservation(goalObject.normalized);
    //     sensor.AddObservation(transform.forward);
    //     sensor.AddObservation((goalObject - transform.position).normalized);
    //     sensor.AddObservation((target.transform.position - transform.position).normalized);
    //     sensor.AddObservation(target.GetComponent<TargetBehaviour>().targetHealth);
    //     sensor.AddObservation(shooting.cooldown);
    //     sensor.AddObservation(shooting.ammo);
    // }
    // public void Move(float MovementInputValue, float MovementSpeed)
    // {
    //     // Create a vector in the direction the tank is facing with a magnitude based on the input, speed and the time between frames.
    //     Vector3 movement = transform.forward * MovementInputValue * MovementSpeed * Time.deltaTime;

    //     // Apply this movement to the rigidbody's position.
    //     AgentRigidbody.MovePosition(AgentRigidbody.position + movement);
    // }


    // public void Turn(float TurnInputValue, float TurnSpeed)
    // {
    //     // Determine the number of degrees to be turned based on the input, speed and time between frames.
    //     float turn = TurnInputValue * TurnSpeed * Time.deltaTime;

    //     // Make this into a rotation in the y axis.
    //     Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

    //     // Apply this rotation to the rigidbody's rotation.
    //     AgentRigidbody.MoveRotation(AgentRigidbody.rotation * turnRotation);
    // }
    // public override void OnActionReceived(ActionBuffers actions)
    // {
    //     int move = actions.DiscreteActions[0];
    //     int rotate = actions.DiscreteActions[1];
    //     int fire = actions.DiscreteActions[2];
    //     float moveSpeed = 5f;
    //     float rotateSpeed = 180f;
        
    //     if(move == 1)
    //         GetComponent<MoveToGoalAgent>().Move(move, moveSpeed);
    //     if(move == 2)
    //         GetComponent<MoveToGoalAgent>().Move(-1, moveSpeed);
    //     if(rotate == 1)
    //         GetComponent<MoveToGoalAgent>().Turn(rotate, rotateSpeed);
    //     if(rotate == 2)
    //         GetComponent<MoveToGoalAgent>().Turn(-1, rotateSpeed);
    //     if(fire == 1)
    //     {
    //         shooting.Fire();
    //     }
    // }
    
    // public override void Heuristic(in ActionBuffers actionsOut)
    // {
    //     ActionSegment<int> DiscreteActions = actionsOut.DiscreteActions;
    //     if(Input.GetAxis("Vertical3") > 0)
    //         DiscreteActions[0] = 1;
    //     else
    //         if(Input.GetAxis("Vertical3") < 0)
    //             DiscreteActions[0] = 2;
    //         else
    //             DiscreteActions[0] = 0;
    //     if(Input.GetAxis("Horizontal3") > 0)
    //         DiscreteActions[1] = 1;
    //     else
    //         if(Input.GetAxis("Horizontal3") < 0)
    //             DiscreteActions[1] = 2;
    //         else
    //             DiscreteActions[1] = 0;
    //     if(Input.GetKey("space") == true)
    //         DiscreteActions[2] = 1;
    //     else
    //         DiscreteActions[2] = 0;
        
        
    // }

    // private void OnTriggerEnter(Collider other) {
    //     if(other.gameObject.tag == "Bounds")
    //         {
    //             SetReward(-1);
    //             Debug.Log("Crash bounds");
    //             EndEpisode();
    //         }    
    //     if(other.gameObject.tag == "Target")
    //     {
    //         SetReward(-1);
    //         Debug.Log("Crash target");
    //         EndEpisode();
    //     }
    // }
    // private void OnCollisionEnter(Collision other) {
    //     if(other.gameObject.tag == "EnvObject")
    //         {
    //             SetReward(-1);
    //             Debug.Log("Crash object");
    //             EndEpisode();
    //         }
    // }
}
