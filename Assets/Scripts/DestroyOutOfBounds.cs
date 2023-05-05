using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private readonly float positiveBound = 25f;
    private readonly float negativeBound = -25f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > positiveBound || transform.position.z < negativeBound || transform.position.x > positiveBound || transform.position.x < negativeBound)
        {
            Destroy(gameObject);

        }
    }
}
