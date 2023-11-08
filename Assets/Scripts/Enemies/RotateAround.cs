using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : EnemyMovement
{
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float currentDistance = Vector3.Distance(GameObject.FindWithTag("Player").transform.position, this.transform.position); 
    }
}
