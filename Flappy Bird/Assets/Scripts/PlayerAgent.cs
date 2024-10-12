using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
using UnityEngine.SceneManagement;

public class PlayerAgent: Agent
{
    Rigidbody2D rb;
    [SerializeField] float mainThrust = 100f;
    int jump = 0;
    Movement script ;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        script = FindAnyObjectByType<Movement>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            jump = 1;
        }
        else
        {
            jump = 0;
        }
    }

    public override void OnEpisodeBegin()
    {
        transform.position = new Vector2(-1.48000002f, 0.851028919f);
        transform.rotation = Quaternion.identity;
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0;
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("obstacle");
        /*foreach (GameObject obstacle in obstacles)
        {
            Destroy(obstacle); 
        }*/
        if (script != null)
        {
            script.enabled = true;
        }
    }
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.position.y);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        if (actions.DiscreteActions[0]==1)
        rb.AddRelativeForce(Vector3.up*mainThrust*Time.deltaTime);
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<int> actionSegment = actionsOut.DiscreteActions;
        actionSegment[0] = jump;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("obstacle") || collision.transform.CompareTag("boundary"))
        {
            GameObject[] Obstacles = GameObject.FindGameObjectsWithTag("obstacle");
            foreach (GameObject obstacle in Obstacles)
            {
                obstacle.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
            script.enabled = false;
            AddReward(-50f);
            EndEpisode();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("pass"))
        {
            AddReward(5f);
        }
    }
}