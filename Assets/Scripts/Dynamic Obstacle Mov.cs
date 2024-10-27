using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DynamicObstacleMov : MonoBehaviour
{
    public float speed = 1.19f;
    public Vector3 pointA;
    public Vector3 pointB;

    // Start is called before the first frame update
    void Start()
    {
     
    }

   

    void Update()
    {
        //PingPong between 0 and 1
        float time = Mathf.PingPong(Time.time * speed, 1);
        transform.position = Vector3.Lerp(pointA, pointB, time);
    }
}
