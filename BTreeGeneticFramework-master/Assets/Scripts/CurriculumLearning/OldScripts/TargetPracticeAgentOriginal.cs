using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class TargetPracticeAgentOriginal : Agent
{
    //teaching the agent to destroy a target 
    //1: the agent will spawn at a set distance smaller than the max range of the projectile and a random rotation
    //rewards: +1 if target hit -1 if bounds hit -1 if max steps reached
    //2: it will spawn at a set distance equal to max range of projectile and a random rotation
    //rewards: +1 if target hit -1 if bounds hit -1 if max steps reached
    //3: it will spawn at a set distance that is greater than max range of projectile and a random rotation
    //+1 if target hit -1 if bounds hit -1 if max steps reached
    //4: it will spawn at a random spawnPoint and random rotation
    //+1 if target hit -1 if bounds hit -1 if max steps reached
    //5: it will have to shoot the target multiple times to destroy it
    //+1/TargetHealth(number of hits required) if target hit -1 if bounds hit -1 if max steps reached
    //to be implemented
    //6: the target will move around
    //+1/TargetHealth(number of hits required) if target hit -1 if bounds hit -1 if max steps reached
    //tags required: target, bounds, EnvObject
    // private Rigidbody AgentRigidbody;
    // public GameObject bounds;
    // public GameObject spawnPoints;
    // public GameObject target;
    // public Shooting shooting;
    // private int prevTargetHealth;

    // public override void Initialize()
    // {
    //     AgentRigidbody = GetComponent<Rigidbody>();
    //     shooting = GetComponent<Shooting>();
    // }
    // public override void OnEpisodeBegin()
    // {  
    //     float lessonValue = Academy.Instance.EnvironmentParameters.GetWithDefault("tankPos", 0.0f);
    //     prevTargetHealth = target.GetComponent<TargetBehaviour>().targetHealth;
    //     tankSpawn(lessonValue);
    //     target.GetComponent<TargetBehaviour>().targetSpawn(lessonValue);
    //     shooting.ShootingReset();
    //     // goalObject.GetComponent<GoalSpawner>().goalSpawn();

    // }

    // private void tankSpawn(float lessonValue)
    // {
    //     transform.rotation = Quaternion.Euler(new Vector3(0.0f, Random.Range(-180.0f,180.0f), 4.0f));
    //     if(lessonValue <3.0f)
    //     {
    //         transform.localPosition = new Vector3(0, 0, -10 - lessonValue*5);
    //     }
    //     else
    //     {
    //             transform.localPosition = spawnPoints.transform.GetChild((int)Random.Range(0,spawnPoints.transform.childCount-1)).transform.localPosition;
    //     }
    // }
    //     private void Move(float MovementInputValue, float MovementSpeed)
    // {
    //     // Create a vector in the direction the tank is facing with a magnitude based on the input, speed and the time between frames.
    //     Vector3 movement = transform.forward * MovementInputValue * MovementSpeed * Time.deltaTime;

    //     // Apply this movement to the rigidbody's position.
    //     AgentRigidbody.MovePosition(AgentRigidbody.position + movement);
    // }


    // private void Turn(float TurnInputValue, float TurnSpeed)
    // {
    //     // Determine the number of degrees to be turned based on the input, speed and time between frames.
    //     float turn = TurnInputValue * TurnSpeed * Time.deltaTime;

    //     // Make this into a rotation in the y axis.
    //     Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

    //     // Apply this rotation to the rigidbody's rotation.
    //     AgentRigidbody.MoveRotation(AgentRigidbody.rotation * turnRotation);
    // }
    // public override void CollectObservations(VectorSensor sensor)
    // {
    //     sensor.AddObservation(transform.position.normalized);
    //     sensor.AddObservation(transform.rotation.normalized);
    //     sensor.AddObservation(target.transform.position.normalized);
    //     sensor.AddObservation(transform.forward);
    //     sensor.AddObservation((target.transform.position - transform.position).normalized);
    //     sensor.AddObservation(target.GetComponent<TargetBehaviour>().targetHealth);
    //     sensor.AddObservation(shooting.cooldown);
    //     sensor.AddObservation(shooting.ammo);
    // }
    // public override void OnActionReceived(ActionBuffers actions)
    // {
    //     int move = actions.DiscreteActions[0];
    //     int rotate = actions.DiscreteActions[1];
    //     int fire = actions.DiscreteActions[2];
    //     float moveSpeed = 5f;
    //     float rotateSpeed = 180f;
        
    //     if(move == 1)
    //         Move(move, moveSpeed);
    //     if(move == 2)
    //         Move(-1, moveSpeed);
    //     if(rotate == 1)
    //         Turn(rotate, rotateSpeed);
    //     if(rotate == 2)
    //         Turn(-1, rotateSpeed);
    //     if(fire == 1)
    //     {
    //         shooting.Fire();
    //         // Debug.Log(shooting.Fire());
    //     }
    // //    Debug.Log("Fire " + move+ " " + rotate + " " + fire);
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
    // private void FixedUpdate()
    // {
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

    // private void OnTriggerEnter(Collider other) {
    //     if(other.gameObject.tag == "Bounds")
    //         {
    //             SetReward(-1);
    //             Debug.Log("Crash bounds");
    //             EndEpisode();
    //         }    
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
