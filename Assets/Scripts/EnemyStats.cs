using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int speed, points;
    public bool autoAim;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<MoveForward>().speed = speed;
        if (autoAim)
            transform.rotation = Quaternion.LookRotation(GameObject.Find("Player").transform.position - transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
