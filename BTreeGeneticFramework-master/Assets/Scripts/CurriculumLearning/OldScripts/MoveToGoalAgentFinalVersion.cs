
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using Random=UnityEngine.Random;



public class MoveToGoalAgentOriginal : Agent
{
//     public GameObject goalObject;
//     private Rigidbody AgentRigidbody;
//     public GameObject bounds;
//     public GameObject spawnPoints;

    
//     public override void Initialize()
//     {
//         AgentRigidbody = GetComponent<Rigidbody>();
//     }
//     public override void OnEpisodeBegin()
//     {  
//         float lessonValue = Academy.Instance.EnvironmentParameters.GetWithDefault("tankPos", 0.0f);
//         transform.rotation = Quaternion.Euler(new Vector3(0.0f, Random.Range(-180.0f,180.0f), 0.0f));
//         tankSpawn(spawnPoints.transform.childCount);
//         goalObject.GetComponent<GoalSpawner>().goalSpawn();


//     }
//     private void tankSpawn(int numSpawnPoints)
//     {
//         transform.localPosition = spawnPoints.transform.GetChild((int)Random.Range(0,numSpawnPoints-1)).transform.localPosition;
//     }
    
//     private void FixedUpdate()
//     {
//         if(StepCount >= 20000)
//         {
//             SetReward(Mathf.Max((-2*(goalObject.transform.position - transform.position).magnitude / 128),-1));
//             Debug.Log("Max steps reached");
//             EndEpisode();
//         }
//     }
//     public override void CollectObservations(VectorSensor sensor)
//     {
//         sensor.AddObservation(transform.position.normalized);
//         sensor.AddObservation(transform.rotation.normalized);
//         sensor.AddObservation(goalObject.transform.position.normalized);
//         sensor.AddObservation(transform.forward);
//         sensor.AddObservation((goalObject.transform.position - transform.position).normalized);
//     }
//     private void Move(float MovementInputValue, float MovementSpeed)
//     {
//         // Create a vector in the direction the tank is facing with a magnitude based on the input, speed and the time between frames.
//         Vector3 movement = transform.forward * MovementInputValue * MovementSpeed * Time.deltaTime;

//         // Apply this movement to the rigidbody's position.
//         AgentRigidbody.MovePosition(AgentRigidbody.position + movement);
//     }


//     private void Turn(float TurnInputValue, float TurnSpeed)
//     {
//         // Determine the number of degrees to be turned based on the input, speed and time between frames.
//         float turn = TurnInputValue * TurnSpeed * Time.deltaTime;

//         // Make this into a rotation in the y axis.
//         Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

//         // Apply this rotation to the rigidbody's rotation.
//         AgentRigidbody.MoveRotation(AgentRigidbody.rotation * turnRotation);
//     }
//     public override void OnActionReceived(ActionBuffers actions)
//     {
//         int move = actions.DiscreteActions[0];
//         int rotate = actions.DiscreteActions[1];
        
//         float moveSpeed = 5f;
//         float rotateSpeed = 180f;
        
//         if(move == 1)
//             Move(move, moveSpeed);
//         if(move == 2)
//             Move(-1, moveSpeed);
//         if(rotate == 1)
//             Turn(rotate, rotateSpeed);
//         if(rotate == 2)
//             Turn(-1, rotateSpeed);
        
//     }
    
//     public override void Heuristic(in ActionBuffers actionsOut)
//     {
//         ActionSegment<int> DiscreteActions = actionsOut.DiscreteActions;
//         if(Input.GetAxis("Vertical3") > 0)
//             DiscreteActions[0] = 1;
//         else
//             if(Input.GetAxis("Vertical3") < 0)
//                 DiscreteActions[0] = 2;
//             else
//                 DiscreteActions[0] = 0;
//         if(Input.GetAxis("Horizontal3") > 0)
//             DiscreteActions[1] = 1;
//         else
//             if(Input.GetAxis("Horizontal3") < 0)
//                 DiscreteActions[1] = 2;
//             else
//                 DiscreteActions[1] = 0;
//     }
//    private void OnTriggerEnter(Collider other) {
//         if(other.tag == "Goal")
//         {
//         SetReward(+1f);
//         Debug.Log("Success");
//         EndEpisode();    
//         }
//         if(other.tag == "Bounds")
//         {
//             SetReward(Mathf.Max((-(goalObject.transform.position - transform.position).magnitude / 128),-1));
//             Debug.Log("Failure");
//             EndEpisode();
//         }

//     }

//     private void OnCollisionEnter(Collision other) {
//         if(other.gameObject.tag == "EnvObject")
//             {
//                 SetReward(Mathf.Max((-(goalObject.transform.position - transform.position).magnitude / 128),-1));
//                 Debug.Log("Object hit");
//                 EndEpisode();
//             }
//     }
   
}
