using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float mainThrust = 100f;
    public GameObject GameOver;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up*mainThrust*Time.deltaTime);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("obstacle") || collision.transform.CompareTag("boundary"))
        {
            Movement script = FindAnyObjectByType<Movement>();
            GameObject[] Obstacles = GameObject.FindGameObjectsWithTag("obstacle");
            foreach (GameObject obstacle in Obstacles)
            {
                if(obstacle!=null)
                {
                    obstacle.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                }
            }
            script.enabled = false;
            GameOver.SetActive(true);
            Destroy(gameObject);
        }
    }
}
