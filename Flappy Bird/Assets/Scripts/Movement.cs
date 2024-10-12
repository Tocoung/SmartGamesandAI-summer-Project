/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed;
    GameObject[] Obstacles;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        Obstacles=GameObject.FindGameObjectsWithTag("obstacle");
        foreach(GameObject obstacle in Obstacles)
        {
            obstacle.GetComponent<Rigidbody2D>().velocity = new Vector2(-1,0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += new Vector3(-1,0,0)*speed*Time.deltaTime;
        //rb.velocity  = new Vector2(1,0);
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical=Input.GetAxis("Vertical");
        rb.velocity=new Vector2(Horizontal,Vertical)*1f;
        //Obstacles=GameObject.FindGameObjectWithTag("obstacle");
    }
}*/
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Movement : MonoBehaviour
{
    GameObject[] Obstacles;
    // Start is called before the first frame update
    public GameObject[] Prefabs;
    bool spawn = true;
    void Start()
    {
        Obstacles = GameObject.FindGameObjectsWithTag("obstacle");
        foreach(GameObject obstacle in Obstacles)
        {
            obstacle.GetComponent<Rigidbody2D>().velocity = new Vector2(-1, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Obstacles = GameObject.FindGameObjectsWithTag("obstacle");
        foreach(GameObject obstacle in Obstacles)
        {
            obstacle.GetComponent<Rigidbody2D>().velocity = new Vector2(-1, 0);
            if (obstacle.transform.position.x < -15)
            {
                Destroy(obstacle);
            }
        }
        if (spawn)
        {
            Invoke("Spawn", 3);
            spawn = false;
        }
    }

    void Spawn()
    {
        int index = Random.Range(0, 4);
        float y=Random.Range(0.5f,2.0f);
        GameObject pillar = Instantiate(Prefabs[index], new Vector2(14.00f, y),Quaternion.identity);
        spawn = true;
    }
}
